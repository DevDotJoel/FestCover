
using ErrorOr;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using FestCover.Application.Common.Contracts;
using FestCover.Application.Common.Models.Auth;
using FestCover.Infrastructure.Common.Persistence.Identity;

namespace AfterLife.Infrastructure.Persistence.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly ITokenClaimService _tokenService;
        public IdentityService(
            UserManager<User> userManager,
            RoleManager<Role> roleManager,
            ITokenClaimService tokenService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _tokenService = tokenService;
        }

        public async Task<ErrorOr<TokenResultModel>> LoginJwtAsync(string email, string password)
        {

            var user = await _userManager.FindByEmailAsync(email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, password))
                return Error.Conflict(description: "Email or Password wrong");
            var role = await _userManager.GetRolesAsync(user);
            var roleName = role.FirstOrDefault();
            var currentRole = await _roleManager.Roles.Where(r => r.Name == roleName).FirstOrDefaultAsync();
            var roleClaims = await _roleManager.GetClaimsAsync(currentRole);
            var currentClaims = roleClaims.Select(r => r.Value).ToList();
            var tokenResult = _tokenService.GetToken(user.Email, user.Id.ToString(), roleName);
            user.RefreshToken = tokenResult.RefreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);
            user.LastLoginTime= DateTime.Now;
            await _userManager.UpdateAsync(user);
            return tokenResult;
        }

        public async Task<ErrorOr<Success>> Register(string username, string email, string password, string password2)
        {
            var userEmailExists = await _userManager.FindByEmailAsync(email);
            if (userEmailExists != null)
            {
                return Error.Conflict(description: "This email is already been used by another user");
            }
            var userUsernameExists = await _userManager.FindByNameAsync(username);
            if (userUsernameExists != null)
            {
                return Error.Conflict(description: "This username is already been used by another user");
            }
            else
            {

                var role = await _roleManager.FindByNameAsync("User");
                if (role == null)
                {
                    return Error.NotFound(description: "Role not found");
                }
                var createUser = new User
                {
                    UserName = username,
                    NormalizedUserName = username.ToUpper(),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    EmailConfirmed = true,
                    Email = email,
                    NormalizedEmail = email.ToUpper(),
                };
                var result = await _userManager.CreateAsync(createUser, password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(createUser, role.Name);
                    return Result.Success;

                }
                else
                {
                    return Error.Unexpected();
                }
            }
        }

        public async Task<ErrorOr<AuthUserModel>> GetUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return Error.Conflict(description: "User not found");
            var role = await _userManager.GetRolesAsync(user);
            var roleName = role.FirstOrDefault();
            var currentUser = new AuthUserModel(
                Id: user.Id,
                Username: user.UserName,
                Email: user.Email
           );
            return currentUser;

        }
        public async Task<ErrorOr<TokenResultModel>> RefreshToken(TokenResultModel currentToken)
        {

            var principal = _tokenService.GetPrincipalFromExpiredToken(currentToken.AccessToken);
            if(principal.IsError)
            {
                return principal.Errors;
            }
            var userId = principal.Value.FindFirst("UserId")?.Value;
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null || user.RefreshToken != currentToken.RefreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
            {
                return Error.Failure(description: "Refresh Token Expired");
            }

            var role = await _userManager.GetRolesAsync(user);
            var roleName = role.FirstOrDefault();
            var currentRole = await _roleManager.Roles.Where(r => r.Name == roleName).FirstOrDefaultAsync();
            var roleClaims = await _roleManager.GetClaimsAsync(currentRole);
            var currentClaims = roleClaims.Select(r => r.Value).ToList();
            var tokenResult = _tokenService.GetToken(user.Email, user.Id.ToString(), roleName);
            user.RefreshToken = tokenResult.RefreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);
            user.LastLoginTime = DateTime.Now;
            await _userManager.UpdateAsync(user);
            return tokenResult;
        }

        public async Task<ErrorOr<Success>> Logout(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return Error.Failure(description: "User not Found");
            }
            user.RefreshTokenExpiryTime = null;
            user.RefreshToken = null;
            await _userManager.UpdateAsync(user);
            return Result.Success;
        }
    }
}
