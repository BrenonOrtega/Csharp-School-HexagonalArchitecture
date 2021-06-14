using Serilog;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolApp.Infra.Extensions;
using SchoolApp.Infra.Helpers.Connections;
using SchoolApp.Infra.Repositories.Postgres.Queries;
using SchoolApp.Infra.Repositories.Postgres.Commands;

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
                .ConfigureServices((context, services) =>  
                    services.AddTransient<BaseConnectionHelper, PgsqlConnectionHelper>()
                        .SetupPostgresRepositories()
                )
                .UseSerilog()
                .Build();

            ///<Summary> Testing out directly retrieving and saving a student with the dependency injection container.</Summary>    
            var queryRepository = ActivatorUtilities.CreateInstance<PgStudentQueryRepository>(host.Services);
            var commandRepository = ActivatorUtilities.CreateInstance<PgStudentCommandRepository>(host.Services);

            Task.Run(async () =>
            {
                var student = await queryRepository.GetById(1);
                Log.Logger.Information("student:{student}", student);

                await commandRepository.Save(new() { FirstName="Peter", LastName="Parker", BirthDate=DateTime.UtcNow });

                var students = await queryRepository.GetAll(1, 100);
                Log.Logger.Information("Created Student {student}",  students.Last());

            }).Wait();

        }
    }
}
