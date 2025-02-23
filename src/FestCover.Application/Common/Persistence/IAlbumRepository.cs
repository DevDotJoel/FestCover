﻿using FestCover.Domain.AlbumContents.ValueObjects;
using FestCover.Domain.Albums;
using FestCover.Domain.Albums.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestCover.Application.Common.Persistence
{
    public interface IAlbumRepository : IBaseRepository<AlbumId, Album>
    {
        Task<Album> GetAlbumByKey(string key,CancellationToken cancellationToken);
        Task<List<Album>> GetAlbumsByAlbumContentIds(List<AlbumContentId> AlbumContentIds, CancellationToken cancellationToken);
    }
}
