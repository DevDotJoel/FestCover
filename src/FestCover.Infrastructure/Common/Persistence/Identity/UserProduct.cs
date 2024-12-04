using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestCover.Infrastructure.Common.Persistence.Identity
{
    public class UserProduct
    {
        public Guid Id { get; set; }
        public string ProductId { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
        public Product Product { get; set; }
    }
}
