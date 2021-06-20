using System.Collections.Generic;
using System.Threading.Tasks;
using SchoolApp.Application.Dtos.CreateDtos;
using SchoolApp.Application.Dtos.ReadDtos;
using SchoolApp.Domain.Repositories.Commands;
using SchoolApp.Domain.Repositories.Queries;

namespace SchoolApp.Application.Services.Course
{
    public class CourseService : ICourseService
    {
        private readonly ICourseCommandRepository _courseCommander;
        private readonly ICourseQueryRepository _courseQuerier;
        private readonly IStudentQueryRepository _studentQuerier;
        private readonly ICategoryQueryRepository _categoryQuerier;


        public CourseService(
            ICourseCommandRepository courseCommander, 
            ICourseQueryRepository courseQuerier, 
            IStudentQueryRepository studentQuerier, 
            ICategoryQueryRepository categoryQuerier)
        {
            _courseCommander = courseCommander;
            _courseQuerier = courseQuerier;
            _studentQuerier = studentQuerier;
            _categoryQuerier = categoryQuerier;
        }

        public async Task<CourseReadDto> Retrieve(int id)
        {
            var course = await _courseQuerier.GetById(id);
            return course;
        }

        public Task<IList<CourseReadDto>> RetrieveMultiple(int page, int offset)
        {
            throw new System.NotImplementedException();
        }
        public Task Create(CourseCreateDto createDto)
        {
            throw new System.NotImplementedException();
        }

        public void Enroll(StudentReadDto student)
        {
            throw new System.NotImplementedException();
        }

        public void Expell(StudentReadDto student)
        {
            throw new System.NotImplementedException();
        }

        public Task Remove(CourseCreateDto readDto)
        {
            throw new System.NotImplementedException();
        }


        public Task Update(CourseCreateDto createDto)
        {
            throw new System.NotImplementedException();
        }
    }
}