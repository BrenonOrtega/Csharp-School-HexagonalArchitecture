using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using SchoolApp.Domain.Repositories.Commands;
using SchoolApp.Domain.Entities;

namespace SchoolApp.Infra.Repositories.JsonFiles.Commands
{
    public class JsonStudentCommandRepository : BaseJsonCommandRepository<Student>, IStudentCommandRepository
    {
        protected override string ConfigFileKey => "StudentFile";

        public JsonStudentCommandRepository(IConfiguration config, ILogger<JsonStudentCommandRepository> logger) 
            : base(config,logger)
        {
        }

    }
}
