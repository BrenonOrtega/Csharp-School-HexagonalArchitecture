using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolApp.Infra.Repositories.Shared
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<T> GetOneById(int id);
        Task<T> GetOneByName(string name);
        Task<IEnumerable<T>> GetAll(int page, int rowCount);
        Task<T> Create(T obj);
        Task Delete(T obj);
        Task Update(T obj);
    }
}