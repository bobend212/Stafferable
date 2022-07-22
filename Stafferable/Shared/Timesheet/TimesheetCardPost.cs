using System.ComponentModel.DataAnnotations;

namespace Stafferable.Shared.Timesheet
{
    public class TimesheetCardPost
    {
        public string? CustomName { get; set; }
        public DateTime DateCreated { get; set; }

        [Required]
        public DateTime? StartDate { get; set; }

        [Required]
        public DateTime? EndDate { get; set; }

        public string Status { get; set; } = string.Empty;
        public decimal TotalHours { get; set; }
        public int UserId { get; set; }
    }
}