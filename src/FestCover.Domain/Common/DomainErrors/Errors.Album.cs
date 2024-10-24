using ErrorOr;

namespace FestCover.Domain.Common.DomainErrors;
public static partial class Errors
{
    public static class Album
    {
        public static Error InvalidAlbumId => Error.Validation(
            code: "Album.InvalidId",
            description: "Album ID is invalid");

        public static Error NotFound => Error.NotFound(
            code: "Album.NotFound",
            description: "Album with given ID does not exist");
    }
}
