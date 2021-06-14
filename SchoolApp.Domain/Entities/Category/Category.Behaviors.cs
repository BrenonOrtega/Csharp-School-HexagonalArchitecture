using System.Linq;
using System.Collections.Generic;

namespace SchoolApp.Domain.Entities
{
    public partial class Category
    {
        public bool IsInCategory(int courseId) => 
            _courses.Any(c => c.Id.Equals(courseId));

        Course GetCourse(int courseId) => 
            _courses.Single(c => c.Id.Equals(courseId));
        
        public void SetCourses(IList<Course> courses) =>
            _courses = courses;
    }
}