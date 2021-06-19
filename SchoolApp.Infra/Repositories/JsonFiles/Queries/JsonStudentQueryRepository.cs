using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using SchoolApp.Domain.Repositories.Queries;
using SchoolApp.Domain.ValueObjects;
using SchoolApp.Domain.Entities;

namespace SchoolApp.Infra.Repositories.JsonFiles.Queries
{
    public class JsonStudentQueryRepository : BaseJsonFilesProperties<Student>, IStudentQueryRepository
    {
        public JsonStudentQueryRepository(IConfiguration config, ILogger<JsonStudentQueryRepository> logger) 
            : base(config, logger)
        {
        }

        protected override string ConfigFileKey => "StudentFile";

        public async Task<IEnumerable<Student>> GetAll(int page, int rowCount)
        {
            var students = await GetEntries();
            return students;
        }

        public async Task<Student> GetById(int id)
        {
            var allStudents = await GetEntries();
            return allStudents.SingleOrDefault(x => x.Id == id);
        }

        public Task<Student> GetByName(Name name)
        {
            throw new NotImplementedException();
        }

        
    }
}