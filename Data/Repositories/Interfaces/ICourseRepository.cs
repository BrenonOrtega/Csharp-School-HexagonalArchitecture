using firstDataAccess.Data.Models;
using FirstDataAccess.Data.Repositories.Interfaces.Shared;

namespace FirstDataAccess.Data.Repositories.Interfaces
{
    public interface ICourseRepository : IAsyncRepository<Course>
    {
         
    }
}