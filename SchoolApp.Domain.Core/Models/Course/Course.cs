using System.Linq;
using System.Collections.Generic;
using System.Collections.Immutable;
using SchoolApp.Domain.Core.Shared;
using System;

namespace SchoolApp.Domain.Core.Models

{
    public partial class Course : NamedBaseEntity
    {
        IEnumerable<Category> _categories {get;set;}
        IEnumerable<Student> _students {get;set;}
        ImmutableArray<int> Students {get => _students.Select(student => student.Id).ToImmutableArray(); }

        ImmutableArray<int> Categories { get => _categories.Select(category => category.Id).ToImmutableArray(); }

        public void SetCategories(IEnumerable<Category> categories)
        {
            _categories = categories;
        }
     
    }
}