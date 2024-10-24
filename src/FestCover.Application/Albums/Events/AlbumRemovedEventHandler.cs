using FestCover.Application.Common.Persistence;
using FestCover.Domain.Albums.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestCover.Application.Albums.Events
{
    public class AlbumRemovedEventHandler : INotificationHandler<AlbumRemoved>
    {
        private readonly IAlbumContentRepository _albumContentRepository;
        public AlbumRemovedEventHandler(IAlbumContentRepository albumContentRepository)
        {
            _albumContentRepository = albumContentRepository;
        }
        public async Task Handle(AlbumRemoved notification, CancellationToken cancellationToken)
        {
          var albumContents= await _albumContentRepository.GetByIdsAsync(notification.AlbumContentIds, cancellationToken);
            if (albumContents.Count > 0)
            {
                await _albumContentRepository.RemoveRangeAsync(albumContents, cancellationToken);
            }
       
        }
    }
}
