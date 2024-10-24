using FestCover.Domain.AlbumContents.ValueObjects;
using FestCover.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestCover.Domain.Albums.Events
{
    public record AlbumRemoved(List<AlbumContentId> AlbumContentIds):IDomainEvent;
}
