using System.Collections.Generic;
using System.Linq;
using SchoolApp.Domain.Entities;
using SchoolApp.Domain.ValueObjects;

namespace SchoolApp.Application.Dtos.ReadDtos.StudentDtos
{
    public class StudentCourseDto
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public IList<Name> Category { get; private set; }
        public StudentCourseDto(Course model)
        {
            Map(model);
        }
        private void Map(Course model)
        {
            Id = model.Id;
            Name = model.Name;
            Category = model.Categories.Select(category => category.Name).ToList();
        }
    }
}