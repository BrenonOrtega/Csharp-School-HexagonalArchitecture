using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstDataAccess.Data.Models
{
    [Table("aluno")]
    public class Student
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("primeiro_nome")]
        public string FirstName {get; set;}

        [Required]
        [Column("ultimo_nome")]
        public string LastName { get; set; }
        
        [Required]
        [Column("data_nascimento")]
        public DateTime BirthDate { get; set; }

        public override string ToString() => $"ID:{ Id }-Name: { FirstName } { LastName }-Birth Date: {BirthDate}";
        
    }
}