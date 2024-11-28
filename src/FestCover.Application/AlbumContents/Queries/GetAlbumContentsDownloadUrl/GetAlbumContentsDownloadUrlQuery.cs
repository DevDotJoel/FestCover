using ErrorOr;
using FestCover.Application.Common.Models.Files;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestCover.Application.AlbumContents.Queries.GetAlbumContentsDownloadUrl
{
    public record GetAlbumContentsDownloadUrlQuery(Guid AlbumId):IRequest<ErrorOr<FileDownloadModel>>;
}
