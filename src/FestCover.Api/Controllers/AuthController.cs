using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FestCover.Application.Common.Contracts;
using FestCover.Application.Common.Models.Auth;
using FestCover.Contracts.Authentication;
using FestCover.Infrastructure.Common.Persistence.Identity;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using ErrorOr;

namespace FestCover.Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ApiController
    {
        private readonly IIdentityService _identityService;
        private readonly IUserService _userService;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _config;
        private readonly IWebHostEnvironment _env;
        public AuthController(IIdentityService identityService, IUserService userService, SignInManager<User> signInManager, IConfiguration configuration, IWebHostEnvironment env)
        {
            _identityService = identityService;
            _userService = userService;
            _signInManager = signInManager;
            _config = configuration;
            _env = env;
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserRequest loginRequest)
        {

            var result = await _identityService.LoginJwtAsync(loginRequest.Email, loginRequest.Password);
            if(!result.IsError)
            {
                SetTokensInsideCookie(result.Value.RefreshToken, HttpContext);

            }

            return result.Match(
                authResult => Ok(new { authResult.AccessToken }),
                Problem);


        }
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Registe(RegisterUserRequest registerUserRequest)
        {

            var result = await _identityService.Register(registerUserRequest.Username,registerUserRequest.Email,registerUserRequest.Password,registerUserRequest.Password2);
          
            return result.Match (_=>NoContent(), Problem);


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
        [HttpPost("external-login")]
        [AllowAnonymous]
        public async Task<IActionResult> ExternalLogin(string provider, string returnUrl)
        {
            var redirectUrl = $"{_config["WebApp:BackendPublicUrl"]}/api/auth/external-auth-callback?returnUrl={returnUrl}";
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            properties.AllowRefresh = true;
            return Challenge(properties, provider);
        }

        [AllowAnonymous]
        [HttpGet("external-auth-callback")]
        public async Task<IActionResult> ExternalLoginCallback()
        {
            var result = await _identityService.ExternalLoginAsycn();

            if (!result.IsError)
            {
                var isProduction = _env.EnvironmentName == "Production";
                var options = new CookieOptions()
                {
                    //Needed so that domain.com can access  the cookie set by api.domain.com
                    Expires = DateTime.UtcNow.AddMinutes(5),
                    Domain=isProduction? $"{_config["WebApp:FrontendHost"]}":null
                };
                HttpContext.Response.Cookies.Append("token", result.Value.AccessToken, options);
            }

            return Redirect($"{_config["WebApp:FrontendPublicUrl"]}/auth/external-login-callback");

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
