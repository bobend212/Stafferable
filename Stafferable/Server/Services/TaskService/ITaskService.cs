namespace Stafferable.Server.Services.TaskService
{
    public interface ITaskService
    {
        Task<ServiceResponse<List<TaskItem>>> GetAllTasksByProjectId(Guid projectId);

        Task<ServiceResponse<TaskItem>> PostTask(TaskItem model);

        Task<ServiceResponse<bool>> CompleteTask(TaskCompleteDTO model);

        Task<ServiceResponse<bool>> UpdateTask(TaskItem model);

        Task<ServiceResponse<bool>> DeleteTask(Guid taskId);
    }
}