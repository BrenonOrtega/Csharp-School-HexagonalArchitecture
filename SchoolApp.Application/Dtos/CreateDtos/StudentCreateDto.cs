using System;
using SchoolApp.Domain.Entities;

namespace SchoolApp.Application.Dtos.CreateDtos
{
    public class StudentCreateDto
    {        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }

        internal Student ToEntity()
        {
            return new Student()
            {
                FirstName = this.FirstName,
                LastName = this.LastName,
                BirthDate = this.BirthDate,
                Email = this.Email
            };
        }
    }
}