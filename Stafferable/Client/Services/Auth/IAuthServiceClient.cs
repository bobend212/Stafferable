using Stafferable.Shared;

namespace Stafferable.Client.Services.Auth
{
    public interface IAuthServiceClient
    {
        Task<ServiceResponse<int>> Register(UserRegister request);
    }
}