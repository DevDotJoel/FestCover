using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestCover.Domain.Common
{
    public interface ISoftDelete
    {
        public bool IsDeleted { get; }
        void SetIsDeleted(bool isDeleted);
    }
}
