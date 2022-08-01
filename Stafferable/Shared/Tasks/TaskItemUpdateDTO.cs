namespace Stafferable.Shared.Tasks
{
    public class TaskItemUpdateDTO
    {
        public Guid TaskItemId { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public int? AssignedToId { get; set; }
        public int? EditorId { get; set; }
        public Guid? ProjectId { get; set; }
        public DateTime? DeadlineDate { get; set; }
        public string Priority { get; set; } = "Medium";
        public DateTime? DateEdited { get; set; }
    }
}