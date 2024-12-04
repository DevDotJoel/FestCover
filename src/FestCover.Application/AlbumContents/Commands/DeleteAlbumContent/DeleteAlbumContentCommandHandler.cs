using ErrorOr;
using FestCover.Application.Common.Persistence;
using FestCover.Domain.AlbumContents.ValueObjects;

using MediatR;
using FestCover.Domain.Common.DomainErrors;
namespace FestCover.Application.AlbumContents.Commands.DeleteAlbumContent
{
    public class DeleteAlbumContentCommandHandler : IRequestHandler<DeleteAlbumContentCommand, ErrorOr<Success>>
    {
        private readonly IAlbumContentRepository _albumContentRepository;
        private readonly IAlbumRepository _albumRepository;
        public DeleteAlbumContentCommandHandler(IAlbumContentRepository albumContentRepository,IAlbumRepository albumRepository)
        {
            _albumContentRepository = albumContentRepository;
            _albumRepository = albumRepository;
        }
        public async Task<ErrorOr<Success>> Handle(DeleteAlbumContentCommand request, CancellationToken cancellationToken)
        {
            var deleteAlbumContentIdResult = AlbumContentId.Create(request.AlbumContentId);
            if (deleteAlbumContentIdResult.IsError)
            {
                return deleteAlbumContentIdResult.Errors;
            }
            if (!await _albumContentRepository.ExistsAsync(deleteAlbumContentIdResult.Value))
            {
                return Errors.Album.NotFound;
            }

            var albumContentToDelete= await _albumContentRepository.GetByIdAsync(deleteAlbumContentIdResult.Value,cancellationToken);
            var album = await _albumRepository.GetByIdAsync(albumContentToDelete.AlbumId,cancellationToken);
            album.RemoveAlbumContent(albumContentToDelete.Id);
            await _albumContentRepository.RemoveAsync(albumContentToDelete,cancellationToken);
            await _albumRepository.UpdateAsync(album,cancellationToken);
            return Result.Success;
        }
    }
}
