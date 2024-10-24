using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestCover.Domain.Common
{
    public class UserId : EntityId<Guid>
    {
        private UserId(Guid id) : base(id)
        {

        }

        public static UserId Create(Guid value)
        {
            return new UserId(value);

        }
        public static UserId CreateUnique()
        {
            return new UserId(Guid.NewGuid());
        }

        private UserId()
        {

        }
    }
}
