using System.Threading.Tasks;
using System.Collections.Generic;

namespace SchoolApp.Application.Services
{
    interface IGenericService<ReadDto, CreateDto> 
        where ReadDto : class 
        where CreateDto : class
    {
        Task<ReadDto> Retrieve(int id);
        Task<IList<ReadDto>> RetrieveMultiple(int page, int entriesCount);
        Task Create(CreateDto createDto);
        Task Update(ReadDto createDto);
        Task Remove(CreateDto readDto);
    }
}