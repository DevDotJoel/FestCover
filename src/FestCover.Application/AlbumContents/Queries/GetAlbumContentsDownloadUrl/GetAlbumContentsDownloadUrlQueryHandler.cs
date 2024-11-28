using ErrorOr;
using FestCover.Application.Common.Persistence;
using FestCover.Domain.Albums.ValueObjects;
using MapsterMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FestCover.Domain.Common.DomainErrors;
using FestCover.Application.Common.Contracts;
using static System.Net.Mime.MediaTypeNames;
using FestCover.Domain.Common;
using FestCover.Application.Common.Models.Files;
namespace FestCover.Application.AlbumContents.Queries.GetAlbumContentsDownloadUrl
{
    public class GetAlbumContentsDownloadUrlQueryHandler : IRequestHandler<GetAlbumContentsDownloadUrlQuery,ErrorOr<FileDownloadModel>>
    {
        private readonly IAlbumRepository _albumRepository;
        private readonly IAlbumContentRepository _albumContentRepository;
        private readonly IStorageService _storageService;
        private readonly IUserService _userService;
        public GetAlbumContentsDownloadUrlQueryHandler(IAlbumContentRepository albumContentRepository, IAlbumRepository albumRepository,IStorageService storageService, IUserService userService)
        {
            _albumRepository = albumRepository;
            _albumContentRepository = albumContentRepository;
            _storageService = storageService;

            _userService = userService;

        }
        public async Task<ErrorOr<FileDownloadModel>> Handle(GetAlbumContentsDownloadUrlQuery request, CancellationToken cancellationToken)
        {
            var listAlbumIdResult = AlbumId.Create(request.AlbumId);

            if (!await _albumRepository.ExistsAsync(listAlbumIdResult))
            {
                return Errors.Album.NotFound;
            }
            var userId = UserId.Create(Guid.Parse(_userService.GetCurrentUserId()));
            var album= await _albumRepository.GetByIdAsync(listAlbumIdResult,cancellationToken);
            if(album.UserId!=userId)
            {
                return Error.NotFound(description: "Album not found");
            }
            var albumContents = await _albumContentRepository.GetByIdsAsync(album.AlbumContentIds.ToList(), cancellationToken);
            var fileNames = albumContents.ConvertAll(ac =>
            {
                var fileName = ac.Url.Substring(ac.Url.LastIndexOf(album.UserId.Value.ToString()));
                return fileName;
            });

            var fileName = Guid.NewGuid().ToString();
            var filesDownloaded = await _storageService.GetDownloadImageAsync(fileNames);

            return new FileDownloadModel(Guid.NewGuid().ToString()+".zip", "application/zip", filesDownloaded.Value);

        }
    }
}
