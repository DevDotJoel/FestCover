using ErrorOr;
using MapsterMapper;
using MediatR;
using FestCover.Application.Common.Contracts;
using FestCover.Application.Common.Persistence;
using FestCover.Domain.Albums.ValueObjects;
using FestCover.Domain.AlbumContents;
using FestCover.Domain.Common.DomainErrors;
using FestCover.Domain.Common;

namespace FestCover.Application.AlbumContents.Commands.CreateAlbumContent
{
    public class CreateAlbumContentCommandHandler : IRequestHandler<CreateAlbumContentCommand, ErrorOr<Success>>
    {
        private readonly IAlbumRepository _albumRepository;
        private readonly IAlbumContentRepository _albumContentRepository;
        private readonly IStorageService _storageService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;
        public CreateAlbumContentCommandHandler(
            IAlbumRepository albumRepository,
            IStorageService storageService,
            IUserService userService,
            IMapper mapper,
            IAlbumContentRepository albumContentRepository,
            IImageService imageService
            )
        {

            _albumRepository = albumRepository;
            _albumRepository = albumRepository;
            _storageService = storageService;
            _userService = userService;
            _mapper = mapper;
            _albumContentRepository = albumContentRepository;
            _imageService = imageService;
        }
        public async Task<ErrorOr<Success>> Handle(CreateAlbumContentCommand request, CancellationToken cancellationToken)
        {
     
                var userId = UserId.Create(Guid.Parse(_userService.GetCurrentUserId()));
                var createAlbumIdResult = AlbumId.Create(request.AlbumId);
                if (createAlbumIdResult.IsError)
                {
                    return createAlbumIdResult.Errors;
                }
                if (!await _albumRepository.ExistsAsync(createAlbumIdResult.Value))
                {
                    return Errors.Album.NotFound;
                }

            //var phoneNumberUtil = PhoneNumberUtil.GetInstance();
            //var phoneNumber = phoneNumberUtil.Parse(request.PhoneNumber, null);
            //var isValid = phoneNumberUtil.IsValidNumber(phoneNumber);
            //if (!isValid)
            //{
            //    return Error.Conflict(description: "Invalid phone number");
            //}
            //var formattedPhoneNumber = phoneNumberUtil.Format(phoneNumber, PhoneNumberFormat.INTERNATIONAL);
            var small = _imageService.ConvertToSmallImage(request.AlbumContentImage.File);
            var medium = _imageService.ConvertToMediumImage(request.AlbumContentImage.File);
            var large = _imageService.ConvertToLargImage(request.AlbumContentImage.File);


            var albumContent = AlbumContent.Create(createAlbumIdResult.Value,null);
            var originalPath = await _storageService.AddFile(request.AlbumContentImage.ContentType, $"{userId}/Albums/{createAlbumIdResult.Value}/Content/original/{albumContent.Id.Value + request.AlbumContentImage.Extension}", request.AlbumContentImage.File);
            var smallPath = await _storageService.AddFile(request.AlbumContentImage.ContentType, $"{userId}/Albums/{createAlbumIdResult.Value}/Content/small/{albumContent.Id.Value + request.AlbumContentImage.Extension}", small);
            var mediumPath = await _storageService.AddFile(request.AlbumContentImage.ContentType, $"{userId}/Albums/{createAlbumIdResult.Value} /Content/medium/{albumContent.Id.Value + request.AlbumContentImage.Extension}", medium);
            var LargePath = await _storageService.AddFile(request.AlbumContentImage.ContentType, $"{userId}/Albums/{createAlbumIdResult.Value} /Content/large/{albumContent.Id.Value + request.AlbumContentImage.Extension}", large);


            albumContent.SetOriginalAlbumContentUrlImage(originalPath.Value);
            albumContent.SetSmallAlbumContentUrlImage(smallPath.Value);
            albumContent.SetMediumAlbumContentUrlImage(mediumPath.Value);
            albumContent.SetLargeAlbumContentUrlImage(LargePath.Value);

            //album.AddContent(formattedPhoneNumber, contentUrl.Value);
            await _albumContentRepository.AddAsync(albumContent, cancellationToken);
                return Result.Success;

            

        }
    }
}
