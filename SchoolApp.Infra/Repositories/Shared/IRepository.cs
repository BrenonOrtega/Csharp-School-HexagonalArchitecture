using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolApp.Infra.Repositories.Shared
{
    public interface IRepository<T> where T : class
    {
        T FindById(int id);
        T FindByName(string name);
        IEnumerable<T> GetAll(int page, int rowCount);
        T Create(T obj);
        void Delete(T obj);
        void Update(T obj);
    }
}