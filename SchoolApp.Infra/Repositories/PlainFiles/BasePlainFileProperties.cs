
using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace SchoolApp.Infra.Repositories.PlainFiles
{
    public abstract class BasePlainFileProperties
    {
        protected readonly IConfiguration _config;
        protected readonly ILogger _logger; 
        protected readonly string PlainFilePath;
        protected string ConfigFileKey { get => "JsonPath"; }

        public BasePlainFileProperties(IConfiguration config, ILogger logger)
        {
            _config = config;
            _logger = logger;
            PlainFilePath = BuildFilePath(config);
        }

        private string BuildFilePath(IConfiguration config) => 
            Path.Join(AppContext.BaseDirectory, config.GetConnectionString(ConfigFileKey));
    }
}