using Galenort.Dominio;
using System.Collections.Generic;

#nullable disable

namespace Galenort.Dominio.Entidades
{
    public partial class TipoComprobante : EntityBase
    {
        public TipoComprobante()
        {
            Comprobantes = new HashSet<Comprobante>();
        }


        public string Descripcion { get; set; }

        public virtual ICollection<Comprobante> Comprobantes { get; set; }
    }
}
