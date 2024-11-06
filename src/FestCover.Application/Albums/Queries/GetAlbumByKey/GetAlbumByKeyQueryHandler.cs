using ErrorOr;
using FestCover.Application.Common.Models.Albums;
using FestCover.Application.Common.Persistence;
using MapsterMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestCover.Application.Albums.Queries.GetAlbumByKey
{
    public class GetAlbumByKeyQueryHandler : IRequestHandler<GetAlbumByKeyQuery, ErrorOr<AlbumDetailModel>>
    {
        private readonly IAlbumRepository _albumRepository;
        private readonly IAlbumContentRepository _albumContentRepository;
        private readonly IMapper _mapper;
        public GetAlbumByKeyQueryHandler(IAlbumContentRepository albumContentRepository, IMapper mapper, IAlbumRepository albumRepository)
        {
            _albumContentRepository = albumContentRepository;
            _mapper = mapper;
            _albumRepository = albumRepository;
        }
        public async Task<ErrorOr<AlbumDetailModel>> Handle(GetAlbumByKeyQuery request, CancellationToken cancellationToken)
        {
            var album = await _albumRepository.GetAlbumByKey(request.Key, cancellationToken);
            if (album is null || !album.IsPublic)
            {
                return Error.NotFound(description: "Album not found");
            }
            
            var albumContents = await _albumContentRepository.GetAlbumContentsByAlbumId(album.Id,cancellationToken);
            return _mapper.Map<AlbumDetailModel>((album,albumContents));
        }
    }
}
