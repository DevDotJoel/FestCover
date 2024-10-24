using ErrorOr;
using MapsterMapper;
using MediatR;
using FestCover.Application.Common.Models.Albums;
using FestCover.Application.Common.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestCover.Application.Albums.Queries.ListAlbum
{
    public class ListAlbumQueryHandler : IRequestHandler<ListAlbumQuery, ErrorOr<List<AlbumModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IAlbumRepository _albumRepository;
        public ListAlbumQueryHandler(IMapper mapper, IAlbumRepository albumRepository)
        {
            _mapper = mapper;
            _albumRepository = albumRepository;
            
        }
        public async Task<ErrorOr<List<AlbumModel>>> Handle(ListAlbumQuery request, CancellationToken cancellationToken)
        {
           return _mapper.Map<List<AlbumModel>>(await _albumRepository.GetAllAsync(cancellationToken));
        }
    }
}
