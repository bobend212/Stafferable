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
    }
}