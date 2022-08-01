using Stafferable.Shared.Tasks;

namespace Stafferable.Client.Services.TaskService
{
    public interface ITaskServiceClient
    {
        Task<ServiceResponse<List<TaskItem>>> GetAllTasksByProjectId(Guid projectId);

        Task<ServiceResponse<TaskItem>> PostTask(TaskItem request);

        Task CompleteTask(TaskItem request);

        Task UpdateTask(TaskItem request);
    }
}