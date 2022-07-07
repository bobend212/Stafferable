using System.ComponentModel.DataAnnotations;

namespace Stafferable.Shared.Auth
{
    public class UserLogin
    {
        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}