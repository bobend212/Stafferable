using Stafferable.Shared;
using Stafferable.Shared.Timesheet;

namespace Stafferable.Server.Services.Timesheet
{
    public interface ITimesheetService
    {
        Task<ServiceResponse<List<TimesheetCard>>> GetTimesheetCardsByLoggedUser(int userId);

        Task<ServiceResponse<TimesheetCard>> PostTimesheetCard(TimesheetCard model);
    }
}