namespace Stafferable.Shared.Project
{
    public class ProjectPostDTO
    {
        public Guid ProjectId { get; set; }
        public int? Number { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Status { get; set; } = "New";
        public DateTime? DateAdded { get; set; } = DateTime.Now;

    }
}