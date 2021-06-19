using System;
using System.Collections.Generic;
using SchoolApp.Domain.ValueObjects;
using SchoolApp.Domain.Entities.Shared;

namespace SchoolApp.Domain.Entities
{
    public class Student : BaseEntity
    {
        public Name FirstName {get; set;}
        public Name LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public Email Email { get; set; }
        public IList<Course> Courses { get; set; }
        
        public override string ToString() => $"ID: { Id } - Name: { FirstName } { LastName } - Birth Date: { BirthDate }.";    
    }
}