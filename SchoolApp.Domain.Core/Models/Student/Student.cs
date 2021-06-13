using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Immutable;
using SchoolApp.Domain.Core.Shared;
using Microsoft.Win32.SafeHandles;

namespace SchoolApp.Domain.Core.Models
{
    public partial class Student : BaseEntity
    {
        public string FirstName {get; set;}
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        IEnumerable<Course> _courses { get; set; }
        public IEnumerable<int> Courses 
        { 
            get=> _courses.Select(course => course.Id).ToImmutableArray(); 
        }

        private string _email;
        public string Email { 
            get => _email;
            set {   
                ThrowIfInvalid(value);
                _email = value;       
            }    
        }

        public void SetCourses(Func<IEnumerable<Course>> getThisStudentCourses)
        {
            IEnumerable<Course> courses = getThisStudentCourses?.Invoke();
            SetThisStudentCourses(courses);
        }

        public void SetCourses(IEnumerable<Course> thisStudentcourses)
        {
            IEnumerable<Course> courses = thisStudentcourses;
            SetThisStudentCourses(courses);
        }


        public override string ToString() => $"ID:{ Id }-Name:{ FirstName } { LastName }-Birth Date:{BirthDate}";
        
    }
}