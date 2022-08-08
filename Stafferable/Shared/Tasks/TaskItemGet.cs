using Stafferable.Shared.Project;

namespace Stafferable.Shared.Tasks
{
    public class TaskItemGet
    {
        public Guid TaskItemId { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public int? AssignedToId { get; set; }
        public int AuthorId { get; set; }
        public int? EditorId { get; set; }
        public ProjectGet? Project { get; set; }
        public DateTime? DeadlineDate { get; set; }
        public bool IsComplete { get; set; } = false;
        public DateTime? CompleteDate { get; set; }
        public string TaskStatus { get; set; }
        public string Priority { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateEdited { get; set; }
    }
}