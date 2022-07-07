using Stafferable.Shared;
using Stafferable.Shared.Auth;

namespace Stafferable.Server.Services.Auth
{
    public interface IAuthService
    {
        Task<ServiceResponse<int>> Register(User user, string password);

        Task<bool> UserExist(string email);

        Task<ServiceResponse<string>> Login(string email, string password);
    }
}