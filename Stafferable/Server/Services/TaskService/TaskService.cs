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
            ServiceResponse<List<TaskItem>> response = new ServiceResponse<List<TaskItem>>();
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

        public async Task<ServiceResponse<TaskItem>> PostTask(TaskItem model)
        {
            _context.Tasks.Add(model);
            await _context.SaveChangesAsync();

            return new ServiceResponse<TaskItem> { Data = model, Message = "New Task added!" };
        }

        public async Task<ServiceResponse<bool>> CompleteTask(TaskCompleteDTO model)
        {
            var findTask = await _context.Tasks.FindAsync(model.TaskItemId);
            if (findTask == null)
            {
                return new ServiceResponse<bool>()
                {
                    Success = false,
                    Message = "Task not found."
                };
            }

            findTask.DateEdited = DateTime.Now;
            findTask.CompleteDate = DateTime.Now;
            findTask.TaskStatus = "Done";
            findTask.IsComplete = true;
            findTask.EditorId = model.EditorId;

            _context.Entry(findTask).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return new ServiceResponse<bool> { Message = "Task Completed", Data = true };
        }

        public async Task<ServiceResponse<bool>> UpdateTask(TaskItem model)
        {
            var findTask = await _context.Tasks.FindAsync(model.TaskItemId);
            if (findTask == null)
            {
                return new ServiceResponse<bool>()
                {
                    Success = false,
                    Message = "Task not found."
                };
            }

            findTask.Title = model.Title;
            findTask.Description = model.Description;
            findTask.AssignedToId = model.AssignedToId;
            findTask.EditorId = model.EditorId;
            findTask.ProjectId = model.ProjectId;
            findTask.DeadlineDate = model.DeadlineDate;
            findTask.Priority = model.Priority;
            findTask.DateEdited = DateTime.Now;

            await _context.SaveChangesAsync();

            return new ServiceResponse<bool> { Message = "Task Updated!", Data = true };
        }

        public async Task<ServiceResponse<bool>> DeleteTask(Guid taskId)
        {
            var findTask = await _context.Tasks.FindAsync(taskId);
            if (findTask == null)
            {
                return new ServiceResponse<bool>()
                {
                    Success = false,
                    Data = false,
                    Message = "Task not found."
                };
            }

            _context.Tasks.Remove(findTask);
            await _context.SaveChangesAsync();

            return new ServiceResponse<bool> { Message = "Task Deleted", Data = true };
        }
    }
}