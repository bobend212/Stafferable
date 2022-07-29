namespace Stafferable.Client.Services.ProjectService
{
    public interface IProjectServiceClient
    {
        Task<ServiceResponse<List<Project>>> GetAllProjects();

        Task<ServiceResponse<Project>> GetSingleProject(Guid projectId);

        Task<ServiceResponse<Project>> PostProject(ProjectPostDTO request);

        Task DeleteProject(Guid projectId);

        Task UpdateProject(Project request);
    }
}