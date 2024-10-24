using FestCover.Domain.AlbumContents.ValueObjects;
using FestCover.Domain.Albums.ValueObjects;
using FestCover.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestCover.Domain.AlbumContents.Events
{
    public record AlbumContentCreated(AlbumId AlbumId,AlbumContentId AlbumContentId) : IDomainEvent;
}
