using Serilog;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using firstDataAccess.Demo;
using FirstDataAccess.Helpers;
using FirstDataAccess.Extensions;

namespace FirstDataAccess
{
    class Program
    {
        static void Main(string[] args)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder();
            IConfiguration configuration = builder.BuildConfig().Build();
            
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();

            Log.Logger.Information("Application started");

            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) => {
                    services.AddTransient<IGreeter, Greeter>();
                    services.AddTransient<IConnectionHelper, PgsqlConnectionHelper>();
                })
                .UseSerilog()
                .Build();

            var greeter = ActivatorUtilities.CreateInstance<Greeter>(host.Services);
            greeter.EnumerateFromAppSettings();

        }

    }
}
