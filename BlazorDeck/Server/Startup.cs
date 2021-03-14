using BlazorDeck.Server.Managers;
using BlazorDeck.Server.SystemControl;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BlazorDeck.Server.Hubs;
using System.Linq;
using BlazorDeck.Server.SystemControl.PrimaryMonitor;
using SoundSwitch.Framework.Audio.Lister;
using SoundSwitch.Audio.Manager;

namespace BlazorDeck.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllersWithViews().AddNewtonsoftJson((jsonOptions) => jsonOptions.SerializerSettings.TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto);
            services.AddRazorPages();
            services.AddSignalR();
            services.AddSingleton<VolumeControl>();
            services.AddSingleton<WindowMonitor>();
            services.AddSingleton<KeyEmulation>();
            services.AddSingleton<TileConfigManager>();
            services.AddSingleton<ServerEventManager>();
            services.AddSingleton<ProgramRunManager>();
            services.AddSingleton<DefaultAudioMonitor>();
            services.AddSingleton<PrimaryDisplayManager>();
            services.AddSingleton((context)=> new CachedAudioDeviceLister(NAudio.CoreAudioApi.DeviceState.Active));
            services.AddSingleton((context) => AudioSwitcher.Instance);
            services.AddResponseCompression(opts =>
            {
                opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
                    new[] { "application/octet-stream" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseResponseCompression();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            
            //app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
                endpoints.MapHub<ServerEventHub>("/servereventhub");
            });
        }
    }
}
