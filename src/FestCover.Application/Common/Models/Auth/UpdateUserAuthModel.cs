using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestCover.Application.Common.Models.Auth
{
    public record UpdateUserAuthModel
    (
    Guid UserId,
    string Username,
    string Email,
    string? CurrentPassword=null,
    string? Password=null,
    string? Password2 = null,
    byte[]? Picture=null,
    string? ContentType=null,
    string? Extension = null
     );
}
