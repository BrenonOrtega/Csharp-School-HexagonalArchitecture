using System.Linq;
using System.Collections.Generic;
using System.Collections.Immutable;
using SchoolApp.Domain.Entities.Shared;

namespace SchoolApp.Domain.Entities
{
    public partial class Category : NamedBaseEntity
    { 
        private IList<Course> _courses { get; set; }
        public ImmutableArray<int> Courses { get => _courses.Select(course => course.Id).ToImmutableArray(); }
    }
}