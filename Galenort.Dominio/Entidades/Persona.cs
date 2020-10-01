#nullable disable

namespace Galenort.Dominio.Entidades
{
    public partial class Persona : EntityBase
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Dni { get; set; }
        public string Direccion { get; set; }
    }
}
