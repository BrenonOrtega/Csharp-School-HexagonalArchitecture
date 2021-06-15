using SchoolApp.Domain.Entities;
using System.Collections.Generic;
using SchoolApp.Application.Dtos.ReadDtos.CategoriesDtos;
using System.Linq;

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
