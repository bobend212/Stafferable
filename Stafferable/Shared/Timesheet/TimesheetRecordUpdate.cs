namespace Stafferable.Shared.Timesheet
{
    public class TimesheetRecordUpdate
    {
        public Guid RecordId { get; set; }

        public int WeekNo { get; set; }

        public DateTime? Date { get; set; }

        public string Type { get; set; } = string.Empty;

        public string? Project { get; set; }

        public decimal Time { get; set; }
    }
}