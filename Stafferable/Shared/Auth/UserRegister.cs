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

        public string Role { get; set; } = "User";

        [Required]
        public string FName { get; set; } = string.Empty;

        [Required]
        public string LName { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
    }
}