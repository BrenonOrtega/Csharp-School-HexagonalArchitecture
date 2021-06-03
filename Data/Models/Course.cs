using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FirstDataAccess.Data.Models;

namespace firstDataAccess.Data.Models
{
    [Table("curso")]
    public class Course
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("nome")]
        public string Name { get; set; }

        [Required]
        [NotMapped]
        Category category {get;set;}

        [Column("categoria_id")]
        public int CategoryId => category.Id;

    }
}