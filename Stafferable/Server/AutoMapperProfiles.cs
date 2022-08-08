using Stafferable.Shared.Auth;

namespace Stafferable.Server
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserGet>();
            CreateMap<Project, ProjectPostDTO>();
            CreateMap<Project, ProjectGet>();
            CreateMap<TaskItemUpdateDTO, TaskItem>();
            CreateMap<TaskItem, TaskItemGet>();
        }
    }
}
