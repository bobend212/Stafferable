using Stafferable.Shared;
using Stafferable.Shared.Timesheet;

namespace Stafferable.Client.Services.Timesheet
{
    public interface ITimesheetCardServiceClient
    {
        //cards
        Task<ServiceResponse<List<TimesheetCard>>> GetTimesheetCardsByLoggedUser();

        Task<ServiceResponse<TimesheetCard>> GetSingleCard(Guid cardId);

        Task<ServiceResponse<TimesheetCard>> PostTimesheetCard(TimesheetCardPost request);

        Task DeleteTimesheetCard(Guid cardId);

        //records
        Task<ServiceResponse<List<TimesheetRecord>>> GetTimesheetRecordsByCard(Guid cardId);

        Task<ServiceResponse<TimesheetRecord>> PostTimesheetRecord(TimesheetRecordPost request);

        Task DeleteTimesheetRecord(Guid recordId);

        Task UpdateTimesheetRecord(TimesheetRecord request);
    }
}