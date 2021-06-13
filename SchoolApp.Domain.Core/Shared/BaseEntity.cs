
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolApp.Domain.Core.Shared
{
    public abstract class BaseEntity
    {
        [Key]
        [Column("id")]
        public int Id {get; set;}

        [Column("created_at")]
        public DateTime CreatedAt {get;} = DateTime.UtcNow;
       
        [Column("modified_at")]
        public DateTime ModifiedAt { get; set;} = DateTime.UtcNow;
    }
}