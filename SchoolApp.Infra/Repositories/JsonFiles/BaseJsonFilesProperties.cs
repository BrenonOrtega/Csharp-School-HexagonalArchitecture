using System;
using System.IO;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SchoolApp.Infra.Extensions;

namespace SchoolApp.Infra.Repositories.JsonFiles
{
    public abstract class BaseJsonFilesProperties
    {
        protected readonly IConfiguration _config;
        protected readonly ILogger _logger; 
        protected readonly string PlainFilePath;
        protected string ConfigFileKey { get => "JsonPath"; }

        private readonly JsonSerializerOptions _baseJsonOptions;
        protected virtual JsonSerializerOptions JsonOptions=> _baseJsonOptions;

        public BaseJsonFilesProperties(IConfiguration config, ILogger logger)
        {
            _config = config;
            _logger = logger;
            _baseJsonOptions = new JsonSerializerOptions().SetupValueObjects();
            PlainFilePath = BuildFilePath(config);
        }

        private string BuildFilePath(IConfiguration config) => 
            Path.Join(AppContext.BaseDirectory, config.GetConnectionString(ConfigFileKey));       
    }
}