using System;
using System.Linq;
using System.Collections.Generic;

namespace SchoolApp.Domain.Core.Models
{
    public partial class Student
    {
        public Course GetCourse(int courseId) => _courses.Single(c => c.Id.Equals(courseId));
        public bool IsEnrolled(int courseId) => _courses.All(c => c.Id.Equals(courseId));

        private void SetThisStudentCourses(IEnumerable<Course> courses) {   
            ThrowIfInvalid(courses);
            _courses = courses;
        }

        private void ThrowIfInvalid<T>(T obj) {
            Type type = typeof(T);
            switch (type) {
                case IEnumerable<Course> courses:
                    ValidateCourses(courses);
                    break;
                default:
                    if (type != typeof(string))
                        throw new InvalidOperationException("No validator for this property");
                    ValidateEmail(obj.ToString());
                    break;        
            }
        }

        private void ValidateCourses(IEnumerable<Course> courses){
            if (courses is null) 
                throw new NullReferenceException($"Enumeration of { nameof(Courses) } is no set to an instance of object.");

            var isNotEnrolled = courses.All(c => c.IsStudentEnrolled(this.Id));
            if(isNotEnrolled)
                throw new ArgumentException($"This student is not Enrolled in this { nameof(Course) }.");
        }

        private void ValidateEmail(string email) {
            var isInvalid = false.Equals( email.Contains("@") && email.Contains(".com") ); 
            if( isInvalid )
                throw new ArgumentException($"invalid { nameof(email) }");
        }
    }
}