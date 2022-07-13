using Stafferable.Shared.Timesheet;

namespace Stafferable.Shared.Auth
{
    public class User
    {
        public int UserId { get; set; }
        public string Email { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
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

        public List<TimesheetCard> TimesheetCards { get; set; } = new List<TimesheetCard>();
    }
}