using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using SchoolApp.Domain.Entities.Shared;
using SchoolApp.Domain.Repositories.Shared;

namespace SchoolApp.Infra.Repositories.JsonFiles.Commands
{
    public abstract class BaseJsonCommandRepository<T> : JsonRepositoryProperties<T>, ICommandRepository<T> where T: BaseEntity
    {
        protected BaseJsonCommandRepository(IConfiguration config, ILogger logger) : base(config, logger)
        {
        }

        public async Task Update(T entity)
        {
            entity.ModifiedAt = DateTime.Now;
            await Task.WhenAll(Delete(entity), Save(entity));
        }
        public async Task Save(T entity)
        {
            entity.Id = entity.Id != 0 ? entity.Id : RandomNumberGenerator.GetInt32(0,99999);
            await Execute(InsertEntity, entity);
        }

        protected virtual async Task<string> InsertEntity(T entity)
        {
            var allEntities = await GetEntries();
            allEntities = allEntities.Append(entity);
            return JsonSerializer.Serialize(allEntities, BaseJsonOptions);
        }

        public async Task Delete(T entity) => 
            await Execute(RemoveEntity, entity);

        protected virtual async Task<string> RemoveEntity(T entityToRemove)
        {
            var allEntities = await GetEntries();
            var filteredEntities = allEntities.Where(student => student.Id != entityToRemove.Id);
            var serializedEntities = JsonSerializer.Serialize(filteredEntities, BaseJsonOptions);
            return serializedEntities;
        }

        protected virtual async Task Execute(Func<T, Task<string>> command, T student)
        {
            var newContent = await command.Invoke(student);
            await File.WriteAllTextAsync(JsonFilePath, newContent);
        }
    }
}