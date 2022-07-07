using Stafferable.Shared;
using Stafferable.Shared.Auth;

namespace Stafferable.Client.Services.Auth
{
    public interface IAuthServiceClient
    {
        Task<ServiceResponse<int>> Register(UserRegister request);

        Task<ServiceResponse<string>> Login(UserLogin request);
    }
}