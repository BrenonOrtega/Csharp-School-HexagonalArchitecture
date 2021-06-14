using Dapper;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

using SchoolApp.Domain.Repositories.Queries;
using SchoolApp.Domain.Entities;
using SchoolApp.Domain.ValueObjects;

namespace SchoolApp.Infra.Repositories.PlainFiles.Queries
{
    public class PfStudentQueryRepository : BasePlainFileProperties, IStudentQueryRepository
    {
        public PfStudentQueryRepository(IConfiguration config, ILogger logger) 
            : base(config, logger)
        {
        }

        public Task<IEnumerable<Student>> GetAll(int page, int rowCount)
        {
            throw new NotImplementedException();
        }

        public Task<Student> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Student> GetByName(Name name)
        {
            throw new NotImplementedException();
        }
    }
}