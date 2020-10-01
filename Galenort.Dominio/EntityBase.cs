using System.ComponentModel.DataAnnotations;

namespace Galenort.Dominio
{
    public class EntityBase
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public bool Estado { get; set; }
    }
}
