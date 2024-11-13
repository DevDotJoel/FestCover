using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestCover.Application.AlbumContents.Commands.ApproveAlbumContent
{
    public record ApproveAlbumContentCommand
    ( 
     Guid AlbumContentId
     ):IRequest<ErrorOr<Success>>;
}
