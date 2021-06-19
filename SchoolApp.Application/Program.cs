using Serilog;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolApp.Infra.Extensions;
using SchoolApp.Infra.Helpers.Connections;
using SchoolApp.Application.Services;
using SchoolApp.Application.Dtos.CreateDtos;

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
                .ConfigureServices(
                    (context, services) =>  
                        services.AddTransient<BaseConnectionHelper, PgsqlConnectionHelper>()
                            .AddScoped<IStudentService, StudentService>()
                            .SetupJsonFilesRepositories())
                .UseSerilog()
                .Build();

            ///<Summary> Testing out directly retrieving and saving a student with the dependency injection container.</Summary>    
            IStudentService studentService = ActivatorUtilities.CreateInstance<StudentService>(host.Services);

            Task.Run(async () => {
                
                var allstudents =  await studentService.RetrieveMultiple(1, 100);
                allstudents.ToList().ForEach(x => Log.Logger.Information("{student}",x));

                var newStudent = new StudentCreateDto { LastName = "Test", FirstName = "Json", BirthDate = DateTime.Now, Email = "bryan.test@hotmail.com" };
                await studentService.Create(newStudent);
                Log.Logger.Information("Student: {Student}", newStudent);

                var studentUpdate = new StudentCreateDto { LastName="updated", FirstName="test", Id=40878, BirthDate= DateTime.Now, Email="TestUpdate@testemail.com.br" };
                await studentService.Update(studentUpdate);
            }).Wait();

        }
    }
}
