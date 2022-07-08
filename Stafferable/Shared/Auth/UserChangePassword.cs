using System.ComponentModel.DataAnnotations;

namespace Stafferable.Shared.Auth
{
    public class UserChangePassword
    {
        [Required, StringLength(50, MinimumLength = 4)]
        public string Password { get; set; } = string.Empty;

        [Compare("Password", ErrorMessage = "The Password does not match.")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}