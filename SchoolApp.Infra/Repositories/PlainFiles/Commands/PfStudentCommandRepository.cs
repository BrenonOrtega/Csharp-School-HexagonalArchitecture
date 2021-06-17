using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using SchoolApp.Domain.Entities;
using SchoolApp.Domain.Repositories.Commands;
using Microsoft.Extensions.Logging;
using System.Runtime.Serialization.Json;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Immutable;

namespace SchoolApp.Infra.Repositories.PlainFiles.Commands
{
    public class PfStudentCommandRepository : BasePlainFileProperties, IStudentCommandRepository
    {
        public PfStudentCommandRepository(IConfiguration config, ILogger<PfStudentCommandRepository> logger) 
            : base(config,logger)
        {
        }
        public Task Delete(Student entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task Save(Student entity)
        {
            entity.Id = entity.Id.Equals(0) ? entity.Id : RandomNumberGenerator.GetInt32(0,99999);
            var jsonSerializerOptions = new JsonSerializerOptions { WriteIndented = true, AllowTrailingCommas = true, };
            var jsonString = JsonSerializer.Serialize(entity, jsonSerializerOptions);
            AppendToFile(jsonString);

        }

        public Task Update(Student entity)
        {
            throw new System.NotImplementedException();
        }

        private async void AppendToFile(string appendString) 
        {
            string[] fileLines = await File.ReadAllLinesAsync(PlainFilePath);
            string[] endingLines = { "," , "]" };
            await File.WriteAllLinesAsync(PlainFilePath, fileLines.Where(x => x != fileLines.Last()).ToArray());
            await File.AppendAllTextAsync(PlainFilePath, appendString); 
            await File.AppendAllLinesAsync(PlainFilePath, endingLines);
        }
    }
}
