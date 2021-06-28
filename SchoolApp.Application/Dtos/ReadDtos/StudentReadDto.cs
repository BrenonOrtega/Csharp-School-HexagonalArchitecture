using System;
using System.Collections.Generic;
using SchoolApp.Application.Dtos.ReadDtos.StudentDtos;
using SchoolApp.Domain.Entities;

namespace SchoolApp.Application.Dtos.ReadDtos
{
    public class StudentReadDto
    {
        public int Id { get; }
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
        public DateTime BirthDate { get; internal set; }
        public string Email { get; internal set; }
        public IList<StudentCourseDto> Courses { get; internal set; }

        public StudentReadDto() { }
        public StudentReadDto(Student student)
        {
            Id = student.Id;
            FirstName = student.FirstName;
            LastName = student.LastName;
            BirthDate = student.BirthDate;
            Email = student.Email;
        }

        public static implicit operator StudentReadDto(Student student) =>
            new StudentReadDto(student);

        public static implicit operator Student(StudentReadDto dto) =>
            new Student() { Id = dto.Id, FirstName = dto.FirstName, LastName = dto.LastName, BirthDate = dto.BirthDate, Email = dto.Email };

        public override string ToString() => $"Student:{FirstName} {LastName} - Id:{Id} - Email: {Email}";
    }
}
