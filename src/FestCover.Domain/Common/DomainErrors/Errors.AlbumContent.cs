using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestCover.Domain.Common.DomainErrors
{
    public static partial class Errors
    {
        public static class AlbumContent
        {
            public static Error InvalidAlbumContentId => Error.Validation(
                code: "AlbumContent.InvalidId",
                description: "AlbumContent ID is invalid");

            public static Error NotFound => Error.NotFound(
                code: "AlbumContent.NotFound",
                description: "AlbumContent with given ID does not exist");
        }
    }
}
