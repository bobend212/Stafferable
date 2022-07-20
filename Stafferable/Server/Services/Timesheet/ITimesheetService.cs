using Stafferable.Shared;
using Stafferable.Shared.Timesheet;

namespace Stafferable.Server.Services.Timesheet
{
    public interface ITimesheetService
    {
        //Cards
        Task<ServiceResponse<List<TimesheetCard>>> GetTimesheetCardsByLoggedUser(int userId);

        Task<ServiceResponse<TimesheetCard>> GetSingleCard(Guid cardId);

        Task<ServiceResponse<TimesheetCard>> PostTimesheetCard(TimesheetCard model);

        Task<ServiceResponse<bool>> DeleteTimesheetCard(Guid cardId);

        // Records
        Task<ServiceResponse<List<TimesheetRecord>>> GetTimesheetRecordsByCard(Guid CardId);

        Task<ServiceResponse<TimesheetRecord>> PostTimesheetRecord(TimesheetRecord model);
    }
}