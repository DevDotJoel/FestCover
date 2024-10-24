using ErrorOr;
using FestCover.Application.Common.Models.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FestCover.Application.Common.Contracts
{
    public interface ITokenClaimService
    {
        TokenResultModel GetToken(string email, string userId, string role);
        ErrorOr<ClaimsPrincipal> GetPrincipalFromExpiredToken(string token);
    }
}
