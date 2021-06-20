using System.Collections.Generic;
using SchoolApp.Domain.Entities;
using SchoolApp.Application.Dtos.ReadDtos.CourseDtos;

namespace SchoolApp.Application.Dtos.ReadDtos
{
    public class CourseReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<CourseStudentDto> Students{ get; set; }
        public IList<CourseCategoryDto> Categories { get; set; }

        public static implicit operator CourseReadDto(Course course) =>
            new CourseReadDto{ Id = course.Id, Name = course.Name };
    }
}