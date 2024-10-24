using FestCover.Domain.AlbumContents;
using FestCover.Domain.AlbumContents.ValueObjects;
using FestCover.Domain.Albums.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestCover.Application.Common.Persistence
{
    public interface IAlbumContentRepository:IBaseRepository<AlbumContentId,AlbumContent>
    {
        Task<List<AlbumContent>> GetAlbumContentsByAlbumId(AlbumId albumId);
    }
}
