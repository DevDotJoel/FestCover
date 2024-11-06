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
            var album = Album.Create(request.Name, request.Description,request.IsPublic ,request.AllowPublicUpload,request.ReviewUploadedContent);            
            var imageUrl = await _storageService.AddFile(request.AlbumImage.ContentType, $"{userId}/Albums/{album.Id.Value}/Profile/{Guid.NewGuid() + request.AlbumImage.Extension}", request.AlbumImage.File);       
            album.SetUrl(imageUrl.Value);
            await _albumRepository.AddAsync(album,cancellationToken);
            return _mapper.Map<AlbumModel>(album);
        }
    }
}
