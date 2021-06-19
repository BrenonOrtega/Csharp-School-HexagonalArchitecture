using Dapper;
using System.Threading.Tasks;
using SchoolApp.Domain.Entities;
using SchoolApp.Domain.Repositories.Commands;
using SchoolApp.Infra.Helpers.Connections;
using Microsoft.Extensions.Configuration;

namespace SchoolApp.Infra.Repositories.Postgres.Commands
{
    public class PgStudentCommandRepository : BaseDbRepository, IStudentCommandRepository
    {
        public PgStudentCommandRepository(IConfiguration config, BaseConnectionHelper helper) : base(config, helper)
        {
        }

        protected override string ConnectionConfigName => "postgres";

        protected override string ProcedureConfigurationPath => "Procedures:Students:";

        public async Task Save(Student entity)
        {
            var sql = _config.GetValue<string>(ProcedureConfigurationPath + nameof(Save));

            using var cnn = _helper.GetConnection(_connectionString);
            await cnn.QueryAsync(
                sql: sql, 
                param: new { FirstName = (string) entity.FirstName, 
                                LastName = (string) entity.LastName ,
                                BirthDate = entity.BirthDate }
            );
        }

        public Task Delete(Student entity)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(Student entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
