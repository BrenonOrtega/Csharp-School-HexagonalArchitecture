using System.Linq;
using System.Collections.Generic;
using SchoolApp.Domain.Entities.Shared;

namespace SchoolApp.Domain.Entities
{
    public partial class Course : NamedBaseEntity 
    {
        public IList<Student> Students { get; set; }
        public IList<Category> Categories { get;set; }     
    }
}