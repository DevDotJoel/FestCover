using ErrorOr;
using MapsterMapper;
using MediatR;
using FestCover.Application.Common.Contracts;
using FestCover.Application.Common.Models.Albums;
using FestCover.Application.Common.Persistence;
using FestCover.Domain.Albums;
using FestCover.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace FestCover.Application.Albums.Commands.CreateAlbum
{
    public class CreateAlbumCommandHandler : IRequestHandler<CreateAlbumCommand, ErrorOr<AlbumModel>>
    {
        private readonly IAlbumRepository _albumRepository;
        private readonly IStorageService _storageService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;
        public CreateAlbumCommandHandler(
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
        public async Task<ErrorOr<AlbumModel>> Handle(CreateAlbumCommand request, CancellationToken cancellationToken)
        {

            var userId = UserId.Create(Guid.Parse(_userService.GetCurrentUserId()));
            var album = Album.Create(request.Name, request.Description);

            var small = _imageService.ConvertToSmallImage(request.AlbumImage.File);
            var medium = _imageService.ConvertToMediumImage(request.AlbumImage.File);
            var large = _imageService.ConvertToLargImage(request.AlbumImage.File);

            
            var originalPath = await _storageService.AddFile(request.AlbumImage.ContentType, $"{userId}/Albums/{album.Id.Value}/Profile/original/{Guid.NewGuid() + request.AlbumImage.Extension}", request.AlbumImage.File);
            var smallPath = await _storageService.AddFile(request.AlbumImage.ContentType, $"{userId}/Albums/{album.Id.Value}/Profile/small/{Guid.NewGuid() + request.AlbumImage.Extension}", small);
            var mediumPath = await _storageService.AddFile(request.AlbumImage.ContentType, $"{userId}/Albums/{album.Id.Value}/Profile/medium/{Guid.NewGuid() + request.AlbumImage.Extension}", medium);
            var LargePath = await _storageService.AddFile(request.AlbumImage.ContentType, $"{userId}/Albums/{album.Id.Value}/Profile/large/{Guid.NewGuid() + request.AlbumImage.Extension}", large);          

            album.SetOriginalAlbumUrlImage(originalPath.Value);
            album.SetSmallAlbumUrlImage(smallPath.Value);
            album.SetMediumAlbumUrlImage(mediumPath.Value);
            album.SetLargeAlbumUrlImage(LargePath.Value);
            await _albumRepository.AddAsync(album,cancellationToken);
            return _mapper.Map<AlbumModel>(album);
        }
    }
}
