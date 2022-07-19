namespace Stafferable.Shared.Timesheet
{
    public class TimesheetRecordPost
    {
        public Guid TimesheetCardId { get; set; }

        public int UserId { get; set; }

        public int WeekNo { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        public string Type { get; set; } = string.Empty;

        public string? Project { get; set; }

        public decimal Time { get; set; }
    }
}