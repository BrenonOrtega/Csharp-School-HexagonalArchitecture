using System.Linq;

namespace SchoolApp.Domain.Entities
{
    public partial class Student
    {
        public Course GetCourse(int courseId) => 
            _courses.Single(c => c.Id.Equals(courseId));

        public bool IsEnrolled(int courseId) => 
            _courses.Any(c => c.Id.Equals(courseId));
    }
}