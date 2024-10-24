using FestCover.Application.Common.Persistence;
using FestCover.Domain.AlbumContents.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestCover.Application.Albums.Events
{
    public class AlbumContentCreatedEventHandler : INotificationHandler<AlbumContentCreated>
    {
        private readonly IAlbumRepository _albumRepository;
        public AlbumContentCreatedEventHandler(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;

        }
        public async Task Handle(AlbumContentCreated notification, CancellationToken cancellationToken)
        {
            var album = await _albumRepository.GetByIdAsync(notification.AlbumId, cancellationToken);

            if (album is null)
            {
                throw new InvalidOperationException($"Content has invalid Album id (AlbumContent id: {notification.AlbumContentId.Value}, album id: {notification.AlbumId.Value}).");
            }

            album.AddAlbumContentId(notification.AlbumContentId);

            await _albumRepository.UpdateAsync(album, cancellationToken);
        }
    }
}
