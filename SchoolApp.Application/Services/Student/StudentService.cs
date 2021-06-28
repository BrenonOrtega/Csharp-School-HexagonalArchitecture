using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using SchoolApp.Domain.Repositories.Commands;
using SchoolApp.Domain.Repositories.Queries;
using SchoolApp.Application.Dtos.CreateDtos;
using SchoolApp.Application.Dtos.ReadDtos;

namespace SchoolApp.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentCommandRepository _studentCommander;
        private readonly IStudentQueryRepository _studentQuerier;
        private readonly ICourseQueryRepository _courseQuerier;

        public StudentService(
            IStudentQueryRepository studentQuerier,
            IStudentCommandRepository studentCommander,
            ICourseQueryRepository courseQuerier)
        {
            _studentQuerier = studentQuerier;
            _studentCommander = studentCommander;
            _courseQuerier = courseQuerier;
        }

        public async Task<StudentReadDto> Retrieve(int id)
        {
            var student = await _studentQuerier.GetById(id);
            return student;
        }

        public async Task<IList<StudentReadDto>> RetrieveMultiple(int page, int entriesCount)
        {
            var students = await _studentQuerier.GetAll(page, entriesCount);
            return students.Select(x => new StudentReadDto(x)).ToList();
        }

        public Task<IList<CourseReadDto>> RetrieveCourses(StudentReadDto student)
        {
            throw new System.NotImplementedException();
        }

        public async Task Create(StudentCreateDto createDto) =>
            await _studentCommander.Save(createDto);

        public async Task Update(StudentReadDto createDto) =>
            await _studentCommander.Update(createDto);

        public async Task Remove(StudentCreateDto createDto) =>
            await _studentCommander.Delete(createDto);
    }
}