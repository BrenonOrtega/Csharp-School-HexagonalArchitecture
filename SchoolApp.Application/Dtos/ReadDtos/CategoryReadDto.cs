using System.Linq;
using System.Collections.Generic;
using SchoolApp.Domain.Entities;
using SchoolApp.Application.Dtos.ReadDtos.CategoriesDtos;

namespace SchoolApp.Application.Dtos.ReadDtos
{
    public class CategoryReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        IList<CategoryCourseDto> Courses { get; set; }

        public CategoryReadDto(Category model)
        {
            Id = model.Id;
            Name = model.Name;
            Courses = model.Courses.Select(course => new CategoryCourseDto(course)).ToList();
        }
    }
}
