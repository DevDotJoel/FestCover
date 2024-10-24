namespace FestCover.Application.Common.Models.Auth
{
    public record TokenResultModel
    (
      string AccessToken,
      string RefreshToken
    );
}
