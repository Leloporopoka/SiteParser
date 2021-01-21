
using Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
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

            await builder.Build().RunAsync();
        }
    }
}
