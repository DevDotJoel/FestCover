using ErrorOr;
using MediatR;


namespace FestCover.Application.AlbumContents.Commands.DeleteAlbumContent
{
    public record DeleteAlbumContentCommand(string AlbumContentId):IRequest<ErrorOr<Success>>;
}
