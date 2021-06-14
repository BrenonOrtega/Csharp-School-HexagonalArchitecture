using SchoolApp.Domain.Entities;
using SchoolApp.Domain.Repositories.Shared;

namespace SchoolApp.Domain.Repositories.Commands
{
    public interface IStudentCommandRepository : ICommandRepository<Student>
    {
        
    }
}