using System.Collections.Generic;
using System.Threading.Tasks;
using SchoolApp.Domain.ValueObjects;

namespace SchoolApp.Domain.Repositories.Shared
{
    public interface IQueryRepository<T> where T : class
    {
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetByName(Name name);
        Task<IEnumerable<T>> GetAll(int page, int rowCount);
        
    }
}