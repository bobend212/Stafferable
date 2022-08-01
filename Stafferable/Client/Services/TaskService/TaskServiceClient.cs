using Stafferable.Shared.Tasks;
using System.Net.Http.Json;

namespace Stafferable.Client.Services.TaskService
{
    public class TaskServiceClient : ITaskServiceClient
    {
        private readonly HttpClient _http;

        public TaskServiceClient(HttpClient http)
        {
            _http = http;
        }
        public async Task<ServiceResponse<List<TaskItem>>> GetAllTasksByProjectId(Guid projectId)
        {
            ServiceResponse<List<TaskItem>> result = await _http.GetFromJsonAsync<ServiceResponse<List<TaskItem>>>($"/api/Tasks/{projectId}/tasks");
            return result!;
        }

        public async Task<ServiceResponse<TaskItem>> PostTask(TaskItem request)
        {
            var result = await _http.PostAsJsonAsync("api/Tasks/post-task", request);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<TaskItem>>();
        }

        public async Task CompleteTask(TaskItem request)
        {
            var result = await _http.PutAsJsonAsync("api/Tasks/complete-task", request);
        }

        public async Task UpdateTask(TaskItem request)
        {
            var result = await _http.PutAsJsonAsync("api/Tasks/task-update", request);
        }
    }
}