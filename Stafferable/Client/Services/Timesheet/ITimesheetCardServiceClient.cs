using Stafferable.Shared;
using Stafferable.Shared.Timesheet;

namespace Stafferable.Client.Services.Timesheet
{
    public interface ITimesheetCardServiceClient
    {
        //cards
        Task<ServiceResponse<List<TimesheetCard>>> GetTimesheetCardsByLoggedUser();
        Task<ServiceResponse<TimesheetCard>> PostTimesheetCard(TimesheetCardPost request);

        //records
        Task<ServiceResponse<List<TimesheetRecord>>> GetTimesheetRecordsByCard(Guid cardId);
    }
}