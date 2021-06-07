using FirstDataAccess.Data.Models;
using FirstDataAccess.Data.Repositories.Interfaces.Shared;
using Microsoft.Extensions.Primitives;

namespace FirstDataAccess.Data.Repositories.Interfaces.Async
{
    public interface IStudentAsyncRepository : IAsyncRepository<Student>
    {
        
    }
}