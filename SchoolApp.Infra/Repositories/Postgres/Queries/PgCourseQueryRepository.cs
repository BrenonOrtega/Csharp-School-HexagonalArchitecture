using Dapper;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using SchoolApp.Infra.Repositories;
using SchoolApp.Infra.Helpers.Connections;
using SchoolApp.Domain.Repositories.Queries;
using SchoolApp.Domain.Entities;
using SchoolApp.Domain.ValueObjects;
using System;

namespace SchoolApp.Services.Repositories.Async
{
    public class PgCourseQueryRepository : BaseDbRepository, ICourseQueryRepository
    {
        protected override string ConnectionConfigName => "postgres";

        protected override string ProcedureConfigurationPath => "Procedures:Courses:";

        public PgCourseQueryRepository(IConfiguration config, BaseConnectionHelper helper) 
            : base(config: config, helper: helper) {
            
        }

        public Task<IEnumerable<Course>> GetAll(int page, int rowCount)
        {
            var sql = "SELECT * FROM public.curso";
            using var cnn = _helper.GetConnection(_connectionString);
            
            var courses = cnn.QueryAsync<Course>(sql);
            return courses;      
        }

        public Task<Course> GetById(int id)
        {
            var sql = "SELECT * FROM public.curso WHERE curso.id=@id";
            using var cnn = _helper.GetConnection(_connectionString);
            
            var course = cnn.QueryFirstOrDefaultAsync<Course>(sql: sql, param: new { id });
            return course;
        }

        public Task<Course> GetByName(Name name)
        {
            throw new NotImplementedException();
        }

    }
}