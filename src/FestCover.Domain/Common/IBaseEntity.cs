using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestCover.Domain.Common
{
    public interface IBaseEntity
    {
        public DateTime CreatedDate { get; }
        public DateTime LastModifiedDate { get; }
        public void SetCreatedDate(DateTime createdDate);
        public void SetLastModifiedDate(DateTime lastModifiedDate);

    }
}
