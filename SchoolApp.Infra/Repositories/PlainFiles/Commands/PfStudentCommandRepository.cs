using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using SchoolApp.Domain.Entities;
using SchoolApp.Domain.Repositories.Commands;
using Microsoft.Extensions.Logging;

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

        public Task Save(Student entity)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(Student entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
