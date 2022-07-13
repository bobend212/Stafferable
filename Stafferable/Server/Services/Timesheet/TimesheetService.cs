using Microsoft.EntityFrameworkCore;
using Stafferable.Server.Data;
using Stafferable.Shared;
using Stafferable.Shared.Timesheet;

namespace Stafferable.Server.Services.Timesheet
{
    public class TimesheetService : ITimesheetService
    {
        private readonly ApplicationDbContext _context;

        public TimesheetService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<TimesheetCard>>> GetTimesheetCardsByLoggedUser(int userId)
        {
            var response = new ServiceResponse<List<TimesheetCard>>();
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserId == userId);
            var timesheets = await _context.TimesheetCards.Where(u => u.UserId == userId).ToListAsync();

            if (user == null)
            {
                response.Success = false;
                response.Message = "User not found.";
            }
            else if (timesheets.Count < 1)
            {
                response.Success = false;
                response.Message = $"No Timesheet Cards for user {user.FName} {user.LName}";
            }
            else
            {
                response.Data = timesheets;
                response.Message = $"Timesheet Cards found for user {user.FName} {user.LName}";
            }

            return response;
        }
    }
}