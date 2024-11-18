using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestCover.Contracts.Authentication
{
    public record UpdateUserRequest
    (
    string Username,
    string Email,
    string? CurrentPassword = null,
    string? Password = null,
    string? Password2 = null,
    IFormFile? File=null
    );
}
