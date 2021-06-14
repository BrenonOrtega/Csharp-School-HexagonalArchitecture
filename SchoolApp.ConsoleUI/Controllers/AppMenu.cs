using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using SchoolApp.Domain.Repositories.Queries;

namespace SchoolApp.ConsoleUI.Controllers
{
    public class AppMenu
    {
        private readonly IConfiguration _config;
        private readonly ILogger<AppMenu> _logger;
        private readonly IStudentQueryRepository _studentRepository;

        public AppMenu(IConfiguration config, ILogger<AppMenu> logger, IStudentQueryRepository studentRepository)
        {
            _config = config;
            _logger = logger;
            _studentRepository = studentRepository;
        }
        
        private IConfigurationSection GetConfigs(string funcName) => _config.GetSection($"{ nameof(AppMenu) }:{ funcName }");

        public void Start()
        {
            InitialGreet();
            NavigationOptions();
            System.Console.ReadKey();
        }

        private void InitialGreet()
        {
            var greet = GetConfigs(nameof(InitialGreet)).Get<string>();

            System.Console.WriteLine();
            _logger.LogInformation(greet);
            System.Console.WriteLine();
        }    

        private void NavigationOptions() 
        {
            var options = GetConfigs(nameof(NavigationOptions)).Get<List<string>>();

            _logger.LogInformation("Please select an option");

            for(var index=0; index < options.Count; index++)
                _logger.LogInformation("{optionIndex}-{optionName}",index, options[index]);
        }

    }
}