using ErrorOr;
using MapsterMapper;
using MediatR;
using FestCover.Application.Common.Models.Albums;
using FestCover.Application.Common.Persistence;
using FestCover.Domain.Albums.ValueObjects;
using FestCover.Domain.Common.DomainErrors;

namespace FestCover.Application.Albums.Queries.GetAlbum
{
    public class GetAlbumQueryHandler : IRequestHandler<GetAlbumQuery, ErrorOr<AlbumDetailModel>>
    {
        private readonly IMapper _mapper;
        private readonly IAlbumRepository _albumRepository;
        public GetAlbumQueryHandler(IMapper mapper, IAlbumRepository albumRepository)
        {
            _mapper = mapper;
            _albumRepository = albumRepository;
        }
        public async Task<ErrorOr<AlbumDetailModel>> Handle(GetAlbumQuery request, CancellationToken cancellationToken)
        {
            var getAlbumIdResult = AlbumId.Create(request.AlbumId);
            if (getAlbumIdResult.IsError)
            {
                return getAlbumIdResult.Errors;
            }
            if (!await _albumRepository.ExistsAsync(getAlbumIdResult.Value))
            {
                return Errors.Album.NotFound;
            }
            var album = await _albumRepository.GetByIdAsync(getAlbumIdResult.Value, cancellationToken);
            return _mapper.Map<AlbumDetailModel>(album);
        }
    }
}
