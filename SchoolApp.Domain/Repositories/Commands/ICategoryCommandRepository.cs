using SchoolApp.Domain.Entities;
using SchoolApp.Domain.Repositories.Shared;

namespace SchoolApp.Domain.Repositories.Commands
{
    public interface ICategoryCommandRepository : ICommandRepository<Category>
    {

    }
}