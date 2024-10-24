using System.ComponentModel.DataAnnotations;

namespace FestCover.Contracts.Authentication
{
    public class RegisterUserRequest
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Password2 { get; set; }
    }
}
