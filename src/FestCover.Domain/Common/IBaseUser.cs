using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestCover.Domain.Common
{
    public interface IBaseUser
    {
        public UserId UserId { get; }
        public void SetUserId(UserId userId);
    }
}
