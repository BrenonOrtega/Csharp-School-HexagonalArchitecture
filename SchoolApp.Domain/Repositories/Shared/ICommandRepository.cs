using System.Threading.Tasks;

namespace SchoolApp.Domain.Repositories.Shared
{
    public interface ICommandRepository<T> where T : class
    {
        Task Save(T entity);
        Task Delete(T entity);
        Task Update(T entity);
    }
}