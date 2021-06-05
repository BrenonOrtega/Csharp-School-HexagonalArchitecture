using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using FirstDataAccess.Helpers;
using FirstDataAccess.Data.Models;
using FirstDataAccess.Data.Repositories.Interfaces;
using Dapper;
using System;
using System.Threading.Tasks;

namespace FirstDataAccess.Data.Repositories
{
    public class PgStudentRepository : IStudentRepository
    {
        private IConnectionHelper _helper;
        private readonly ILogger<PgStudentRepository> _logger;

        public PgStudentRepository(IConnectionHelper helper, ILogger<PgStudentRepository> logger)
        {
            _helper = helper;
            _logger = logger;
        }   

        public async Task<IEnumerable<Student>> GetAll(int page=1, int rowCount=10)
        {
            using(var connection = _helper.GetDbConnection()) { 
                var students = connection.Query<Student>(@" SELECT  id AS Id, 
                                                                    primeiro_nome AS FirstName,
                                                                    ultimo_nome AS LastName,
                                                                    data_nascimento AS BirthDate 
                                                            FROM public.aluno"
                                                            );
                foreach (var student in students) {
                    _logger.LogInformation("{studentItem}", student);  
                }
                return new List<Student>(students);
            }
        }
 
        public async Task<Student> FindById(int id)
        {
            using(var cnn = _helper.GetDbConnection())
            {
                var student = await cnn.QueryFirstAsync<Student>($@"SELECT  id as Id,
                                                                            primeiro_nome as FirstName,
                                                                            ultimo_nome as LastName,
                                                                            data_nascimento as BirthData
                                                                    FROM    public.aluno 
                                                                    WHERE   Id = @Id;", new {Id = id});
                return student ?? throw new Exception();
            }
        }

        public async Task<Student> FindByName(string name)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Student> Create(Student obj)
        {
            var student = new Student();
            return await new Task<Student>(() => student);
        }

        public Task Delete(Student obj)
        {
            throw new NotImplementedException();
        }

        public Task Update(Student obj)
        {
            throw new NotImplementedException();
        }

        
    }
}