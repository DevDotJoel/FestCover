using ErrorOr;
using FestCover.Application.Common.Contracts;
using FestCover.Application.Common.Persistence;
using FestCover.Domain.AlbumContents.ValueObjects;
using FestCover.Domain.Albums.ValueObjects;
using FestCover.Domain.Common;
using FestCover.Domain.Common.DomainErrors;
using MediatR;


namespace FestCover.Application.AlbumContents.Commands.ApproveAlbumContent
{
    public class ApproveAlbumContentCommandHandler : IRequestHandler<ApproveAlbumContentCommand, ErrorOr<Success>>
    {
        private readonly IUserService _userService;
        private readonly IAlbumContentRepository _albumContentRepository;
        public ApproveAlbumContentCommandHandler(IAlbumContentRepository albumContentRepository, IUserService userService)
        {
            _albumContentRepository = albumContentRepository;
            _userService = userService;
        }
        public async Task<ErrorOr<Success>> Handle(ApproveAlbumContentCommand request, CancellationToken cancellationToken)
        {

            var albumContentId = AlbumContentId.Create(request.AlbumContentId);
            if (!await _albumContentRepository.ExistsAsync(albumContentId))
            {
                return Errors.AlbumContent.NotFound;
            }
            var albumContent= await _albumContentRepository.GetByIdAsync(albumContentId,cancellationToken);
            albumContent.SetPendent(false);
            await _albumContentRepository.UpdateAsync(albumContent,cancellationToken);
            return Result.Success;
        }
    }
}
