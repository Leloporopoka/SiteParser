using Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Syncfusion.Blazor;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");
            var services = builder.Services;

            services.AddTransient(sp => new HttpClient {
                BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            services.AddSingleton<NewsService>();
            services.AddSyncfusionBlazor();
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mzg3MjU0QDMxMzgyZTM0MmUzMGY1RCtqenJzVXZlZzlwZUF5ZnRXMGM5cVg0OVhjdzF0RzhxTnZrS0JiY0k9");

            await builder.Build().RunAsync();
        }
    }
}
