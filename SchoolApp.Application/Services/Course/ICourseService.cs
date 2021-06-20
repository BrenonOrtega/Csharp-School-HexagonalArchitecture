using System.Threading.Tasks;
using System.Collections.Generic;
using SchoolApp.Application.Dtos.CreateDtos;
using SchoolApp.Application.Dtos.ReadDtos;

namespace SchoolApp.Application.Services
{
    interface ICourseService : IGenericService<CourseReadDto, CourseCreateDto>
    {
        Task<IEnumerable<StudentReadDto>> GetStudents(CourseReadDto course);
        void AddStudent(StudentReadDto student);
    }
}
