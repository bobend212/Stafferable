using Stafferable.Shared;
using Stafferable.Shared.Auth;

namespace Stafferable.Server.Services.Auth
{
    public interface IAuthService
    {
        Task<ServiceResponse<int>> Register(User user, string password);

        Task<bool> UserExist(string email);

        Task<ServiceResponse<string>> Login(string email, string password);

        Task<ServiceResponse<bool>> ChangePassword(int userId, string newPassword);

        Task<ServiceResponse<bool>> ChangeProfile(int userId, UserChangeProfile model);

        Task<ServiceResponse<User>> GetSingleUser(int userId);
    }
}