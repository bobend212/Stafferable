using System.ComponentModel.DataAnnotations;

namespace Stafferable.Shared
{
    public class UserRegister
    {
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required, StringLength(50, MinimumLength = 4)]
        public string Password { get; set; } = string.Empty;

        [Compare("Password", ErrorMessage = "The Password does not match.")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}