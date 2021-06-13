using System.Linq;
using SchoolApp.Domain.Core.Shared;


namespace SchoolApp.Domain.Core.Models

{
    public partial class Course : NamedBaseEntity
    {
        public bool IsStudentEnrolled(int studentId) => _categories.Any(c => c.Id.Equals(studentId));
        public bool IsInCategory(int categoryId) => _categories.Any(c => c.Id.Equals(categoryId));
        public Student Student(int studentId) => _students.Single(s => s.Id.Equals(studentId));
        public Category Category(int categoryId) => _categories.Single(c => c.Id.Equals(categoryId)); 

        public void Enroll(Student student)
        {
            _students = _students.Append(student);
        }
    }
}