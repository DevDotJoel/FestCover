using ErrorOr;
using MediatR;
using FestCover.Application.Common.Models.Albums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestCover.Application.Albums.Commands.CreateAlbum
{
    public record CreateAlbumCommand
    (
     string Name,
     string Description,
     AlbumImageCommand AlbumImage
    ):IRequest<ErrorOr<AlbumModel>>;

    public record AlbumImageCommand(
     byte[] File,
     string FileName,
     string Extension,
     string ContentType
     );
}
