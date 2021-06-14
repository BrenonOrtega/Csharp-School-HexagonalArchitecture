using System.Linq;
using System.Collections.Generic;
using SchoolApp.Domain.Entities.Shared;

namespace SchoolApp.Domain.Entities
{
    public partial class Course : NamedBaseEntity
    {
        public bool IsStudentEnrolled(int studentId) => 
            _categories.Any(c => c.Id.Equals(studentId));

        public bool IsInCategory(int categoryId) => 
            _categories.Any(c => c.Id.Equals(categoryId));


        public Student Student(int studentId) => 
            _students.Single(s => s.Id.Equals(studentId));

        public Category Category(int categoryId) => 
            _categories.Single(c => c.Id.Equals(categoryId)); 


        void SetStudents(IList<Student> students) =>
            _students = students;
   
        void SetCategories(IList<Category> categories) =>
            _categories = categories;

    }
}