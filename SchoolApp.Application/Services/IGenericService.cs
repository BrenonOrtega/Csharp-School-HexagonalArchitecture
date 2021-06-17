using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolApp.Application.Services
{
    interface IGenericService<ReadDto, CreateDto> 
        where ReadDto : class 
        where CreateDto : class
    {
        Task<ReadDto> Retrieve(int id);
        Task<IList<ReadDto>> RetrieveMultiple(int page, int offset);
        Task Create(CreateDto createDto);
        void Remove(ReadDto readDto);
    }
}