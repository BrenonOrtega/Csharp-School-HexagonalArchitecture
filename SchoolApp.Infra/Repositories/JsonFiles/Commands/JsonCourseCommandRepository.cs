using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SchoolApp.Domain.Entities;
using SchoolApp.Domain.Repositories.Commands;

namespace SchoolApp.Infra.Repositories.JsonFiles.Commands
{
    public class JsonCourseCommandRepository : BaseJsonCommandRepository<Course>, ICourseCommandRepository
    {
        protected override string ConfigFileKey => "CourseFile";

        public JsonCourseCommandRepository(IConfiguration config, ILogger<JsonCourseCommandRepository> logger) : base(config, logger)
        {
        }

    }
}