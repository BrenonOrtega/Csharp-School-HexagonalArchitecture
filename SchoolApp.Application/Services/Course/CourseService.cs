using System;
using System.Collections.Generic;
using System.Linq;
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


        public CourseService(
            ICourseCommandRepository courseCommander,
            ICourseQueryRepository courseQuerier,
            IStudentQueryRepository studentQuerier
        )
        {
            _courseCommander = courseCommander;
            _courseQuerier = courseQuerier;
            _studentQuerier = studentQuerier;
            //_categoryQuerier = categoryQuerier;
        }
        public async Task<IList<CourseReadDto>> RetrieveMultiple(int page = 0, int entriesCount = 20)
        {
            var courses = await _courseQuerier.GetAll(page, entriesCount);
            var courseList = courses.Select(course => new CourseReadDto(course)).ToList();

            return courseList;
        }

        public async Task<CourseReadDto> Retrieve(int id)
        {
            var course = await _courseQuerier.GetById(id);

            return course;
        }

        public async Task Create(CourseCreateDto createDto)
        {
            await _courseCommander.Save(createDto);
        }

        public async Task Remove(CourseCreateDto readDto)
        {
            await _courseCommander.Delete(readDto);
        }

        public async Task Update(CourseReadDto readDto)
        {
            await _courseCommander.Update(readDto);
        }

        public async Task<IEnumerable<StudentReadDto>> GetStudents(CourseReadDto course)
        {
            throw new NotImplementedException();
        }

        public async Task AddStudent(StudentReadDto student)
        {
            throw new System.NotImplementedException();
        }
    }
}
