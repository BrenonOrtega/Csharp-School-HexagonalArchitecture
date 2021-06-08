using Serilog;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using firstDataAccess.Demo;
using FirstDataAccess.Helpers;
using FirstDataAccess.Extensions;
using FirstDataAccess.Controllers;
using FirstDataAccess.Data.Repositories;
using FirstDataAccess.Data.Repositories.Interfaces.Async;

namespace FirstDataAccess
{
    class Program
    {
        static void Main(string[] args)
        {
        #region Configuration

            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            IConfigurationBuilder builder = new ConfigurationBuilder();
            IConfiguration configuration = builder.SetupConfig(environment).Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();

            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) => {
                    services.AddTransient<IGreeter, Greeter>();
                    services.AddTransient<IConnectionHelper, PgsqlConnectionHelper>();
                    services.AddTransient<IStudentAsyncRepository, PgStudentRepository>();
                })
                .UseSerilog()
                .Build();

            Log.Logger.Information("Application started. Running in {env} environment.", environment);
        #endregion

        #region Initial Demo enumerating based on configuration definition
            var greeter = ActivatorUtilities.CreateInstance<Greeter>(host.Services);
            greeter.EnumerateFromAppSettings();
        #endregion

        #region Trying out repository async implementation
            var repository = ActivatorUtilities.CreateInstance<PgStudentRepository>(host.Services);
            Task.Run(
                async () =>{
                    var student = await repository.GetOneById(1);
                    Log.Logger.Information("student:{student}", student);

                    greeter.Greet(await repository.GetAll());

                    student = await repository.Create(new() { FirstName="Peter", LastName="Parker", BirthDate=DateTime.UtcNow });
                    Log.Logger.Information("Created Student {student}", student);
            }).Wait();
        #endregion

        #region App start
            var app = ActivatorUtilities.CreateInstance<AppMenu>(host.Services);
            app.Start();
        #endregion

        }

    }
}
