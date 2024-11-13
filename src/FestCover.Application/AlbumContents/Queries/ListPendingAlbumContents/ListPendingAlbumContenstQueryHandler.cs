using ErrorOr;
using FestCover.Application.Common.Models.Albums;
using FestCover.Application.Common.Persistence;
using FestCover.Domain.AlbumContents.ValueObjects;
using MapsterMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestCover.Application.AlbumContents.Queries.ListPendingAlbumContents
{
    public class ListPendingAlbumContenstQueryHandler : IRequestHandler<ListPendingAlbumContenstQuery, ErrorOr<List<AlbumContentPendingModel>>>
    {
        private readonly IAlbumRepository _albumRepository;
        private readonly IAlbumContentRepository _albumContentRepository;
        private readonly IMapper _mapper;
        public ListPendingAlbumContenstQueryHandler(IAlbumContentRepository albumContentRepository, IMapper mapper, IAlbumRepository albumRepository)
        {
            _albumContentRepository = albumContentRepository;
            _mapper = mapper;
            _albumRepository = albumRepository;
        }
        public async Task<ErrorOr<List<AlbumContentPendingModel>>> Handle(ListPendingAlbumContenstQuery request, CancellationToken cancellationToken)
        {
            var albumContents = await _albumContentRepository.GetPendingAlbumContents(cancellationToken);
            var albumContentsIds= albumContents.ConvertAll(ac=>ac.Id).ToList();
            var allAlbums= await _albumRepository.GetAllAsync(cancellationToken);
            var albums = allAlbums.Where(p => p.AlbumContentIds.Any(aci => albumContentsIds.Contains(aci))).Distinct().ToList();
            var result= albumContents.ConvertAll(content =>
            {
                var album= albums.Where(a=>a.AlbumContentIds.Contains(content.Id)).FirstOrDefault();

               return _mapper.Map<AlbumContentPendingModel>((album,content));

            }).ToList();
            return result;
        }
    }
}
