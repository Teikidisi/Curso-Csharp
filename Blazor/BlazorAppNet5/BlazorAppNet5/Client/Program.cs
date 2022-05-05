using BlazorAppNet5.Client.Services.Abstractions;
using BlazorAppNet5.Client.Services.Implementations;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAppNet5.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            
            ConfigureServices(builder.Services);

            await builder.Build().RunAsync();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ServicesSingleton>();
            services.AddTransient<ServicesTransient>();
            services.AddScoped<IMovieApi, MovieApi>();
            services.AddScoped<IGenreAPI, GenreAPI>();
            services.AddScoped<IActorAPI, ActorAPI>();
        }
    }
}
