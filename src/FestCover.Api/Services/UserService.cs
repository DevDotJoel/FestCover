

using FestCover.Application.Common.Contracts;

namespace FestCover.Api.Services
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContext;
        public UserService(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }
        public string GetCurrentUserId()
        {
            var userId = _httpContext.HttpContext?.User.FindFirst("UserId")?.Value;
            return userId;
        }
    }
}
