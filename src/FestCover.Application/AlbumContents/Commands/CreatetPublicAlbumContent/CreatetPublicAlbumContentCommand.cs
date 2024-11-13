using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestCover.Application.AlbumContents.Commands.CreatetPublicAlbumContent
{
    public record CreatetPublicAlbumContentCommand
      (
        string Name,
        string PhoneNumber,
        string AlbumId,
       List<AlbumPublicContentImageCommand> AlbumPublicContentImages
    ) : IRequest<ErrorOr<Success>>;


    public record AlbumPublicContentImageCommand(
    byte[] File,
    string FileName,
    string Extension,
    string ContentType
    );
}
