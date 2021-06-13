using Serilog;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolApp.Services.Helpers.Connections;
using SchoolApp.Services.Repositories.Async;
using SchoolApp.Infra.Repositories.Async;

namespace SchoolApp.Services
{
    class Program
    {
        
        static void Main(string[] args)
        {
            IConfiguration configuration;
            string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            configuration = new ConfigurationBuilder()
                        .SetBasePath(AppContext.BaseDirectory)
                        .AddJsonFile("appsettings.json", optional:false, reloadOnChange: true)
                        .AddJsonFile(@$"appsettings.{ environment ?? "Production" }.json", optional: true, reloadOnChange:true)
                        .AddEnvironmentVariables()
                        .Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();

            IHost host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) => {
                    services.AddTransient<BaseConnectionHelper, PgsqlConnectionHelper>();
                    services.AddTransient<IStudentAsyncRepository, PgStudentAsyncRepository>();
                    services.AddTransient<ICourseAsyncRepository, PgCourseAsyncRepository>();
                })  
                .UseSerilog()
                .Build();

            #region Trying out repository async implementation
            
            var repository = ActivatorUtilities.CreateInstance<PgStudentAsyncRepository>(host.Services);
            Task.Run(async () =>{
                var student = await repository.GetOneById(1);
                Log.Logger.Information("student:{student}", student);

                student = await repository.Create(new() { FirstName="Peter", LastName="Parker", BirthDate=DateTime.UtcNow });
                Log.Logger.Information("Created Student {student}", student);
            }).Wait();
            #endregion
              
        }
    }
}
