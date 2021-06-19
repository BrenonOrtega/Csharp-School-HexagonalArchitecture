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

        internal Student ToEntity()
        {
            return new Student()
            {
                Id = this.Id,
                FirstName = this.FirstName,
                LastName = this.LastName,
                BirthDate = this.BirthDate,
                Email = this.Email
            };
        }
    }
}