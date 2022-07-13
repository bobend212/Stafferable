using Microsoft.AspNetCore.Mvc;
using Stafferable.Server.Services.Timesheet;
using Stafferable.Shared;
using Stafferable.Shared.Timesheet;
using System.Security.Claims;

namespace Stafferable.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimesheetController : ControllerBase
    {
        private readonly ITimesheetService _timesheetService;

        public TimesheetController(ITimesheetService timesheetService)
        {
            _timesheetService = timesheetService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<TimesheetCard>>>> GetTimesheetCardsByLoggedUser()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var response = await _timesheetService.GetTimesheetCardsByLoggedUser(int.Parse(userId));

            //if (!response.Success)
            //{
            //    return BadRequest();
            //}

            return Ok(response);
        }
    }
}