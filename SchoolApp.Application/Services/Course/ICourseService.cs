using SchoolApp.Application.Dtos.CreateDtos;
using SchoolApp.Application.Dtos.ReadDtos;

namespace SchoolApp.Application.Services
{
    interface ICourseService : IGenericService<CourseReadDto, CourseCreateDto>
    {
        void Expell(StudentReadDto student);
        void Enroll(StudentReadDto student);
    }
}
