using Stafferable.Shared.Tasks;

namespace Stafferable.Client.Services.TaskService
{
    public interface ITaskServiceClient
    {
        Task<ServiceResponse<List<TaskItem>>> GetAllTasksByProjectId(Guid projectId);
    }
}