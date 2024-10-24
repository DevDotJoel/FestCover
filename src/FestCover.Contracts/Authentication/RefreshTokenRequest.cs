using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestCover.Contracts.Authentication
{
    public class RefreshTokenRequest
    {
        public string AccessToken { get; set; }
    }
}
