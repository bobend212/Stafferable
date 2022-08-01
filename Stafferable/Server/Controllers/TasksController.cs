using Microsoft.AspNetCore.Mvc;
using Stafferable.Server.Services.TaskService;
using System.Security.Claims;

namespace Stafferable.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;
        private readonly IMapper _mapper;

        public TasksController(ITaskService taskService, IMapper mapper)
        {
            _taskService = taskService;
            _mapper = mapper;
        }

        [HttpGet("{projectId}/tasks")]
        public async Task<ActionResult<ServiceResponse<List<TaskItem>>>> GetAllTasksByProjectId(Guid projectId)
        {
            ServiceResponse<List<TaskItem>> response = await _taskService.GetAllTasksByProjectId(projectId);
            return Ok(response);
        }

        [HttpPost("post-task")]
        public async Task<ActionResult<ServiceResponse<TaskItem>>> PostTask(TaskItemPostDTO request)
        {
            var loggedUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var newTask = new TaskItem
            {
                Title = request.Title,
                Description = request.Description,
                AssignedToId = request.AssignedToId,
                AuthorId = int.Parse(loggedUserId),
                ProjectId = request.ProjectId,
                DeadlineDate = request.DeadlineDate,
                CompleteDate = request.CompleteDate,
                TaskStatus = request.TaskStatus,
                Priority = request.Priority,
                DateCreated = DateTime.Now
            };

            var response = await _taskService.PostTask(newTask);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPut("complete-task")]
        public async Task<ActionResult<ServiceResponse<TaskItem>>> CompleteTask([FromBody] TaskCompleteDTO request)
        {
            var loggedUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            request.EditorId = int.Parse(loggedUserId);
            var result = await _taskService.CompleteTask(request);
            return Ok(result);
        }

        [HttpPut("task-update")]
        public async Task<ActionResult<ServiceResponse<bool>>> UpdateTask([FromBody] TaskItemUpdateDTO request)
        {
            var loggedUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            request.EditorId = int.Parse(loggedUserId);
            var result = await _taskService.UpdateTask(_mapper.Map<TaskItem>(request));
            return Ok(result);
        }
    }
}