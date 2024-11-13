using ErrorOr;
using FestCover.Application.AlbumContents.Commands.CreatetPublicAlbumContent;
using FestCover.Application.Common.Contracts;
using FestCover.Application.Common.Persistence;
using FestCover.Domain.Albums.ValueObjects;
using MediatR;
using FestCover.Domain.Common.DomainErrors;
using PhoneNumbers;
using FestCover.Domain.Common;
using FestCover.Domain.AlbumContents;
using System.Text.RegularExpressions;

namespace FestCover.Application.AlbumContents.Commands.CreatetPublicAlbumContent
{
    public class CreatetPublicAlbumContentCommandHandler : IRequestHandler<CreatetPublicAlbumContentCommand, ErrorOr<Success>>
    {
        private readonly IAlbumRepository _albumRepository;
        private readonly IAlbumContentRepository _albumContentRepository;
        private readonly IStorageService _storageService;
        public CreatetPublicAlbumContentCommandHandler(IAlbumRepository albumRepository,
            IStorageService storageService,IAlbumContentRepository albumContentRepository)
        {
            _albumRepository = albumRepository;
            _albumContentRepository = albumContentRepository;
            _storageService = storageService;
            
            
        }
        public async Task<ErrorOr<Success>> Handle(CreatetPublicAlbumContentCommand request, CancellationToken cancellationToken)
        {
            var createAlbumIdResult = AlbumId.Create(request.AlbumId);
            if (!await _albumRepository.ExistsAsync(createAlbumIdResult.Value))
            {
                return Errors.Album.NotFound;
            }
            var album = await _albumRepository.GetByIdAsync(createAlbumIdResult.Value, cancellationToken);

            if (!album.AllowPublicUpload)
            {
                return Errors.Album.NotFound;
            }
            var currentPhoneNumber = request.PhoneNumber;
            if (!request.PhoneNumber.StartsWith("+"))
            {
                currentPhoneNumber = "+" + currentPhoneNumber;
            }
            var phoneNumberUtil = PhoneNumberUtil.GetInstance();
            var phoneNumber = phoneNumberUtil.Parse(currentPhoneNumber, null);
            var isValid = phoneNumberUtil.IsValidNumber(phoneNumber);
            if (!isValid)
            {
                return Error.Conflict(description: "Invalid phone number");
            }

            var formattedPhoneNumber = phoneNumberUtil.Format(phoneNumber, PhoneNumberFormat.INTERNATIONAL);

            List<AlbumContent> albumContents = new();
            foreach (var albumContentImage in request.AlbumPublicContentImages)
            {
                var albumContent = AlbumContent.Create(createAlbumIdResult.Value, album.ReviewUploadedContent, formattedPhoneNumber,request.Name);
                var imageUrl = await _storageService.AddFile(albumContentImage.ContentType, $"{album.UserId}/Albums/{createAlbumIdResult.Value}/Content/{albumContent.Id.Value + albumContentImage.Extension}", albumContentImage.File);
                albumContent.SetUrl(imageUrl.Value);
                albumContents.Add(albumContent);
            }
            await _albumContentRepository.AddRangeAsync(albumContents,cancellationToken);
            return Result.Success;
        }
    }
}
