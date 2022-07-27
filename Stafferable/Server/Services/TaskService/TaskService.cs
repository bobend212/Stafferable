namespace Stafferable.Server.Services.TaskService
{
    public class TaskService : ITaskService
    {
        private readonly ApplicationDbContext _context;

        public TaskService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<TaskItem>>> GetAllTasksByProjectId(Guid projectId)
        {
            var response = new ServiceResponse<List<TaskItem>>();
            var findProject = await _context.Projects.FirstOrDefaultAsync(x => x.ProjectId == projectId);
            var tasks = await _context.Tasks.Where(u => u.ProjectId == projectId).Include(x => x.AssignedTo).ToListAsync();

            if (findProject == null)
            {
                response.Success = false;
                response.Message = "Project not found.";
            }
            else if (tasks.Count < 1)
            {
                response.Success = true;
                response.Message = $"No Tasks for Project: {findProject.Number} {findProject.Name}";
            }
            else
            {
                response.Data = tasks;
                response.Message = $"Tasks found for Project: {findProject.Number} {findProject.Name}";
            }

            return response;
        }
    }
}