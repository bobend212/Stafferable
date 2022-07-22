using Newtonsoft.Json;
using Stafferable.Shared.Auth;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stafferable.Shared.Timesheet
{
    public class TimesheetCard
    {
        [Key]
        public Guid TimesheetCardId { get; set; }

        public string? CustomName { get; set; }
        public DateTime DateCreated { get; set; }

        [Required]
        public DateTime? StartDate { get; set; }

        [Required]
        public DateTime? EndDate { get; set; }

        public string Status { get; set; } = string.Empty;

        [Column(TypeName = "decimal(10,2)")]
        public decimal TotalHours { get; set; }

        [JsonIgnore]
        public User User { get; set; }

        public int UserId { get; set; }

        public List<TimesheetRecord> TimesheetRecords { get; set; } = new List<TimesheetRecord>();
    }
}