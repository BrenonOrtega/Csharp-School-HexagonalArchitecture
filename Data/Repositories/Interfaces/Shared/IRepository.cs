using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FirstDataAccess.Data.Repositories.Interfaces.Shared
{
    public interface IRepository<T> where T : class
    {
        T FindById(int id);
        T FindByName(string name);
        IEnumerable<T> GetAll(int page, int rowCount);
        T Create(T obj);
        bool Delete(T obj);
        bool Update(T obj);
    }
}