﻿using ErrorOr;
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
        private readonly IContentValidator _contentValidator;

        public CreateAlbumCommandHandler(
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
        public async Task<ErrorOr<AlbumModel>> Handle(CreateAlbumCommand request, CancellationToken cancellationToken)
        {

            var userId = UserId.Create(Guid.Parse(_userService.GetCurrentUserId()));
            var isContentValid = await _contentValidator.IsValidContent(request.AlbumImage.File);
            if (!isContentValid)
            {
                return Error.Conflict(description: "Content not valid");
            }
            var album = Album.Create(request.Name, request.Description,request.IsPublic ,request.AllowPublicUpload,request.ReviewUploadedContent);            
            var imageUrl = await _storageService.AddFile(request.AlbumImage.ContentType, $"{userId}/Albums/{album.Id.Value}/Profile/{Guid.NewGuid() + request.AlbumImage.Extension}", request.AlbumImage.File);     
            album.SetUrl(imageUrl.Value);
            if(request.AlbumBackgroundImage != null)
            {
                var isBackgroundContentValid = await _contentValidator.IsValidContent(request.AlbumBackgroundImage.File);
                if (!isBackgroundContentValid)
                {
                    return Error.Conflict(description: "Content not valid");
                }
                var backgroundUrl = await _storageService.AddFile(request.AlbumBackgroundImage.ContentType, $"{userId}/Albums/{album.Id.Value}/Profile/Background/{Guid.NewGuid() + request.AlbumBackgroundImage.Extension}", request.AlbumBackgroundImage.File);
                album.SetBackgroundUrl(backgroundUrl.Value);
            }
            await _albumRepository.AddAsync(album,cancellationToken);
            return _mapper.Map<AlbumModel>(album);
        }
    }
}
