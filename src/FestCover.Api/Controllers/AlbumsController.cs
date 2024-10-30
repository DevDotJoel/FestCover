using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using FestCover.Application.Albums.Commands.CreateAlbum;
using FestCover.Application.Albums.Commands.UpdateAlbum;
using FestCover.Application.Albums.Queries.GetAlbum;
using FestCover.Application.Albums.Queries.ListAlbum;
using FestCover.Contracts.Albums;
using FestCover.Application.Albums.Commands.DeleteAlbum;
using FestCover.Application.Albums.Queries.GetAlbumByKey;
using Microsoft.AspNetCore.Authorization;


namespace FestCover.Api.Controllers
{
    [Route("api/albums")]
    [ApiController]
    public class AlbumsController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public AlbumsController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> ListAlbum()
        {
            var query = new ListAlbumQuery();
            var result = await _mediator.Send(query);
            return result.Match(Ok, Problem);
        }
        [HttpGet("{albumId}")]
        public async Task<IActionResult> GetAlbum(string albumId)
        {
            var query = new GetAlbumQuery(albumId);
            var result = await _mediator.Send(query);
            return result.Match(Ok, Problem);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAlbum([FromForm] CreateAlbumRequest createAlbumRequest)
        {
            var command = _mapper.Map<CreateAlbumCommand>(createAlbumRequest);
            var result = await _mediator.Send(command);
            return result.Match(Ok, Problem);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAlbum([FromForm] UpdateAlbumRequest updateAlbumRequest)
        {
            var command = _mapper.Map<UpdateAlbumCommand>(updateAlbumRequest);
            var result = await _mediator.Send(command);
            return result.Match(Ok, Problem);
        }
        [HttpDelete("{albumId}")]
        public async Task<IActionResult> DeleteAlbum(string albumId)
        {
            var command= new DeleteAlbumCommand(albumId);
            var result = await _mediator.Send(command);
            return result.Match(_=> NoContent(), Problem);
        }
        [AllowAnonymous]
        [HttpGet("public/{key}")]
        public async Task<IActionResult> ListAlbumContentsByKey(string key)
        {
            var query = new GetAlbumByKeyQuery(key);
            var result = await _mediator.Send(query);
            return result.Match(Ok, Problem);
        }
    }
}
