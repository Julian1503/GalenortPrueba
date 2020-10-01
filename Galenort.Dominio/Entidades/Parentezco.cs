using Galenort.Dominio;
using System.Collections.Generic;

#nullable disable

namespace Galenort.Dominio.Entidades
{
    public partial class Parentezco : EntityBase
    {
        public Parentezco()
        {
            Pacientes = new HashSet<Paciente>();
        }

        public string Descripcion { get; set; }
        public int Codigo { get; set; }

        public virtual ICollection<Paciente> Pacientes { get; set; }
    }
}
