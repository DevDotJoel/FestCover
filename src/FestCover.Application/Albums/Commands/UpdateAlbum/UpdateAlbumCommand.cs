using ErrorOr;
using MediatR;
using FestCover.Application.Common.Models.Albums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestCover.Application.Albums.Commands.UpdateAlbum
{
    public record UpdateAlbumCommand
    (
     string AlbumId,
     string Name,
     string Description,
     bool IsPublic,
     bool AllowPublicUpload,
     bool ReviewUploadedContent,
     UpdateAlbumImageCommand? AlbumImage = null
    ) : IRequest<ErrorOr<AlbumModel>>;

    public record UpdateAlbumImageCommand(
     byte[] File,
     string FileName,
     string Extension,
     string ContentType
     );
}
