using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stafferable.Shared.Timesheet
{
    public class TimesheetRecord
    {
        [Key]
        public Guid RecordId { get; set; }

        [JsonIgnore]
        public TimesheetCard TimesheetCard { get; set; }

        public Guid TimesheetCardId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int WeekNo { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Type { get; set; } = string.Empty;

        public string? Project { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Time { get; set; }
    }
}