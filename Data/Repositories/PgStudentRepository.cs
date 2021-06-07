using Dapper;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using FirstDataAccess.Helpers;
using FirstDataAccess.Data.Models;
using FirstDataAccess.Data.Repositories.Interfaces.Async;

namespace FirstDataAccess.Data.Repositories
{
    public class PgStudentRepository : IStudentAsyncRepository
    {
        private readonly IConnectionHelper _helper;
        private readonly ILogger<PgStudentRepository> _logger;
        private readonly IConfiguration _config;

        public PgStudentRepository(IConfiguration config, IConnectionHelper helper, ILogger<PgStudentRepository> logger)
        {
            _config = config;
            _helper = helper;
            _logger = logger;
        }   

        public async Task<IEnumerable<Student>> GetAll(int page=1, int rowCount=2)
        {
            using(var connection  = _helper.GetDbConnection()) 
            { 
                var sql =  _config.GetValue<string>("Procedures:Students:GetAll");
                var students = await connection.QueryAsync<Student>(sql, new { rowCount = rowCount, page = page });
                return new List<Student>(students);
            }
        }
 
        public async Task<Student> GetOneById(int id)
        {
            using(var cnn = _helper.GetDbConnection())  {
                var student = 
                await cnn.QueryFirstAsync<Student>(
                    sql:$@" SELECT  id as Id,
                                    primeiro_nome as FirstName,
                                    ultimo_nome as LastName,
                                    data_nascimento as BirthData
                            FROM    public.aluno 
                            WHERE   Id = @Id;",
                    param: new {Id = id}
                );

                return student ?? throw new DataException();
            }
        }

        public async Task<Student> GetOneByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<Student> Create(Student obj)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(Student obj)
        {
            throw new NotImplementedException();
        }

        public async Task Update(Student obj)
        {
            throw new NotImplementedException();
        }

        
    }
}