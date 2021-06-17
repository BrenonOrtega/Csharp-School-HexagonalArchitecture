using System;
using System.Linq;
using System.Collections.Generic;
using SchoolApp.Domain.Entities;
using SchoolApp.Application.Dtos.ReadDtos.StudentDtos;

namespace SchoolApp.Application.Dtos.ReadDtos
{
    public class StudentReadDto 
    {
        public int Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public DateTime BirthDate { get; }
        public string Email { get; }
        public IList<StudentCourseDto> Courses { get; }
        public StudentReadDto(Student student)
        {
            Id = student.Id;
            FirstName = student.FirstName;
            LastName = student.LastName;
            BirthDate = student.BirthDate;
            Email = student.Email;
            Courses = student.Courses.Select(course => new StudentCourseDto(course)).ToList();
        }
    }
}
