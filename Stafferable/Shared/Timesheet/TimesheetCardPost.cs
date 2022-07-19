namespace Stafferable.Shared.Timesheet
{
    public class TimesheetCardPost
    {
        public string? CustomName { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Status { get; set; } = string.Empty;
        public decimal TotalHours { get; set; }
        public int UserId { get; set; }
    }
}