using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using SchoolApp.Infra.Extensions;

namespace SchoolApp.Infra.Repositories.JsonFiles
{
    public abstract class BaseJsonFilesProperties<T>
    {
        protected readonly IConfiguration _config;
        protected readonly ILogger _logger; 
        protected readonly string JsonFilePath;
        private readonly JsonSerializerOptions _baseJsonOptions;
        
        protected virtual JsonSerializerOptions BaseJsonOptions{ get => _baseJsonOptions; } 
        protected abstract string ConfigFileKey { get; }

        protected BaseJsonFilesProperties(IConfiguration config, ILogger logger)
        {
            _config = config;
            _logger = logger;
            _baseJsonOptions = new JsonSerializerOptions().SetupValueObjects();
            JsonFilePath = BuildFilePath(config);
        }

        private string BuildFilePath(IConfiguration config) => 
            Path.Join(AppContext.BaseDirectory, config.GetConnectionString(ConfigFileKey));   

        protected async Task<IEnumerable<T>> GetEntries()
        {
            var jsonFile = await File.ReadAllTextAsync(JsonFilePath);
            var entries = JsonSerializer.Deserialize<IEnumerable<T>>(jsonFile, BaseJsonOptions);
            return entries;
        }
    }
}