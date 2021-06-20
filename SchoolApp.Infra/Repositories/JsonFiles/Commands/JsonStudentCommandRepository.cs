using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using SchoolApp.Domain.Repositories.Commands;
using SchoolApp.Domain.Entities;

namespace SchoolApp.Infra.Repositories.JsonFiles.Commands
{
    public class JsonStudentCommandRepository : BaseJsonFilesProperties<Student>, IStudentCommandRepository
    {
        protected override string ConfigFileKey => "StudentFile";

        public JsonStudentCommandRepository(IConfiguration config, ILogger<JsonStudentCommandRepository> logger) 
            : base(config,logger)
        {
        }

        public async Task Update(Student entity)
        {
            entity.ModifiedAt = DateTime.Now;
            await Task.WhenAll(Delete(entity), Save(entity));
        }
        public async Task Save(Student entity)
        {
            entity.Id = entity.Id != 0 ? entity.Id : RandomNumberGenerator.GetInt32(0,99999);
            await Execute(InsertStudent, entity);
        }

        private async Task<string> InsertStudent(Student student)
        {
            var allStudents = await GetEntries();
            allStudents = allStudents.Append(student);
            return JsonSerializer.Serialize(allStudents, BaseJsonOptions);
        }

        public async Task Delete(Student entity)
        {
            await Execute(RemoveStudent, entity);
        }

        private async Task<string> RemoveStudent(Student studentToRemove)
        {
            var allStudents = await GetEntries();
            var filteredStudents = allStudents.Where(student => student.Id != studentToRemove.Id);
            var serializedStudents = JsonSerializer.Serialize(filteredStudents, BaseJsonOptions);
            return serializedStudents;
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
