using System.Collections.Generic;
using SchoolApp.Application.Dtos.ReadDtos;
using SchoolApp.Application.Dtos.CreateDtos;
using System.Threading.Tasks;

namespace SchoolApp.Application.Services
{
    interface IStudentService : IGenericService<StudentReadDto, StudentCreateDto>
    {
        void Leave(CourseReadDto course);
        Task<IList<CourseReadDto>> RetrieveCourses(StudentReadDto student);

    }
}
