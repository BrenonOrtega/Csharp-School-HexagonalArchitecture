using System;
using SchoolApp.Domain.Entities;

namespace SchoolApp.Application.Dtos.CreateDtos
{
    public class StudentCreateDto
    {        
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }

        public static implicit operator Student(StudentCreateDto dto) =>
            new Student()
            { 
                Id = dto.Id, 
                FirstName = dto.FirstName, 
                LastName = dto.LastName, 
                BirthDate = dto.BirthDate, 
                Email = dto.Email,
                ModifiedAt = DateTime.Now
            };
    }

}