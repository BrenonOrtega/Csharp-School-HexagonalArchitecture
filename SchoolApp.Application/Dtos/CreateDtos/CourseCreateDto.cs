using SchoolApp.Domain.Entities;

namespace SchoolApp.Application.Dtos.CreateDtos
{
    
    public class CourseCreateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public static implicit operator Course(CourseCreateDto dto) =>
            new Course() {Id = dto.Id, Name = dto.Name };
    }
}