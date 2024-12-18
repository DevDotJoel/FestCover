﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestCover.Infrastructure.Common.Persistence.Identity
{
    public class User : IdentityUser<Guid>
    {
        public string? RefreshToken { get; set; }
        public string? PictureUrl { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
        public DateTime? LastLoginTime { get; set; }
        public string? CustomerId { get; set; }
        public UserSubscriptionType SubscriptionType { get; set; }
        public DateTime? LastSubscriptionPayment { get; set; }
    }

    public enum UserSubscriptionType
    {
        None,
        Basic,
        Premium
    }
}
