

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FestCover.Application.Common.Contracts;
using Microsoft.AspNetCore.Authorization;

namespace FestCover.Api.Controllers
{

    [Route("api/users")]
    [ApiController]
    public class UsersController : ApiController
    {
        private readonly IIdentityService _identityService;
        private readonly IUserService _userService;
        public UsersController(IUserService userService, IIdentityService identityService)
        {
            _userService = userService;
            _identityService = identityService;

        }
        [HttpGet("Me")]
        public async Task<IActionResult> GetMe()
        {
            var userId = _userService.GetCurrentUserId();
            var result= await _identityService.GetUser(userId);
            return result.Match(Ok, Problem);


        }
    }
}
