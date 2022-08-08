namespace Stafferable.Shared.Project
{
    public class ProjectGet
    {
        public Guid ProjectId { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateEdited { get; set; }
    }
}