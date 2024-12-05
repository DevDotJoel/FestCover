

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FestCover.Application.Common.Contracts;
using Microsoft.AspNetCore.Authorization;
using FestCover.Contracts.Authentication;
using MapsterMapper;
using FestCover.Application.Common.Models.Auth;
using FestCover.Contracts.Users;

namespace FestCover.Api.Controllers
{

    [Route("api/users")]
    [ApiController]
    public class UsersController : ApiController
    {
        private readonly IIdentityService _identityService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UsersController(IUserService userService, IIdentityService identityService,IMapper mapper)
        {
            _userService = userService;
            _identityService = identityService;
            _mapper = mapper;

        }
        [HttpGet("Me")]
        public async Task<IActionResult> GetMe()
        {
            var userId = _userService.GetCurrentUserId();
            var result= await _identityService.GetUser(userId);
            return result.Match(Ok, Problem);

        }
        [HttpPut("Profile")]
        public async Task<IActionResult> UpdateUser([FromForm] UpdateUserRequest request)
        {
            var userId = _userService.GetCurrentUserId();
            var result = await _identityService.UpdateUser(_mapper.Map<UpdateUserAuthModel>((request,userId)));
            return result.Match(_ => NoContent(), Problem);

        }
        [HttpPut("Subscription")]
        public async Task<IActionResult> ChangeUserSubscription(UpdateUserSubscriptionRequest request)
        {
            var userId = _userService.GetCurrentUserId();
            var result = await _identityService.ChangeUserSubscription(new UpdateUserSubscriptionModel(Guid.Parse(userId),request.SubscriptionType));
            return result.Match(Ok, Problem);

        }
    }
}
