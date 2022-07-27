using Stafferable.Shared.Auth;
using System.ComponentModel.DataAnnotations;

namespace Stafferable.Shared.Tasks
{
    public class TaskItem
    {
        [Key]
        public Guid TaskItemId { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }
        public int? AssignedToId { get; set; }
        public User? AssignedTo { get; set; }
        public int AuthorId { get; set; }
        public User? Author { get; set; }
        public int? EditorId { get; set; }
        public User? Editor { get; set; }
        public Guid? ProjectId { get; set; }
        public Project.Project? Project { get; set; }
        public DateTime? DeadlineDate { get; set; }
        public DateTime? CompleteDate { get; set; }

        [Required]
        public string TaskStatus { get; set; } = "not started";

        [Required]
        public string Priority { get; set; } = "Medium";

        [Required]
        public DateTime? DateCreated { get; set; } = DateTime.Now;

        public DateTime? DateEdited { get; set; }
    }
}