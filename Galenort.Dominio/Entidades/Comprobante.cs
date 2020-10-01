using Galenort.Dominio;
using System.Collections.Generic;

#nullable disable

namespace Galenort.Dominio.Entidades
{
    public partial class Comprobante : EntityBase
    {
        public Comprobante()
        {
            DetalleComprobantes = new HashSet<DetalleComprobante>();
            DetalleCtaCtes = new HashSet<DetalleCtaCte>();
        }

        public string NumeroComprobante { get; set; }
        public decimal Monto { get; set; }
        public int EstadoComprobanteId { get; set; }
        public int PacienteId { get; set; }
        public int TipoComprobanteId { get; set; }

        public virtual EstadoComprobante EstadoComprobante { get; set; }
        public virtual Paciente Paciente { get; set; }
        public virtual TipoComprobante TipoComprobante { get; set; }
        public virtual ICollection<DetalleComprobante> DetalleComprobantes { get; set; }
        public virtual ICollection<DetalleCtaCte> DetalleCtaCtes { get; set; }
    }
}
