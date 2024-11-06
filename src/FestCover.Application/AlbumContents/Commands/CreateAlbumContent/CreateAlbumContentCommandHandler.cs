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
        public CreateAlbumContentCommandHandler(
            IAlbumRepository albumRepository,
            IStorageService storageService,
            IUserService userService,
            IMapper mapper,
            IAlbumContentRepository albumContentRepository
            )
        {

            _albumRepository = albumRepository;
            _albumRepository = albumRepository;
            _storageService = storageService;
            _userService = userService;
            _mapper = mapper;
            _albumContentRepository = albumContentRepository;
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
            List<AlbumContent> albumContents = new();
            foreach (var albumContentImage in request.AlbumContentImages)
            {
                var albumContent = AlbumContent.Create(createAlbumIdResult.Value,false, null);
                var imageUrl = await _storageService.AddFile(albumContentImage.ContentType, $"{userId}/Albums/{createAlbumIdResult.Value}/Content/{albumContent.Id.Value + albumContentImage.Extension}", albumContentImage.File);
                albumContent.SetUrl(imageUrl.Value);
                albumContents.Add(albumContent);
            }


            //album.AddContent(formattedPhoneNumber, contentUrl.Value);
            await _albumContentRepository.AddRangeAsync(albumContents, cancellationToken);
                return Result.Success;

            

        }
    }
}
