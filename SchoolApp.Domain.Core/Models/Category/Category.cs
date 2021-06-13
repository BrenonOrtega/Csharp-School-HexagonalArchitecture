using System.Linq;
using System.Collections.Generic;
using System.Collections.Immutable;
using SchoolApp.Domain.Core.Shared;
using System;

namespace SchoolApp.Domain.Core.Models
{
    public class Category : NamedBaseEntity
    { 
        public ImmutableArray<int> Courses { get => _courses.Select(course => course.Id).ToImmutableArray(); }
        private IEnumerable<Course> _courses { get; set; }

        public bool IsInCategory(int courseId) => _courses.Any(c => c.Id.Equals(courseId));
        public Course Course(int courseId) => _courses.Single(c => c.Id.Equals(courseId));

        public void SetCourses(Func<IEnumerable<Course>> getThisCategoryCourses)
        {
            var courses = getThisCategoryCourses?.Invoke() 
                ?? throw new NullReferenceException($"Cannot retrieve this {nameof(Category)} { nameof(Courses) }");
                
            var isValid = courses.All(c => c.IsInCategory(this.Id));
            _courses = courses;
        }
    }
}