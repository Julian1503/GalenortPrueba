using Galenort.Dominio;
using System.Collections.Generic;

#nullable disable

namespace Galenort.Dominio.Entidades
{
    public partial class Paciente : EntityBase
    {
        public Paciente()
        {
            Comprobantes = new HashSet<Comprobante>();
            DetalleCtaCtes = new HashSet<DetalleCtaCte>();
        }


        public string Apellido { get; set; }
        public int? CodigoVinculante { get; set; }
        public int ParentezcoId { get; set; }

        public virtual Parentezco Parentezco { get; set; }
        public virtual ICollection<Comprobante> Comprobantes { get; set; }
        public virtual ICollection<DetalleCtaCte> DetalleCtaCtes { get; set; }
    }
}
