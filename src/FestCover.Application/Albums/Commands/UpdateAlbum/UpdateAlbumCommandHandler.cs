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
        private readonly IImageService _imageService;
        public UpdateAlbumCommandHandler(
             IAlbumRepository albumRepository,
            IStorageService storageService,
            IUserService userService,
            IMapper mapper,
           IImageService imageService
            )
        {
            _albumRepository = albumRepository;
            _albumRepository = albumRepository;
            _storageService = storageService;
            _userService = userService;
            _mapper = mapper;
            _imageService = imageService;
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
            if (request.AlbumImage != null) 
            {

                var imageUrl = await _storageService.AddFile(request.AlbumImage.ContentType, $"{album.UserId.Value}/Albums/{album.Id.Value}/Profile/{Guid.NewGuid() + request.AlbumImage.Extension}", request.AlbumImage.File);

                album.SetUrl(imageUrl.Value);
            }
            await _albumRepository.UpdateAsync(album,cancellationToken);
            return _mapper.Map<AlbumModel>(album);
        }
    }
}
