using ErrorOr;
using FestCover.Domain.Common;
using FestCover.Domain.Common.DomainErrors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestCover.Domain.Albums.ValueObjects
{
    public class AlbumId : EntityId<Guid>
    {
        private AlbumId(Guid id) : base(id)
        {

        }

        public static AlbumId Create(Guid value)
        {
            return new AlbumId(value);

        }
        public static AlbumId CreateUnique()
        {
            return new AlbumId(Guid.NewGuid());
        }
        public static ErrorOr<AlbumId> Create(string value)
        {
            if (!Guid.TryParse(value, out var guid))
            {
                return Errors.Album.InvalidAlbumId;
            }

            return new AlbumId(guid);
        }
        private AlbumId()
        {

        }
    }
}
