
using ErrorOr;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using FestCover.Application.Common.Contracts;
using FestCover.Application.Common.Models.Auth;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace FestCover.Infrastructure.Persistence.Identity
{
    public class TokenClaimService : ITokenClaimService
    {
        private readonly IConfiguration _configuration;
        private readonly IConfigurationSection _jwtSettings;
        public TokenClaimService(IConfiguration configuration)
        {
            _configuration = configuration;
            _jwtSettings = _configuration.GetSection("JwtSettings");
        }
        public TokenResultModel GetToken(string email, string userId, string role)
        {


            var claims = new[]
              {
                new Claim("UserId",userId),
                new Claim(JwtRegisteredClaimNames.Email,email)                ,
                new Claim("Role",role)
            };
            var credentials = GetSigningCredentials();
            var tokenExpireMinutes = Convert.ToDouble(_jwtSettings.GetSection("expiryIn").Value);
            var tokenExpireIn = DateTime.Now.AddMinutes(tokenExpireMinutes);
            var tokenOptions = GenerateTokenOptions(credentials, claims, tokenExpireIn);
            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);


            var refreshToken = GenerateRefreshToken();
            return new TokenResultModel(token, refreshToken);
        }
        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, Claim[] claims, DateTime expireIn)
        {
            var tokenOptions = new JwtSecurityToken(
                issuer: _jwtSettings.GetSection("validIssuer").Value,
                audience: _jwtSettings.GetSection("validAudience").Value,
                claims: claims,
                expires: expireIn,
                signingCredentials: signingCredentials);
            return tokenOptions;

        }

        public ErrorOr<ClaimsPrincipal> GetPrincipalFromExpiredToken(string token)
        {
            try
            {
                var tokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = _jwtSettings.GetSection("validIssuer").Value,
                    ValidAudience = _jwtSettings.GetSection("validAudience").Value,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.GetSection("securityKey").Value))
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                SecurityToken securityToken;
                var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
                var jwtSecurityToken = securityToken as JwtSecurityToken;
                if (jwtSecurityToken is null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                {
                    return Error.Conflict(description: "Invalid Token");
                }
                return principal;
            }
            catch (Exception ex)
            {

                return Error.Failure(description: ex.Message);
            }


        }
        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }
        private SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(_jwtSettings.GetSection("securityKey").Value);
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }
    }
}
