using Blazored.Modal;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Presentacion.Helpers;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Presentacion
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddScoped(sp => new ServiciosRest(new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) }));
            builder.Services.AddBlazoredModal();
            await builder.Build().RunAsync();
        }
    }
}
