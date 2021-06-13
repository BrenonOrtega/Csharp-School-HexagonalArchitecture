using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolApp.Domain.Core.Shared
{
    public abstract class NamedBaseEntity : BaseEntity
    {
        [Required]
        [Column("name")]
        public string Name { get; set; }
    }
}