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
using NpgsqlTypes;

namespace FirstDataAccess.Data.Repositories
{
    public class PgStudentRepository : IStudentAsyncRepository
    {
        private readonly string configPrefix = "Procedures:Students";
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
            var sql =  _config.GetValue<string>($"{ configPrefix }:{ nameof(GetAll)}");

            using(var connection  = _helper.GetDbConnection()) 
            {  
                var students = await connection.QueryAsync<Student>(sql, new { rowCount = rowCount, page = page });
                return new List<Student>(students);
            }
        }
 
        public async Task<Student> GetOneById(int id)
        {
            var sql = _config.GetValue<string>( $"{ configPrefix }:{ nameof(GetOneById)}" );

            using(var cnn = _helper.GetDbConnection())  
            {
                var student =  await cnn.QueryFirstAsync<Student>(sql:sql, param: new {id = id});
                return student ?? throw new DataException();
            }
        }

        public async Task<Student> GetOneByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<Student> Create(Student obj)
        {
            using (var connection = _helper.GetDbConnection())
            {
                var sql = _config.GetValue<string>($"{ configPrefix }:{ nameof(Create) }");
                var new_student = await connection.QueryFirstOrDefaultAsync<Student>(
                    sql:sql,
                    param: new { FirstName=obj.FirstName, LastName=obj.LastName, BirthDate=obj.BirthDate}
                );
                return new_student;
            }
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