using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Immutable;
using SchoolApp.Domain.Entities.Shared;
using SchoolApp.Domain.ValueObjects;

namespace SchoolApp.Domain.Entities
{
    public partial class Student : BaseEntity
    {
        public Name FirstName {get; set;}
        public Name LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public Email Email { get; set; }
        IEnumerable<Course> _courses { get; set; }

        public ImmutableArray<int> Courses => 
            _courses.Select(course => course.Id).ToImmutableArray();
        
        public override string ToString() => $"ID: { Id } - Name: { FirstName } { LastName } - Birth Date: { BirthDate }.";    
    }
}