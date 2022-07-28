namespace Stafferable.Shared.Tasks
{
    public class TaskCompleteDTO
    {
        public Guid TaskItemId { get; set; }
        public int? EditorId { get; set; }
        public bool IsComplete { get; set; }
        public DateTime? CompleteDate { get; set; }
        public DateTime? DateEdited { get; set; }
    }
}