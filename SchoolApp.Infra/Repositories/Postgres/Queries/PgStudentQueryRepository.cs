using Dapper;
using System.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using SchoolApp.Infra.Helpers.Connections;
using SchoolApp.Domain.Repositories.Queries;
using SchoolApp.Domain.ValueObjects;
using SchoolApp.Domain.Entities;

namespace SchoolApp.Infra.Repositories.Postgres.Queries
{
    public class PgStudentQueryRepository : BaseDbRepository, IStudentQueryRepository
    {
        protected override string ConnectionConfigName { get => "postgres"; }
        protected override string ProcedureConfigurationPath => "Procedures:Students:";

        public PgStudentQueryRepository(IConfiguration config, BaseConnectionHelper helper)
            :base (config, helper)
        {
        }


        public async Task<IEnumerable<Student>> GetAll(int page=1, int rowCount=2)
        {
            var sql =  _config.GetValue<string>(ProcedureConfigurationPath + nameof(GetAll));

            using var connection = _helper.GetConnection(_connectionString);
            var students = await connection.QueryAsync<Student>(sql, new { rowCount,  page });
            return new List<Student>(students);   
        }
 
        public async Task<Student> GetById(int id)
        {
            var sql = _config.GetValue<string>(ProcedureConfigurationPath + nameof(GetById));

            using var cnn = _helper.GetConnection(_connectionString);
            var student =  await cnn.QueryFirstAsync<Student>(sql:sql, param: new { id });
            return student ?? throw new DataException();       
        }

        public async Task<IEnumerable<Student>> GetByName(Name name)
        {
            var sql = $"SELECT * FROM public.aluno a WHERE a.primeiro_nome ILIKE @name OR a.ultimo_nome ILIKE @name";
            using var cnn = _helper.GetConnection(_connectionString);
            var student = await cnn.QueryAsync<Student>(sql: sql, param: new { name = (string) name });
            return student;
        }
    }
}