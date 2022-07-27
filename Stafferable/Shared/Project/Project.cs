using Newtonsoft.Json;
using Stafferable.Shared.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Stafferable.Shared.Project
{
    public class Project
    {
        [Key]
        public Guid ProjectId { get; set; }

        [Required]
        public int Number { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Status { get; set; } = "unknown";

        public DateTime? DateAdded { get; set; } = DateTime.Now;
        public DateTime? DateEdited { get; set; }

        [JsonIgnore]
        public List<TaskItem> Tasks { get; set; } = new List<TaskItem>();
    }
}