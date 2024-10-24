using System.ComponentModel.DataAnnotations;

namespace FestCover.Contracts.Authentication
{
    public class LoginUserRequest
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
