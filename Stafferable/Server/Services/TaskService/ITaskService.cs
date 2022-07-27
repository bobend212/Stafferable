namespace Stafferable.Server.Services.TaskService
{
    public interface ITaskService
    {
        Task<ServiceResponse<List<TaskItem>>> GetAllTasksByProjectId(Guid projectId);
    }
}