using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using SchoolApp.Domain.Repositories.Commands;
using SchoolApp.Domain.Entities;
using System.Security.Cryptography;

namespace SchoolApp.Infra.Repositories.JsonFiles.Commands
{
    public class JsonStudentCommandRepository : BaseJsonFilesProperties, IStudentCommandRepository
    {
        public JsonStudentCommandRepository(IConfiguration config, ILogger<JsonStudentCommandRepository> logger) 
            : base(config,logger)
        {
        }
        public Task Delete(Student entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task Save(Student entity)
        {
            entity.Id = entity.Id != 0 ? entity.Id : RandomNumberGenerator.GetInt32(0,99999);
            var jsonString = JsonSerializer.Serialize(entity, JsonOptions);
            await AppendToFile(jsonString);
        }

        public Task Update(Student entity)
        {
            throw new System.NotImplementedException();
        }

        private async Task AppendToFile(string appendString) 
        {
            string[] fileLines = await File.ReadAllLinesAsync(PlainFilePath);
            string[] endingLines = { "," , "]" };
            File.WriteAllLines(PlainFilePath, fileLines.Where(x => x != fileLines.Last()).ToArray());
            File.AppendAllText(PlainFilePath, appendString); 
            File.AppendAllLines(PlainFilePath, endingLines);
        }
    }
}
