namespace Stafferable.Shared.Auth
{
    public class UserGet
    {
        public string Email { get; set; } = string.Empty;
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime? DateEdited { get; set; }
        public string Role { get; set; } = "User";

        // additional properties
        public string FName { get; set; } = string.Empty;

        public string LName { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        //
    }
}