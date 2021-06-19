using System.Collections.Generic;
using SchoolApp.Domain.Entities.Shared;

namespace SchoolApp.Domain.Entities
{
    public class Category : NamedBaseEntity
    {
        public IList<Course> Courses { get; set; }
    }
}