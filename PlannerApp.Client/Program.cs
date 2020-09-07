using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using PlannerApp.Shared.Services;
using BlazorStrap;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Tewr.Blazor.FileReader;
using Microsoft.Extensions.Options;

namespace PlannerApp.Client
{
    public class Program
    {
        private const string URL = "https://plannerappserver20200228091432.azurewebsites.net";
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");
            builder.Services.AddScoped<AuthenticationService>(s =>
            {
                return new AuthenticationService(URL);
            });
            builder.Services.AddScoped<PlansService>(s =>
            {
                return new PlansService(URL);
            });
            builder.Services.AddScoped<ToDoItemsService>(s =>
            {
                return new ToDoItemsService(URL);
            });
            builder.Services.AddFileReaderService(Options =>
            {
                Options.UseWasmSharedBuffer = true;
            });
            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddBootstrapCss();
            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<AuthenticationStateProvider, LocalAuthenticationStateProvider>();
            await builder.Build().RunAsync();
        }
    }
}
