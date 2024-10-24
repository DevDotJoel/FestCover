using ErrorOr;
using FestCover.Application.Common.Persistence;
using FestCover.Domain.Albums.ValueObjects;
using MediatR;
using FestCover.Domain.Common.DomainErrors;
namespace FestCover.Application.Albums.Commands.DeleteAlbum
{
    public class DeleteAlbumCommandHandler : IRequestHandler<DeleteAlbumCommand, ErrorOr<Success>>
    {
        private readonly IAlbumRepository _albumRepository;
        public DeleteAlbumCommandHandler(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
            
        }
        public async Task<ErrorOr<Success>> Handle(DeleteAlbumCommand request, CancellationToken cancellationToken)
        {
            var deleteAlbumIdResult = AlbumId.Create(request.albumId);
            if (deleteAlbumIdResult.IsError)
            {
                return deleteAlbumIdResult.Errors;
            }
            if (!await _albumRepository.ExistsAsync(deleteAlbumIdResult.Value))
            {
                return Errors.Album.NotFound;
            }
            var album = await _albumRepository.GetByIdAsync(deleteAlbumIdResult.Value, cancellationToken);
            album.Remove();
            await _albumRepository.RemoveAsync(album,cancellationToken);
            return Result.Success;
        }
    }
}
