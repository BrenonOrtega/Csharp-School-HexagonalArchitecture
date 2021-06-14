using Serilog;
using System;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolApp.ConsoleUI.Demo;
using SchoolApp.ConsoleUI.Extensions;
using SchoolApp.ConsoleUI.Controllers;

namespace SchoolApp.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            /// Configuration
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            IConfigurationBuilder builder = new ConfigurationBuilder();
            IConfiguration configuration = builder.SetupConfig(environment).Build();

            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) => {
                    services.AddTransient<IGreeter, Greeter>();                
                })
                .UseSerilog()
                .Build();

            Log.Logger.Information("Application started. Running in {env} environment.", environment);


        /// Initial Demo enumerating based on configuration definition
            var greeter = ActivatorUtilities.CreateInstance<Greeter>(host.Services);
            greeter.EnumerateFromAppSettings();


        ///<Summary>  App start </Summary>
            var app = ActivatorUtilities.CreateInstance<AppMenu>(host.Services);
            app.Start();
        }

    }
}
