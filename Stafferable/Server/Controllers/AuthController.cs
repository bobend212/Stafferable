using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stafferable.Server.Services.Auth;
using Stafferable.Shared;
using Stafferable.Shared.Auth;
using System.Security.Claims;

namespace Stafferable.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public AuthController(IAuthService authService, IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(UserRegister request)
        {
            var response = await _authService.Register(new User
            {
                Email = request.Email,
                FName = request.FName,
                LName = request.LName,
                Title = request.Title,
                Phone = request.Phone,
                Department = request.Department,
            }, request.Password);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<ActionResult<ServiceResponse<string>>> Login(UserLogin request)
        {
            var response = await _authService.Login(request.Email, request.Password);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPost("change-password"), Authorize]
        public async Task<ActionResult<ServiceResponse<bool>>> ChangePassword([FromBody] string newPassword)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var response = await _authService.ChangePassword(int.Parse(userId), newPassword);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPost("change-profile"), Authorize]
        public async Task<ActionResult<ServiceResponse<bool>>> ChangeProfile(UserChangeProfile model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var response = await _authService.ChangeProfile(int.Parse(userId), model);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("single-user")]
        public async Task<ActionResult<ServiceResponse<User>>> GetSingleUser()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var response = await _authService.GetSingleUser(int.Parse(userId));

            if (!response.Success)
            {
                return BadRequest();
            }

            return Ok(response);
        }

        [HttpGet("users")]
        public async Task<ActionResult<ServiceResponse<List<User>>>> GetAllUsers()
        {
            var response = await _authService.GetAllUsers();
            return Ok(response);
        }
    }
}