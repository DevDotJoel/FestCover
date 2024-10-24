namespace FestCover.Contracts.Authentication
{
    public record AuthenticationResponse
   (
   string Token,
   double expiresIn
   );
}
