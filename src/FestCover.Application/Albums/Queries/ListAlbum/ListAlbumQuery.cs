using ErrorOr;
using MediatR;
using FestCover.Application.Common.Models.Albums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestCover.Application.Albums.Queries.ListAlbum
{
    public record ListAlbumQuery():IRequest<ErrorOr<List<AlbumModel>>>;
}
