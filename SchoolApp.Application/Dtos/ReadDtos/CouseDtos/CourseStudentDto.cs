using SchoolApp.Domain.Entities;

namespace SchoolApp.Application.Dtos.ReadDtos.CourseDtos
{
    public class CourseStudentDto
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        
        public CourseStudentDto(Student model)
        {
            Id = model.Id;
            Name = $"{ model.FirstName } { model.LastName }";
            Email = model.Email;
        }

        public override string ToString() => $"Course:{ Name } - Identification: { Id }";
    }
}