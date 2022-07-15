using Stafferable.Shared;
using Stafferable.Shared.Timesheet;
using System.Net.Http.Json;

namespace Stafferable.Client.Services.Timesheet
{
    public class TimesheetCardServiceClient : ITimesheetCardServiceClient
    {
        private readonly HttpClient _http;

        public TimesheetCardServiceClient(HttpClient http)
        {
            _http = http;
        }

        public async Task<ServiceResponse<List<TimesheetCard>>> GetTimesheetCardsByLoggedUser()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<TimesheetCard>>>($"/api/Timesheet/my-timesheets");
            return result;
        }
        public async Task<ServiceResponse<TimesheetCard>> GetSingleCard(Guid cardId)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<TimesheetCard>>($"/api/Timesheet/card/{cardId}");
            return result;
        }

        public async Task<ServiceResponse<TimesheetCard>> PostTimesheetCard(TimesheetCardPost request)
        {
            var result = await _http.PostAsJsonAsync("api/Timesheet/post-timesheet-card", request);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<TimesheetCard>>();
        }

        public async Task<ServiceResponse<List<TimesheetRecord>>> GetTimesheetRecordsByCard(Guid cardId)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<TimesheetRecord>>>($"/api/Timesheet/{cardId}/records");
            return result;
        }
    }
}