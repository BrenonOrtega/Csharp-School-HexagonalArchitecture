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
using System.Text.Json;
using System.IO;
using System.Linq;

namespace SchoolApp.Infra.Repositories.PlainFiles.Queries
{
    public class PfStudentQueryRepository : BasePlainFileProperties, IStudentQueryRepository
    {
        public PfStudentQueryRepository(IConfiguration config, ILogger<PfStudentQueryRepository> logger) 
            : base(config, logger)
        {
        }

        public async Task<IEnumerable<Student>> GetAll(int page, int rowCount)
        {
            var jsonFile = await File.ReadAllTextAsync(PlainFilePath);
            var students = JsonSerializer.Deserialize<IEnumerable<Student>>(
                    jsonFile, new JsonSerializerOptions { 
                        AllowTrailingCommas = true,
                        Converters = { new EmailJsonConverter(), new NameJsonConverter()}
                    });
            return students;
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