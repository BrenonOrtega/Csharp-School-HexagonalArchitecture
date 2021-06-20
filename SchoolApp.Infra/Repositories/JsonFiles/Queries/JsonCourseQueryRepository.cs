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
    public class JsonCourseQueryRepository : BaseJsonQueryRepository<Course>, ICourseQueryRepository
    {
        protected override string ConfigFileKey => "CourseFile";

        public JsonCourseQueryRepository(IConfiguration config, ILogger<JsonCourseQueryRepository> logger) : base(config, logger)
        {
        }

        public override async Task<IEnumerable<Course>> GetByName(Name name)
        {
            var courses = await GetEntries();
            var queriedCourses = courses.Where(course => course.Name.Equals(name));
            return queriedCourses;
        }
    }
}