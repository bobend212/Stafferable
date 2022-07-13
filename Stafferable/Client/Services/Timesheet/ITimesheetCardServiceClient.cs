using Stafferable.Shared;
using Stafferable.Shared.Timesheet;

namespace Stafferable.Client.Services.Timesheet
{
    public interface ITimesheetCardServiceClient
    {
        Task<ServiceResponse<List<TimesheetCard>>> GetTimesheetCardsByLoggedUser();
    }
}