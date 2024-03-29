﻿using Microsoft.AspNetCore.Authorization;
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

        [HttpGet("my-timesheets")]
        public async Task<ActionResult<ServiceResponse<List<TimesheetCard>>>> GetTimesheetCardsByLoggedUser()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var response = await _timesheetService.GetTimesheetCardsByLoggedUser(int.Parse(userId));
            return Ok(response);
        }

        [HttpPost("post-timesheet-card")]
        public async Task<ActionResult<ServiceResponse<TimesheetCard>>> PostTimesheetCard(TimesheetCardPost request)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var newTimesheetCard = new TimesheetCard
            {
                CustomName = request.CustomName,
                DateCreated = DateTime.Now,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                Status = request.Status,
                TotalHours = request.TotalHours,
                UserId = int.Parse(userId)
            };

            var response = await _timesheetService.PostTimesheetCard(newTimesheetCard);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [Authorize]
        [HttpGet("{cardId}/records")]
        public async Task<ActionResult<ServiceResponse<List<TimesheetRecord>>>> GetTimesheetRecordsByCard(Guid cardId)
        {
            var response = await _timesheetService.GetTimesheetRecordsByCard(cardId);
            return Ok(response);
        }

        [HttpGet("card/{cardId}")]
        public async Task<ActionResult<ServiceResponse<TimesheetCard>>> GetSingleCard(Guid cardId)
        {
            var response = await _timesheetService.GetSingleCard(cardId);

            if (!response.Success)
            {
                return BadRequest();
            }

            return Ok(response);
        }

        [HttpDelete("card/{cardId}")]
        public async Task<ActionResult<ServiceResponse<bool>>> DeleteTimesheetCard(Guid cardId)
        {
            var response = await _timesheetService.DeleteTimesheetCard(cardId);
            return Ok(response);
        }

        [HttpPost("post-timesheet-record")]
        public async Task<ActionResult<ServiceResponse<TimesheetRecord>>> PostTimesheetRecord(TimesheetRecordPost request)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var newTimesheetRecord = new TimesheetRecord
            {
                TimesheetCardId = request.TimesheetCardId,
                UserId = int.Parse(userId),
                Date = request.Date,
                Type = request.Type,
                Project = request.Project,
                Time = request.Time
            };

            var response = await _timesheetService.PostTimesheetRecord(newTimesheetRecord);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpDelete("record/{recordId}")]
        public async Task<ActionResult<ServiceResponse<bool>>> DeleteTimesheetRecord(Guid recordId)
        {
            var response = await _timesheetService.DeleteTimesheetRecord(recordId);
            return Ok(response);
        }

        [HttpPut("record-update")]
        public async Task<ActionResult<ServiceResponse<bool>>> UpdateTimesheetRecord(TimesheetRecordUpdate request)
        {
            var result = await _timesheetService.UpdateTimesheetRecord(request);
            return Ok(result);
        }
    }
}