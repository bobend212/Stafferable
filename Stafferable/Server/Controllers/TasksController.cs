using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stafferable.Server.Services.TaskService;

namespace Stafferable.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet("{projectId}/tasks")]
        public async Task<ActionResult<ServiceResponse<List<TaskItem>>>> GetAllTasksByProjectId(Guid projectId)
        {
            var response = await _taskService.GetAllTasksByProjectId(projectId);
            return Ok(response);
        }
    }
}
