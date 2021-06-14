using System.Linq;
using System.Collections.Generic;
using System.Collections.Immutable;
using SchoolApp.Domain.Entities.Shared;

namespace SchoolApp.Domain.Entities

{
    public partial class Course : NamedBaseEntity
    {
        IList<Student> _students {get;set;}
        ImmutableArray<int> Students {get => _students.Select(student => student.Id).ToImmutableArray(); }

        IList<Category> _categories {get;set;}
        ImmutableArray<int> Categories { get => _categories.Select(category => category.Id).ToImmutableArray(); }
     
    }
}