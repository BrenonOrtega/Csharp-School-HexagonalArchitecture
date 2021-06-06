using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using FirstDataAccess.Data.Repositories.Interfaces;
using System.Collections.Generic;
using System;
using Microsoft.VisualBasic;

namespace FirstDataAccess.Controllers
{
    public class AppMenu
    {
        private IConfiguration _config;
        private ILogger<AppMenu> _logger;
        private IStudentRepository _studentRepository;
        private string name => nameof(AppMenu);

        public AppMenu(IConfiguration config, ILogger<AppMenu> logger, IStudentRepository studentRepository)
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
            _logger.LogInformation(greet);
        }    

        private void NavigationOptions() 
        {
            var options = getConfigs(nameof(NavigationOptions)).Get<List<string>>();

            for(var index=0; index < options.Count; index++)
            {
                _logger.LogInformation("{optionIndex}-{optionName}",index, options[index]);
            }
            /* _logger.LogInformation("Select an option:");
            _logger.LogInformation("{optionNumber} - {optionName}"); */
        }

        private IConfigurationSection getConfigs(string funcName) => _config.GetSection($"{ name }:{ funcName }");
    }
}