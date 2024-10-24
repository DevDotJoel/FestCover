using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestCover.Application.Albums.Commands.DeleteAlbum
{
    public record DeleteAlbumCommand(string albumId):IRequest<ErrorOr<Success>>;
}
