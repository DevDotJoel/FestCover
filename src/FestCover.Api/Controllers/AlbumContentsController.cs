using FestCover.Application.AlbumContents.Commands.ApproveAlbumContent;
using FestCover.Application.AlbumContents.Commands.CreateAlbumContent;
using FestCover.Application.AlbumContents.Commands.CreatetPublicAlbumContent;
using FestCover.Application.AlbumContents.Commands.DeleteAlbumContent;
using FestCover.Application.AlbumContents.Commands.RejectAlbumContent;
using FestCover.Application.AlbumContents.Queries.GetAlbumContentsDownloadUrl;
using FestCover.Application.AlbumContents.Queries.ListAlbumContents;
using FestCover.Application.AlbumContents.Queries.ListPendingAlbumContents;
using FestCover.Contracts.Albums;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FestCover.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumContentsController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public AlbumContentsController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
        [HttpGet("{albumId}")]
        public async Task<IActionResult> ListAlbumContents(string albumId)
        {
            var query = new ListAlbumContentQuery(albumId);
            var result = await _mediator.Send(query);
            return result.Match(Ok, Problem);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAlbumContent([FromForm] CreateAlbumContentRequest createAlbumContenttRequest)
        {
            var command = _mapper.Map<CreateAlbumContentCommand>(createAlbumContenttRequest);
            var result = await _mediator.Send(command);
            return result.Match(_ => NoContent(), Problem);
        }
        [HttpDelete("{albumContentId}")]
        public async Task<IActionResult> DeleteAlbumContent(string albumContentId)
        {
            var command = new DeleteAlbumContentCommand(albumContentId);
            var result = await _mediator.Send(command);
            return result.Match(_ => NoContent(), Problem);
        }
        [HttpPost("Approve")]
        public async Task<IActionResult> ApproveAlbumContent(ApproveAlbumContentRequest request)
        {
            var command = new ApproveAlbumContentCommand(request.AlbumContentId);
            var result = await _mediator.Send(command);
            return result.Match(_ => NoContent(), Problem);
        }
        [HttpPost("Reject")]
        public async Task<IActionResult> RejectAlbumContent(RejectAlbumContentRequest request)
        {
            var command = new RejectAlbumContentCommand(request.AlbumContentId);
            var result = await _mediator.Send(command);
            return result.Match(_ => NoContent(), Problem);
        }
        [HttpGet("Pending")]
        public async Task<IActionResult> ListPendingAlbumContents()
        {
            var query = new ListPendingAlbumContenstQuery();
            var result = await _mediator.Send(query);
            return result.Match(Ok, Problem);
        }
        [HttpGet("Download/{albumId}")]
        public async Task<IActionResult> GetAlbumContentsDownloadUrl(Guid albumId)
        {
            var query = new GetAlbumContentsDownloadUrlQuery(albumId);
            var result = await _mediator.Send(query);
            return result.Match(a=>File(a.File, a.FileType, a.Filename), Problem);
        }
        [AllowAnonymous]
        [HttpPost("Public/Upload")]
        public async Task<IActionResult> CreatePublicAlbumContent([FromForm] CreatePublicAlbumContentRequest createPublicAlbumContentRequest)
        {
            var command = _mapper.Map<CreatetPublicAlbumContentCommand>(createPublicAlbumContentRequest);
            var result = await _mediator.Send(command);
            return result.Match(_ => NoContent(), Problem);
        }
    }
}

