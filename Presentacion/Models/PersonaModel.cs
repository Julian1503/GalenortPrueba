using System.ComponentModel.DataAnnotations;

namespace Presentacion.Models
{
    public class PersonaModel
    {
        public int PersonaId { get; set; }
        [Required(ErrorMessage = "El campo nombre es necesario")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El campo apellido es necesario")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "El campo DNI es necesario")]
        [MinLength(8, ErrorMessage = "El DNI debe ser de 8 numeros")]
        [MaxLength(8)]
        public string Dni { get; set; }
        [Required(ErrorMessage = "El campo direccion es necesario")]
        public string Direccion { get; set; }
    }
}
