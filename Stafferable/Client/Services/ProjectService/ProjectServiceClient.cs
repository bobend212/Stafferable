using System.Net.Http.Json;

namespace Stafferable.Client.Services.ProjectService
{
    public class ProjectServiceClient : IProjectServiceClient
    {
        private readonly HttpClient _http;

        public ProjectServiceClient(HttpClient http)
        {
            _http = http;
        }

        public async Task<ServiceResponse<List<Project>>> GetAllProjects()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<Project>>>($"/api/project/list");
            return result;
        }

        public async Task<ServiceResponse<Project>> GetSingleProject(Guid projectId)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<Project>>($"/api/Project/{projectId}");
            return result;
        }

        public async Task<ServiceResponse<Project>> PostProject(ProjectPostDTO request)
        {
            var result = await _http.PostAsJsonAsync("api/Project/post-project", request);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<Project>>();
        }

        public async Task DeleteProject(Guid projectId)
        {
            var result = await _http.DeleteAsync($"/api/Project/{projectId}");
        }

        public async Task UpdateProject(Project request)
        {
            var result = await _http.PutAsJsonAsync("api/Project/project-update", request);
        }
    }
}