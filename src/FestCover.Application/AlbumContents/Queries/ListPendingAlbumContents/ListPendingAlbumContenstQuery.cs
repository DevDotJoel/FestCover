using ErrorOr;
using FestCover.Application.Common.Models.Albums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestCover.Application.AlbumContents.Queries.ListPendingAlbumContents
{
    public record ListPendingAlbumContenstQuery() : IRequest<ErrorOr<List<AlbumContentPendingModel>>>;
}
