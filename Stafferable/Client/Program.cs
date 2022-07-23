global using Microsoft.AspNetCore.Components.Authorization;
global using Stafferable.Client.Services.Auth;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using Sotsera.Blazor.Toaster.Core.Models;
using Stafferable.Client;
using Stafferable.Client.Services.Timesheet;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddToaster(config =>
{
    config.PositionClass = Defaults.Classes.Position.BottomRight;
    config.PreventDuplicates = false;
    config.NewestOnTop = true;
});

//services
builder.Services.AddMudServices();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddScoped<IAuthServiceClient, AuthServiceClient>();
builder.Services.AddScoped<ITimesheetCardServiceClient, TimesheetCardServiceClient>();

await builder.Build().RunAsync();