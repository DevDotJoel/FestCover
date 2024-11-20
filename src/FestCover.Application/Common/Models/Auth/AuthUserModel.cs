using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestCover.Application.Common.Models.Auth
{
    public record AuthUserModel
    (
       Guid Id,
       string Username,
       string Email,
       bool ExternalAuth,
       string? PictureUrl=null
    );


}
