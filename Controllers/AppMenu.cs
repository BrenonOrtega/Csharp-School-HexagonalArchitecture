using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using FirstDataAccess.Data.Repositories.Interfaces.Async;

namespace FirstDataAccess.Controllers
{
    public class AppMenu
    {
        private IConfiguration _config;
        private ILogger<AppMenu> _logger;
        private IStudentAsyncRepository _studentRepository;
        private string name => nameof(AppMenu);

        public AppMenu(IConfiguration config, ILogger<AppMenu> logger, IStudentAsyncRepository studentRepository)
        {
            _config = config;
            _logger = logger;
            _studentRepository = studentRepository;
        }

        public void Start()
        {
            InitialGreet();
            NavigationOptions();
            System.Console.ReadKey();
        }

        private void InitialGreet()
        {
            var greet = getConfigs(nameof(InitialGreet)).Get<string>();

            _logger.LogInformation("*******************************");

            _logger.LogInformation(greet);
            
            _logger.LogInformation("*******************************");

        }    

        private void NavigationOptions() 
        {
            _logger.LogInformation("Please select an option");

            var options = getConfigs(nameof(NavigationOptions)).Get<List<string>>();

            for(var index=0; index < options.Count; index++)
                _logger.LogInformation("{optionIndex}-{optionName}",index, options[index]);
        }

        private IConfigurationSection getConfigs(string funcName) => _config.GetSection($"{ name }:{ funcName }");
    }
}