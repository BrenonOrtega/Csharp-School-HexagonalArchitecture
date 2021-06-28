using Serilog;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolApp.Application.Services;
using SchoolApp.Application.Demo;
using SchoolApp.Infra.Extensions;
using SchoolApp.Application.Services.Course;

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
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile(@$"appsettings.{ environment ?? "Production" }.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();

            IHost host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                    services.AddScoped<IStudentService, StudentService>()
                        .SetupJsonFilesRepositories())
                .UseSerilog()
                .Build();

            ///<Summary> Testing out directly retrieving and saving a student with the dependency injection container.</Summary>    
            IStudentService studentService = ActivatorUtilities.CreateInstance<StudentService>(host.Services);
            ICourseService courseService = ActivatorUtilities.CreateInstance<CourseService>(host.Services);

            Task.Run(async () =>
            {
                await StudentServiceDemo.Run(studentService);

                await CourseServiceDemo.Run(courseService);
            }).Wait();
        }
    }
}
