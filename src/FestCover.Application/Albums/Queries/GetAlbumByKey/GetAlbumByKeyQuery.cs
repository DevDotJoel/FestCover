using ErrorOr;
using FestCover.Application.Common.Models.Albums;
using FestCover.Domain.AlbumContents;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestCover.Application.Albums.Queries.GetAlbumByKey
{
    public record GetAlbumByKeyQuery(string Key) : IRequest<ErrorOr<AlbumDetailModel>>;

}
