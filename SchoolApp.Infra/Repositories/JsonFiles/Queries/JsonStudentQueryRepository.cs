using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using SchoolApp.Domain.Repositories.Queries;
using SchoolApp.Domain.ValueObjects;
using SchoolApp.Domain.Entities;

namespace SchoolApp.Infra.Repositories.JsonFiles.Queries
{
    public class JsonStudentQueryRepository : BaseJsonFilesProperties, IStudentQueryRepository
    {
        public JsonStudentQueryRepository(IConfiguration config, ILogger<JsonStudentQueryRepository> logger) 
            : base(config, logger)
        {
        }

        public async Task<IEnumerable<Student>> GetAll(int page, int rowCount)
        {
            var students = await Load();
            return students;
        }

        public async Task<Student> GetById(int id)
        {
            var allStudents = await Load();
            return allStudents.SingleOrDefault(x => x.Id == id);
        }

        public Task<Student> GetByName(Name name)
        {
            throw new NotImplementedException();
        }

        private async Task<IEnumerable<Student>> Load()
        {
            var jsonFile = await File.ReadAllTextAsync(PlainFilePath);
            var students = JsonSerializer.Deserialize<IEnumerable<Student>>(jsonFile, JsonOptions);
            return students;
        }
    }
}