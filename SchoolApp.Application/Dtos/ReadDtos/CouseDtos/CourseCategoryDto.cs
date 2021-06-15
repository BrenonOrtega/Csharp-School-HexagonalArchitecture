using SchoolApp.Domain.Entities;

namespace SchoolApp.Application.Dtos.ReadDtos.CourseDtos
{
    public class CourseCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public CourseCategoryDto(Category model)
        {
            Id = model.Id;
            Name = model.Name;
        }

        public override string ToString() => $"Course:{ Name } - Identification: { Id }";
    }
}