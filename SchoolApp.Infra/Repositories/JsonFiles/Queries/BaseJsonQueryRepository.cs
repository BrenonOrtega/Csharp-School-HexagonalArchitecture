using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using SchoolApp.Domain.Repositories.Shared;
using SchoolApp.Domain.Entities.Shared;
using SchoolApp.Domain.ValueObjects;

namespace SchoolApp.Infra.Repositories.JsonFiles.Queries
{
    public abstract class BaseJsonQueryRepository<T> : JsonRepositoryProperties<T>, IQueryRepository<T> where T: BaseEntity
    {
        public BaseJsonQueryRepository(IConfiguration config, ILogger logger) : base(config, logger)
        {
        }

        public abstract Task<IEnumerable<T>> GetByName(Name name);

        public virtual async Task<IEnumerable<T>> GetAll(int page, int rowCount)
        {
            var toRetrieveCount = CountEntriesToRetrieve(rowCount);
            var queryOffset = page * toRetrieveCount;

            var enumeratedEntities = await GetEntries();
            var entityList = enumeratedEntities.ToList();

            var queriedEntities =  GetPaginatedEntries(entityList, queryOffset, toRetrieveCount);
            return queriedEntities;
        }

        private int CountEntriesToRetrieve(int rowCount)
        {
            const int StandardRetrievesCount = 20;
            var toRetrieveCount = rowCount > 0 ? rowCount : StandardRetrievesCount;
            return toRetrieveCount;
        }

        private IEnumerable<T> GetPaginatedEntries(IList<T> entityList, int queryOffset, int toRetrieveCount)
        {
            var paginatedEntries = entityList
                .Where(entity => entityList.IndexOf(entity) >= queryOffset)
                .Take(toRetrieveCount);
            return paginatedEntries;
        }

        public virtual async Task<T> GetById(int id)
        {
            var enumeratedEntities = await GetEntries();
            var queried = enumeratedEntities.SingleOrDefault(x => x.Id == id);
            return queried ?? throw new KeyNotFoundException($"Id { id } does not exist in storage.");
        }
    }
}