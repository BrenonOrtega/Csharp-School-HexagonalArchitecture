using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using SchoolApp.Infra.Extensions;
using SchoolApp.Domain.Entities;

namespace SchoolApp.Infra.Repositories.JsonFiles
{
    public abstract class BaseJsonFilesProperties<T>
    {
        protected readonly IConfiguration _config;
        protected readonly ILogger _logger; 
        protected readonly string JsonFilePath;
        protected abstract string ConfigFileKey { get; }

        private readonly JsonSerializerOptions _baseJsonOptions;
        protected virtual JsonSerializerOptions JsonOptions=> _baseJsonOptions;

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
            var entries = JsonSerializer.Deserialize<IEnumerable<T>>(jsonFile, JsonOptions);
            return entries;
        }

        protected async Task Execute(
            Func<Student, Task<string>> command,
            Student student)
        {
            var newContent = await command.Invoke(student);
            await File.WriteAllTextAsync(JsonFilePath, newContent);
        }
    }
}