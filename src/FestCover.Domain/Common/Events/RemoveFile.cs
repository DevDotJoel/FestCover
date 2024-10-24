
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestCover.Domain.Common.Events
{
    public record RemoveFile(string Path) : IDomainEvent;
}
