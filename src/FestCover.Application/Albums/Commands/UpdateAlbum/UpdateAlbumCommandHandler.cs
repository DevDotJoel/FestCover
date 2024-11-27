using ErrorOr;
using MapsterMapper;
using MediatR;
using FestCover.Application.Common.Contracts;
using FestCover.Application.Common.Helpers;
using FestCover.Application.Common.Models.Albums;
using FestCover.Application.Common.Persistence;
using FestCover.Domain.Albums.ValueObjects;
using FestCover.Domain.Common.DomainErrors;
using FestCover.Domain.Common;


namespace FestCover.Application.Albums.Commands.UpdateAlbum
{
    public class UpdateAlbumCommandHandler : IRequestHandler<UpdateAlbumCommand, ErrorOr<AlbumModel>>
    {
        private readonly IAlbumRepository _albumRepository;
        private readonly IStorageService _storageService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IContentValidator _contentValidator;
        public UpdateAlbumCommandHandler(
             IAlbumRepository albumRepository,
            IStorageService storageService,
            IUserService userService,
            IMapper mapper,
            IContentValidator contentValidator
            )
        {
            _albumRepository = albumRepository;
            _albumRepository = albumRepository;
            _storageService = storageService;
            _userService = userService;
            _mapper = mapper;
            _contentValidator = contentValidator;
        }
        public async Task<ErrorOr<AlbumModel>> Handle(UpdateAlbumCommand request, CancellationToken cancellationToken)
        {
            var createAlbumIdResult = AlbumId.Create(request.AlbumId);
            if (createAlbumIdResult.IsError)
            {
                return createAlbumIdResult.Errors;
            }
            if (!await _albumRepository.ExistsAsync(createAlbumIdResult.Value))
            {
                return Errors.Album.NotFound;
            }
            var album = await _albumRepository.GetByIdAsync(createAlbumIdResult.Value, cancellationToken);
            album.SetName(request.Name);
            album.SetDescription(request.Description);
            album.SetAllowPublicUpload(request.AllowPublicUpload);
            album.SetReviewUploadedContent(request.ReviewUploadedContent);
            album.SetIsPublic(request.IsPublic);
            if (request.AlbumImage != null)
            {
                var isContentValid = await _contentValidator.IsValidContent(request.AlbumImage.File);
                if (!isContentValid)
                {
                    return Error.Conflict(description: "Content not valid");
                }

                var imageUrl = await _storageService.AddFile(request.AlbumImage.ContentType, $"{album.UserId.Value}/Albums/{album.Id.Value}/Profile/{Guid.NewGuid() + request.AlbumImage.Extension}", request.AlbumImage.File);

                album.SetUrl(imageUrl.Value);
            }

            if(string.IsNullOrEmpty(request.BackgroundUrl) && album.BackgroundUrl!=null)
            {

                var deletePictureResult = await _storageService.RemoveFile(album.UserId.Value.ToString() + "/" + album.BackgroundUrl.Substring(album.BackgroundUrl.LastIndexOf("Albums")));

                if (deletePictureResult.IsError)
                {
                    return Error.Conflict(description: "An error occurred while updating the album background image");
                }
                album.SetBackgroundUrl(null);
            }
            if (request.AlbumBackgroundImage != null)
            {
                var isContentValid = await _contentValidator.IsValidContent(request.AlbumBackgroundImage.File);
                if (!isContentValid)
                {
                    return Error.Conflict(description: "Content not valid");
                }

                var backgroundUrl = await _storageService.AddFile(request.AlbumBackgroundImage.ContentType, $"{album.UserId.Value}/Albums/{album.Id.Value}/Profile/Background/{Guid.NewGuid() + request.AlbumBackgroundImage.Extension}", request.AlbumBackgroundImage.File);

                album.SetBackgroundUrl(backgroundUrl.Value);
            }
            await _albumRepository.UpdateAsync(album,cancellationToken);
            return _mapper.Map<AlbumModel>(album);
        }
    }
}
