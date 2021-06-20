using System.Threading.Tasks;
using System.Collections.Generic;
using SchoolApp.Application.Dtos.ReadDtos;
using SchoolApp.Application.Dtos.CreateDtos;

namespace SchoolApp.Application.Services
{
    interface IStudentService : IGenericService<StudentReadDto, StudentCreateDto>
    {
        Task<IList<CourseReadDto>> RetrieveCourses(StudentReadDto student);

    }
}
