namespace Stafferable.Shared.Tasks
{
    public class TaskItemPostDTO
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public int? AssignedToId { get; set; }
        public int AuthorId { get; set; }
        public int? EditorId { get; set; }
        public Guid? ProjectId { get; set; }
        public DateTime? DeadlineDate { get; set; }
        public bool IsComplete { get; set; } = false;
        public DateTime? CompleteDate { get; set; }
        public string TaskStatus { get; set; } = "not started";
        public string Priority { get; set; } = "Medium";
        public DateTime? DateCreated { get; set; } = DateTime.Now;
        public DateTime? DateEdited { get; set; }
    }
}