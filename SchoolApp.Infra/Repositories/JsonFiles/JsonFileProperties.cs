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
    public abstract class JsonRepositoryProperties<T>
    {
        protected readonly string JsonFilePath;
        protected readonly IConfiguration _config;
        protected readonly ILogger _logger; 
        private readonly JsonSerializerOptions _baseJsonOptions;
        
        protected virtual JsonSerializerOptions BaseJsonOptions{ get => _baseJsonOptions; } 
        protected abstract string ConfigFileKey { get; }

        protected JsonRepositoryProperties(IConfiguration config, ILogger logger)
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
            try 
            {
                var jsonFile = await File.ReadAllTextAsync(JsonFilePath);
                var entries = JsonSerializer.Deserialize<IEnumerable<T>>(jsonFile, BaseJsonOptions);
                return entries;

            } catch (JsonException) {
                HandleCorruptedJson();
                
            } catch (FileNotFoundException) { 
                HandleInexistentJsonFile();
            }
            return new List<T>();
        }


        private void HandleCorruptedJson()
        {
            string backupFileSufix = ".backup.txt";
            _logger.LogCritical("Corrupted Json format found. " + 
                $"Please verify your json files folder for the { backupFileSufix } file with the backedup content.");

            BackupJsonFile(backupFileSufix);
        }

        private void BackupJsonFile(string backupFileSufix)
        {
            var corruptedJsonContent = File.ReadAllText(JsonFilePath);
            var backupFilePath = JsonFilePath + DateTime.Now.ToString("dd/mm/yyyy hh:mm:ss") + backupFileSufix;
            File.WriteAllText(backupFilePath, corruptedJsonContent);
        }

        private void HandleInexistentJsonFile()
        {
            var expectedFilePath = Path.GetFullPath(JsonFilePath);
            var errorDescription = $"Unnable to find Json File configured at { ConfigFileKey } settings entry.";
            var actionDescription = $"Json file will be created at { expectedFilePath } alongside the request content.";

            _logger.LogError("{errorDescription}", errorDescription);
            _logger.LogInformation("{actionDescription}", actionDescription);
        }


    }
}