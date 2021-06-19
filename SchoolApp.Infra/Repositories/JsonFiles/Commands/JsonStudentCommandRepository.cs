using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using SchoolApp.Domain.Repositories.Commands;
using SchoolApp.Domain.Entities;
using System.Security.Cryptography;


namespace SchoolApp.Infra.Repositories.JsonFiles.Commands
{
    public class JsonStudentCommandRepository : BaseJsonFilesProperties<Student>, IStudentCommandRepository
    {
        public JsonStudentCommandRepository(IConfiguration config, ILogger<JsonStudentCommandRepository> logger) 
            : base(config,logger)
        {
        }

        protected override string ConfigFileKey => "StudentFile";

        public async Task Delete(Student entity)
        {
            await Execute(RemoveStudent, entity);
        }
        public async Task Save(Student entity)
        {
            entity.Id = entity.Id != 0 ? entity.Id : RandomNumberGenerator.GetInt32(0,99999);
            await Execute(InsertStudent, entity);
        }

        public async Task Update(Student entity)
        {
            entity.ModifiedAt = DateTime.Now;
            Task.WaitAll(
                Delete(entity),
                Save(entity)
            );
        }

        private async Task<string> InsertStudent(Student student)
        {
            var allStudents = await GetEntries();
            allStudents = allStudents.Append(student);
            return JsonSerializer.Serialize(allStudents, JsonOptions);
        }

        private async Task<string> RemoveStudent(Student studentToRemove)
        {
            var allStudents = await GetEntries();
            var filteredStudents = allStudents.Where(student => student.Id != studentToRemove.Id);
            var serializedStudents = JsonSerializer.Serialize(filteredStudents, JsonOptions);
            return serializedStudents;
        }
    }
}
