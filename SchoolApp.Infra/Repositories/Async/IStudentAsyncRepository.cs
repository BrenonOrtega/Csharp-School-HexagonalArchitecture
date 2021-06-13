using SchoolApp.Domain.Core.Models;
using SchoolApp.Infra.Repositories.Shared;

namespace SchoolApp.Infra.Repositories.Async
{
    public interface IStudentAsyncRepository : IAsyncRepository<Student>
    {
        
    }
}