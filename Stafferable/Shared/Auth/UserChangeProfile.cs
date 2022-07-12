using System.ComponentModel.DataAnnotations;

namespace Stafferable.Shared.Auth
{
    public class UserChangeProfile
    {
        [Required]
        public string FName { get; set; } = string.Empty;

        [Required]
        public string LName { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;

        [Phone]
        public string Phone { get; set; } = string.Empty;

        public string Department { get; set; } = string.Empty;
    }
}