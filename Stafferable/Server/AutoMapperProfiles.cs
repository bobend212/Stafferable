using Stafferable.Shared.Auth;

namespace Stafferable.Server
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserGet>();
            CreateMap<Project, ProjectPostDTO>();
        }
    }
}
