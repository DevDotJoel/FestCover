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

namespace FestCover.Application.Albums.Commands.CreateAlbum
{
    public class CreateAlbumCommandHandler : IRequestHandler<CreateAlbumCommand, ErrorOr<AlbumModel>>
    {
        private readonly IAlbumRepository _albumRepository;
        private readonly IStorageService _storageService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public CreateAlbumCommandHandler(
            IAlbumRepository albumRepository,
            IStorageService storageService,
            IUserService userService,
            IMapper mapper)
        {

            _albumRepository = albumRepository;
            _albumRepository = albumRepository;
            _storageService = storageService;
            _userService = userService;
            _mapper = mapper;

        }
        public async Task<ErrorOr<AlbumModel>> Handle(CreateAlbumCommand request, CancellationToken cancellationToken)
        {

            var userId = UserId.Create(Guid.Parse(_userService.GetCurrentUserId()));
            var album = Album.Create(request.Name, request.Description);
            var result = await _storageService.AddFile(request.AlbumImage.ContentType, $"{userId}/Albums/{album.Id.Value}/Profile/{Guid.NewGuid() + request.AlbumImage.Extension}", request.AlbumImage.File);
            if(result.IsError)
            {
                return result.Errors;
            }
            album.SetAlbumUrlImage(result.Value);
            await _albumRepository.AddAsync(album,cancellationToken);
            return _mapper.Map<AlbumModel>(album);
        }
    }
}
