﻿using Stafferable.Shared;
using Stafferable.Shared.Auth;
using System.Net.Http.Json;

namespace Stafferable.Client.Services.Auth
{
    public class AuthServiceClient : IAuthServiceClient
    {
        private readonly HttpClient _http;

        public AuthServiceClient(HttpClient http)
        {
            _http = http;
        }
        public async Task<ServiceResponse<int>> Register(UserRegister request)
        {
            var result = await _http.PostAsJsonAsync("api/auth/register", request);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<int>>();
        }

        public async Task<ServiceResponse<string>> Login(UserLogin request)
        {
            var result = await _http.PostAsJsonAsync("api/auth/login", request);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<string>>();
        }

        public async Task<ServiceResponse<bool>> ChangePassword(UserChangePassword request)
        {
            var result = await _http.PostAsJsonAsync("api/auth/change-password", request.Password);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<bool>>();
        }

        public async Task<ServiceResponse<bool>> ChangeProfile(UserChangeProfile request)
        {
            var result = await _http.PostAsJsonAsync("api/auth/change-profile", request);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<bool>>();
        }

        public async Task<ServiceResponse<User>> GetSingleUser()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<User>>($"/api/Auth/single-user");
            return result;
        }

        public async Task<ServiceResponse<List<UserGet>>> GetAllUsers()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<UserGet>>>($"/api/Auth/users");
            return result;
        }
    }
}