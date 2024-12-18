
using ErrorOr;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using FestCover.Application.Common.Contracts;
using FestCover.Application.Common.Models.Auth;
using FestCover.Infrastructure.Common.Persistence.Identity;
using FestCover.Domain.Common;
using FestCover.Infrastructure.Common.Persistence;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using SixLabors.ImageSharp.Metadata.Profiles.Iptc;

namespace AfterLife.Infrastructure.Persistence.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly ITokenClaimService _tokenService;
        private readonly IStorageService _storageService;
        private readonly FestCoverDbContext _context;
        private readonly IContentValidator _contenteService;
        private readonly SignInManager<User> _signInManager;
        private readonly IPaymentService _paymentService;
        public IdentityService(
            UserManager<User> userManager,
            RoleManager<Role> roleManager,
            SignInManager<User> signInManager,
            ITokenClaimService tokenService,
            IStorageService storageService,
            FestCoverDbContext context,
            IContentValidator contenteService,
            IPaymentService paymentService
            )
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _tokenService = tokenService;
            _storageService = storageService;
            _context = context;
            _contenteService = contenteService;
            _signInManager = signInManager;
            _paymentService = paymentService;

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
            user.LastLoginTime = DateTime.Now;
            if (String.IsNullOrEmpty(user.CustomerId))
            {
                var customerId = await _paymentService.CreateCustomer(user.UserName, user.Email);
                user.CustomerId = customerId;
            }
            await _userManager.UpdateAsync(user);

            //var spaceUsed = await _storageService.GetFolderSizeAsync($"{user.Id}/Albums/");
            //var totalSize = (spaceUsed. Value/(1024 * 1024));
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
            var hasPassword = await _userManager.HasPasswordAsync(user);
            var role = await _userManager.GetRolesAsync(user);
            var roleName = role.FirstOrDefault();
            var currentUser = new AuthUserModel(
                Id: user.Id,
                Username: user.UserName,
                Email: user.Email,
                PictureUrl: user.PictureUrl,
                SubscriptionType:user.SubscriptionType.ToString(),
                ExternalAuth:!hasPassword
           );
            return currentUser;

        }
        public async Task<ErrorOr<TokenResultModel>> RefreshToken(TokenResultModel currentToken)
        {

            var principal = _tokenService.GetPrincipalFromExpiredToken(currentToken.AccessToken);
            if (principal.IsError)
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

        public async Task<ErrorOr<Success>> UpdateUser(UpdateUserAuthModel userInfo)
        {
            if (userInfo == null || string.IsNullOrWhiteSpace(userInfo.Username) || string.IsNullOrWhiteSpace(userInfo.Email))
                return Error.Validation(description: "Invalid user information.");

            await using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var user = await _userManager.FindByIdAsync(userInfo.UserId.ToString());
                if (user == null)
                    return Error.Conflict(description: "User not found");

                var isUserNameInUse = await _userManager.Users.AnyAsync(u => u.UserName.ToLower() == userInfo.Username.ToLower() && u.Id != userInfo.UserId);
                if (isUserNameInUse)
                    return Error.Conflict(description: "Username not available");

                var isEmailInUse = await _userManager.Users.AnyAsync(u => u.Email.ToLower() == userInfo.Email.ToLower() && u.Id != userInfo.UserId);
                if (isEmailInUse)
                    return Error.Conflict(description: "Email not available");

                if (!string.IsNullOrWhiteSpace(userInfo.Password))
                {
                    if (string.IsNullOrWhiteSpace(userInfo.CurrentPassword))
                        return Error.Conflict(description: "Current password is required to set a new password.");

                    if (!await _userManager.CheckPasswordAsync(user, userInfo.CurrentPassword))
                        return Error.Conflict(description: "Invalid password.");

                    if (userInfo.Password != userInfo.Password2)
                        return Error.Conflict(description: "Passwords don't match.");

                    var passwordResult = await _userManager.ChangePasswordAsync(user, userInfo.CurrentPassword, userInfo.Password);
                    if (!passwordResult.Succeeded)
                        return Error.Conflict(description: string.Join(", ", passwordResult.Errors.Select(e => e.Description)));
                }

                if (userInfo.Picture != null)
                {
                    var isImageValid = await _contenteService.IsValidContent(userInfo.Picture);
                    if (!isImageValid)
                    {
                        return Error.Conflict(description: "Not valid profile picture");
                    }
                    if (user.PictureUrl != null)
                    {
                        var deletePictureResult = await _storageService.RemoveFile(user.Id.ToString() + "/" + user.PictureUrl.Substring(user.PictureUrl.LastIndexOf("Profile")));

                        if (deletePictureResult.IsError)
                        {
                            return Error.Conflict(description: "An error occurred while updating the user picture");
                        }

                    }
                    var fileResult = await _storageService.AddFile(userInfo.ContentType, $"{user.Id}/Profile/{Guid.NewGuid().ToString() + userInfo.Extension}", userInfo.Picture);
                    if (fileResult.IsError)
                    {
                        await _context.Database.RollbackTransactionAsync();
                        return Error.Conflict(description: "An error occurred while uploading the profile picture.");
                    }
                    user.PictureUrl = fileResult.Value;
                }

                user.UserName = userInfo.Username;
                user.NormalizedUserName = userInfo.Username.ToUpperInvariant();
                user.Email = userInfo.Email;
                user.NormalizedEmail = userInfo.Email.ToUpperInvariant();

                var updateResult = await _userManager.UpdateAsync(user);
                if (!updateResult.Succeeded)
                {
                    await _context.Database.RollbackTransactionAsync();
                    return Error.Conflict(description: "User update failed.");
                }

                await _context.Database.CommitTransactionAsync();
                return Result.Success;
            }
            catch
            {
                await _context.Database.RollbackTransactionAsync();
                throw;
            }
        }

        public async Task<ErrorOr<TokenResultModel>> ExternalLoginAsycn()
        {
            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info is null)
            {
                return Error.Failure(description: "Sign in failed");
            }
            var signinResult = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, false);
            var email = info.Principal.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindByEmailAsync(email);
            if (signinResult.Succeeded)
            {
                if(String.IsNullOrEmpty(user.CustomerId))
                {
                    var customerId = await _paymentService.CreateCustomer(user.UserName, user.Email);
                    user.CustomerId = customerId;
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
            if (email is not null)
            {
                var role = await _roleManager.FindByNameAsync("User");
                if (user is null)
                {
                    user = new User
                    {
                        UserName = info.Principal.FindFirstValue(ClaimTypes.Email),
                        Email = info.Principal.FindFirstValue(ClaimTypes.Email),
                        EmailConfirmed=true,
                    };

                   var result=  await _userManager.CreateAsync(user);
                    if (result.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(user, role.Name);
                    }
                    else
                    {
                        return Error.Failure(description: "An error occurred while signing in");
                    }
                }
                if (String.IsNullOrEmpty(user.CustomerId))
                {
                    var customerId = await _paymentService.CreateCustomer(user.UserName, user.Email);
                    user.CustomerId = customerId;
                    await _userManager.UpdateAsync(user);
                }

                await _userManager.AddLoginAsync(user, info);
                await _signInManager.SignInAsync(user, false);
                var tokenResult = _tokenService.GetToken(user.Email, user.Id.ToString(), role.Name);
                return tokenResult;
            }
            return Error.Failure(description: "An error occurred while signing in");
        }

        public async Task<ErrorOr<string>> ChangeUserSubscription( UpdateUserSubscriptionModel updateUserSubscription)
        {
            var user = await _userManager.FindByIdAsync(updateUserSubscription.UserId.ToString());
            if (user == null)
                return Error.Conflict(description: "User not found");
    
            var subscriptionToAdd = (UserSubscriptionType)Enum.Parse(typeof(UserSubscriptionType), updateUserSubscription.SubscriptionType, true);

            var productId = "";
            ErrorOr<string> result="";

            switch (user.SubscriptionType)
            {
                case UserSubscriptionType.None:
                    if(subscriptionToAdd==UserSubscriptionType.Basic)
                    {
                        productId = await _paymentService.SearchProduct("Basic");
                    }
                    else if (subscriptionToAdd == UserSubscriptionType.Premium)
                    {
                        productId = await _paymentService.SearchProduct("Premium");
                    }
                    result =  await _paymentService.AddSubscription(user.CustomerId, productId);
                    break;

                case UserSubscriptionType.Basic:
                    if (subscriptionToAdd == UserSubscriptionType.Premium)
                    {
                        productId = await _paymentService.SearchProduct("Premium");
                    }

                    result = await _paymentService.AddSubscription(user.CustomerId, productId);
                    break;


            }
            return result;
        }

        public async Task<ErrorOr<Success>> UpdateUserSubscription(string customerId,string subscriptionId,DateTime date)
        {
            var user= await _userManager.Users.Where(u=>u.CustomerId== customerId).FirstOrDefaultAsync();
            if (user == null)
                return Error.Conflict(description: "User not found");

            var productId= await _paymentService.GetProductIdBySubscriptionId(subscriptionId);
            var product= await _paymentService.GetProductById(productId.Value);
            user.LastSubscriptionPayment = date;
            switch(user.SubscriptionType) {

                case UserSubscriptionType.None:
                    if (product.Value == "Basic")
                    {
                        user.SubscriptionType = UserSubscriptionType.Basic;

                    }
                    break;

                case UserSubscriptionType.Basic:
                    if (product.Value == "Premium")
                    {
                        user.SubscriptionType = UserSubscriptionType.Premium;

                    }
                    break;
            }
            await _userManager.UpdateAsync(user);
            return Result.Success;
        }
    }
}
