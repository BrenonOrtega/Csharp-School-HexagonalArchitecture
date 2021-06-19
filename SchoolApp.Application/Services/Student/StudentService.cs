using System.Threading.Tasks;
using System.Collections.Generic;
using SchoolApp.Domain.Repositories.Commands;
using SchoolApp.Domain.Repositories.Queries;
using SchoolApp.Application.Dtos.CreateDtos;
using SchoolApp.Application.Dtos.ReadDtos;
using System.Linq;

namespace SchoolApp.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentQueryRepository _queryStudent;
        private readonly IStudentCommandRepository _commandStudent;
        private readonly ICourseQueryRepository _queryCourses;

        public StudentService(
            IStudentQueryRepository queryStudent, 
            IStudentCommandRepository commandStudent, 
            ICourseQueryRepository queryCourses)
        {
            _queryStudent = queryStudent;
            _commandStudent = commandStudent;
            _queryCourses = queryCourses;
        }

        public async Task Create(StudentCreateDto createDto)
        {
            await _commandStudent.Save(createDto.ToEntity());
        }
        
        public async Task Update(StudentCreateDto createDto) => await _commandStudent.Update(createDto.ToEntity());
        public void Leave(CourseReadDto course)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<CourseReadDto>> RetrieveCourses(StudentReadDto student)
        {
            throw new System.NotImplementedException();
        }

        public Task Remove(StudentReadDto entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task<StudentReadDto> Retrieve(int id) 
        {
            var student = await _queryStudent.GetById(id);
            return new StudentReadDto(student);
        }

        public async Task<IList<StudentReadDto>> RetrieveMultiple(int page, int offset)
        {
            var students = await _queryStudent.GetAll(page, offset);
            return students.Select(x => new StudentReadDto(x)).ToList();
        }
    }
}