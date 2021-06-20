using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using SchoolApp.Domain.Entities;
using SchoolApp.Domain.Repositories.Commands;
using SchoolApp.Domain.Repositories.Queries;
using SchoolApp.Domain.ValueObjects;
using SchoolApp.Infra.Helpers.Connections;
using SchoolApp.Infra.Helpers.Redis;
using StackExchange.Redis;

namespace SchoolApp.Infra.Repositories.Redis
{
    public class RedisStudentRepository :  IStudentQueryRepository, IStudentCommandRepository
    {
        public RedisStudentRepository(IConfiguration config, RedisMultiplexer multiplexer) 
        {
            _config = config;
            _multiplexer = multiplexer;
        }

        private readonly IConfiguration _config;
        private readonly RedisMultiplexer _multiplexer;
        public string ConnectionConfigName => "Redis";

        public string ProcedureConfigurationPath => "Procedure:Students";

        public Task<IEnumerable<Student>> GetAll(int page, int rowCount)
        {
            throw new System.NotImplementedException();
        }

        public Task<Student> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Student>> GetByName(Name name)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(Student entity)
        {
            throw new System.NotImplementedException();
        }


        public async Task Save(Student entity)
        {
            var connectionString = _config.GetConnectionString(ConnectionConfigName);
            var database = _multiplexer.GetDatabase(connectionString);
            await database.SetAddAsync(
                new RedisKey(entity.Id.ToString()), 
                new RedisValue(JsonSerializer.Serialize(entity))
            );
        }

        public Task Update(Student entity)
        {
            throw new System.NotImplementedException();
        }
    }
}