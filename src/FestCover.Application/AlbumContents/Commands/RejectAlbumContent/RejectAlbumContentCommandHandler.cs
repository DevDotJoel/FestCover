using ErrorOr;
using FestCover.Application.Common.Contracts;
using FestCover.Application.Common.Persistence;
using FestCover.Domain.AlbumContents.ValueObjects;
using MediatR;
using FestCover.Domain.Common.DomainErrors;
namespace FestCover.Application.AlbumContents.Commands.RejectAlbumContent
{
    public class RejectAlbumContentCommandHandler : IRequestHandler<RejectAlbumContentCommand, ErrorOr<Success>>
    {
        private readonly IUserService _userService;
        private readonly IAlbumContentRepository _albumContentRepository;
        public RejectAlbumContentCommandHandler(IAlbumContentRepository albumContentRepository, IUserService userService)
        {
            _albumContentRepository = albumContentRepository;
            _userService = userService;
        }
        public async Task<ErrorOr<Success>> Handle(RejectAlbumContentCommand request, CancellationToken cancellationToken)
        {
            var albumContentId = AlbumContentId.Create(request.AlbumContentId);
            if (!await _albumContentRepository.ExistsAsync(albumContentId))
            {
                return Errors.AlbumContent.NotFound;
            }
            var albumContent = await _albumContentRepository.GetByIdAsync(albumContentId, cancellationToken);
            albumContent.SetPendent(false);
            await _albumContentRepository.RemoveAsync(albumContent,cancellationToken);
            return Result.Success;
        }
    }
}
