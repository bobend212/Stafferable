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
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<TaskItem>>>($"/api/Tasks/{projectId}/tasks");
            return result;
        }
    }
}