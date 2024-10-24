using ErrorOr;
using FestCover.Domain.Albums.ValueObjects;
using FestCover.Domain.Common;
using FestCover.Domain.Common.DomainErrors;

namespace FestCover.Domain.AlbumContents.ValueObjects
{
    public class AlbumContentId : EntityId<Guid>
    {
        private AlbumContentId(Guid id) : base(id)
        {

        }

        public static AlbumContentId Create(Guid value)
        {
            return new AlbumContentId(value);

        }
        public static AlbumContentId CreateUnique()
        {
            return new AlbumContentId(Guid.NewGuid());
        }
        public static ErrorOr<AlbumContentId> Create(string value)
        {
            if (!Guid.TryParse(value, out var guid))
            {
                return Errors.AlbumContent.InvalidAlbumContentId;
            }

            return new AlbumContentId(guid);
        }
        private AlbumContentId()
        {

        }
    }
}
