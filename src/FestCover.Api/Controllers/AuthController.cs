using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FestCover.Application.Common.Contracts;
using FestCover.Application.Common.Models.Auth;
using FestCover.Contracts.Authentication;

namespace FestCover.Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ApiController
    {
        private readonly IIdentityService _identityService;
        private readonly IUserService _userService;
        public AuthController(IIdentityService identityService, IUserService userService)
        {
            _identityService = identityService;
            _userService = userService;
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserRequest loginRequest)
        {

            var result = await _identityService.LoginJwtAsync(loginRequest.Email, loginRequest.Password);
            SetTokensInsideCookie(result.Value.RefreshToken, HttpContext);
            return result.Match(data => Ok(new { data.AccessToken }), Problem);
        }

        [HttpGet("logOut")]
        public async Task<IActionResult> Logout()
        {
            var result = await _identityService.Logout(_userService.GetCurrentUserId());

            return result.Match(_ => NoContent(), Problem);



        }
        [AllowAnonymous]
        [HttpPost("refresh")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest refreshTokenRequest)
        {
            HttpContext.Request.Cookies.TryGetValue("refreshToken", out var refreshToken);
            if (refreshTokenRequest.AccessToken != null && refreshToken != null)
            {
                var tokenResult = new TokenResultModel(refreshTokenRequest.AccessToken, refreshToken);
                var result = await _identityService.RefreshToken(tokenResult);
                if (result.IsError)
                {
                  return   result.Match(_ => Problem(), Problem);
                }
                SetTokensInsideCookie(result.Value.RefreshToken, HttpContext);
                return result.Match(data => Ok(new { data.AccessToken }), Problem);
            }
            else
            {
                return Problem();
            }

        }

        private void SetTokensInsideCookie(string refreshToken, HttpContext context)
        {

            context.Response.Cookies.Append("refreshToken", refreshToken, new CookieOptions
            {
                Expires = DateTime.Now.AddDays(7),
                HttpOnly = true,
                IsEssential = true,
                Secure = true,
                SameSite = SameSiteMode.None,
            });

        }
    }
}
