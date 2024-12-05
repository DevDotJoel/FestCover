using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestCover.Application.Common.Models.Auth
{
   public record UpdateUserSubscriptionModel
   ( Guid UserId,
     int SubscriptionType
    );
}
