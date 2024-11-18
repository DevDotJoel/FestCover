using ErrorOr;
using FestCover.Application.Common.Models.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestCover.Application.Common.Contracts
{
    public interface IIdentityService
    {
        Task<ErrorOr<TokenResultModel>> LoginJwtAsync(string email, string password);
        Task<ErrorOr<AuthUserModel>> GetUser(string userId);
        Task<ErrorOr<Success>> Register(string username, string email, string password, string password2);
        Task<ErrorOr<TokenResultModel>> RefreshToken(TokenResultModel currentToken);
        Task<ErrorOr<Success>> Logout(string userId);

        Task<ErrorOr<Success>> UpdateUser(UpdateUserAuthModel userInfo);
    }
}
