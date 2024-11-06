using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestCover.Application.AlbumContents.Commands.CreateAlbumContent
{
    public record CreateAlbumContentCommand
    (
        string AlbumId,
        List<AlbumContentImageCommand> AlbumContentImages
    ) : IRequest<ErrorOr<Success>>;
    public record AlbumContentImageCommand(
    byte[] File,
    string FileName,
    string Extension,
    string ContentType
    );
}
