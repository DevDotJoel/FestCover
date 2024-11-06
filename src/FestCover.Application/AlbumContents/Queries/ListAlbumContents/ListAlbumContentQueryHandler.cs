using ErrorOr;
using FestCover.Application.Common.Models.Albums;
using FestCover.Application.Common.Persistence;
using FestCover.Domain.Albums.ValueObjects;
using MapsterMapper;
using MediatR;
using FestCover.Domain.Common.DomainErrors;

namespace FestCover.Application.AlbumContents.Queries.ListAlbumContents
{
    public class ListAlbumContentQueryHandler : IRequestHandler<ListAlbumContentQuery, ErrorOr<List<AlbumContentModel>>>
    {
        private readonly IAlbumRepository _albumRepository;
        private readonly IAlbumContentRepository _albumContentRepository;
        private readonly IMapper _mapper;
        public ListAlbumContentQueryHandler(IAlbumContentRepository albumContentRepository,IMapper mapper,IAlbumRepository albumRepository)
        {
            _albumContentRepository = albumContentRepository;
            _mapper = mapper;
            _albumRepository = albumRepository;
            
        }
        public async Task<ErrorOr<List<AlbumContentModel>>> Handle(ListAlbumContentQuery request, CancellationToken cancellationToken)
        {
            var listAlbumIdResult = AlbumId.Create(request.AlbumId);
            if (listAlbumIdResult.IsError)
            {
                return listAlbumIdResult.Errors;
            }
            if (!await _albumRepository.ExistsAsync(listAlbumIdResult.Value))
            {
                return Errors.Album.NotFound;
            }
            return _mapper.Map<List<AlbumContentModel>>(await _albumContentRepository.GetApprovedAlbumContentsByAlbumId(listAlbumIdResult.Value, cancellationToken));
        }
    }
}
