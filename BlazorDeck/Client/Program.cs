using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorDeck.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddScoped<Services.ActionRouter>();
            builder.Services.AddScoped<Services.ActionRunners.APIActionRunner>();
            builder.Services.AddScoped<Services.ServerEventHandlers.ServerEventManager>();
            builder.Services.AddScoped<Services.ServerEventHandlers.ActiveWindowEventHandler>();
            builder.Services.AddScoped<Services.ActionRunners.NavActionRunner>();
            builder.Services.AddScoped<Services.BlazorTimer>();
            builder.Services.AddScoped<Services.ActionRunners.NativeActionRunner>();
            builder.Services.AddScoped<Services.ServerEventHandlers.AudioDeviceEventHandler>();
            builder.Services.AddScoped<Services.IdleManager>();


            await builder.Build().RunAsync();
        }
    }
}
