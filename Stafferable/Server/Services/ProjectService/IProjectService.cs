namespace Stafferable.Server.Services.ProjectService
{
    public interface IProjectService
    {
        Task<ServiceResponse<List<Project>>> GetAllProjects();

        Task<ServiceResponse<Project>> GetSingleProject(Guid projectId);

        Task<ServiceResponse<Project>> PostProject(ProjectPostDTO model);

        Task<ServiceResponse<bool>> DeleteProject(Guid projectId);

        Task<ServiceResponse<bool>> UpdateProject(Project model);
    }
}