using Microsoft.AspNetCore.Mvc;
using Stafferable.Server.Services.ProjectService;

namespace Stafferable.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly IMapper _mapper;

        public ProjectController(IProjectService projectService, IMapper mapper)
        {
            _projectService = projectService;
            _mapper = mapper;
        }

        [HttpGet("list")]
        public async Task<ActionResult<ServiceResponse<List<Project>>>> GetAllProjects()
        {
            var response = await _projectService.GetAllProjects();
            return Ok(response);
        }

        [HttpGet("{projectId}")]
        public async Task<ActionResult<ServiceResponse<Project>>> GetSingleProject(Guid projectId)
        {
            var response = await _projectService.GetSingleProject(projectId);
            return Ok(response);
        }

        [HttpPost("post-project")]
        public async Task<ActionResult<ServiceResponse<Project>>> PostProject(ProjectPostDTO request)
        {
            var response = await _projectService.PostProject(request);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpDelete("{projectId}")]
        public async Task<ActionResult<ServiceResponse<bool>>> DeleteProject(Guid projectId)
        {
            var response = await _projectService.DeleteProject(projectId);
            return Ok(response);
        }

        [HttpPut("project-update")]
        public async Task<ActionResult<ServiceResponse<bool>>> UpdateProject(Project request)
        {
            var result = await _projectService.UpdateProject(request);
            return Ok(result);
        }
    }
}