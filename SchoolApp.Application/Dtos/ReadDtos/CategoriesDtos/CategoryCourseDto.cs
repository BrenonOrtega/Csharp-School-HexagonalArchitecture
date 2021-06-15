using SchoolApp.Domain.Entities;

namespace SchoolApp.Application.Dtos.ReadDtos.CategoriesDtos
{
    public class CategoryCourseDto
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public CategoryCourseDto(Course model)
        {
            Id = model.Id;
            Name = model.Name;
        }
    }
}