namespace Stafferable.Server.Services.ProjectService
{
    public class ProjectService : IProjectService
    {
        private readonly ApplicationDbContext _context;

        public ProjectService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<Project>>> GetAllProjects()
        {
            var projects = await _context.Projects.Include(x => x.Tasks).ToListAsync();

            var response = new ServiceResponse<List<Project>>()
            {
                Data = projects
            };

            return response;
        }

        public async Task<ServiceResponse<Project>> GetSingleProject(Guid projectId)
        {
            var response = new ServiceResponse<Project>();
            var project = await _context.Projects.FirstOrDefaultAsync(x => x.ProjectId == projectId);

            if (project == null)
            {
                response.Success = false;
                response.Message = "Project does not exist.";
            }
            else
            {
                response.Data = project;
            }

            return response;
        }

        public async Task<ServiceResponse<Project>> PostProject(ProjectPostDTO model)
        {
            var newProject = new Project
            {
                Number = (int)model.Number,
                Name = model.Name,
                Status = model.Status
            };

            _context.Projects.Add(newProject);
            await _context.SaveChangesAsync();

            return new ServiceResponse<Project> { Data = newProject, Message = "New Project added!" };
        }

        public async Task<ServiceResponse<bool>> DeleteProject(Guid projectId)
        {
            var findProject = await _context.Projects.FindAsync(projectId);
            if (findProject == null)
            {
                return new ServiceResponse<bool>()
                {
                    Success = false,
                    Data = false,
                    Message = "Project not found."
                };
            }

            _context.Projects.Remove(findProject);
            await _context.SaveChangesAsync();

            return new ServiceResponse<bool> { Message = "Project Deleted", Data = true };
        }

        public async Task<ServiceResponse<bool>> UpdateProject(Project model)
        {
            var findProject = await _context.Projects.FindAsync(model.ProjectId);
            if (findProject == null)
            {
                return new ServiceResponse<bool>()
                {
                    Success = false,
                    Message = "Project not found."
                };
            }

            findProject.Number = model.Number;
            findProject.Name = model.Name;
            findProject.Status = model.Status;
            findProject.DateEdited = DateTime.Now;

            await _context.SaveChangesAsync();

            return new ServiceResponse<bool> { Message = "Project Updated!", Data = true };
        }
    }
}