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
    public class JsonStudentQueryRepository : BaseJsonQueryRepository<Student>, IStudentQueryRepository
    {
        protected override string ConfigFileKey => "StudentFile";
        
        public JsonStudentQueryRepository(IConfiguration config, ILogger<JsonStudentQueryRepository> logger) 
            : base(config, logger)
        {
        }

        public override async Task<IEnumerable<Student>> GetByName(Name name)
        {
            var students = await GetEntries();
            var queriedStudents = students
                .Where(student => student.FirstName.Equals(name) || student.LastName.Equals(name));
            return queriedStudents;
        }
    }
}