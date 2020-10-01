using System.Collections.Generic;

#nullable disable

namespace Galenort.Dominio.Entidades
{
    public partial class DetalleCtaCte : EntityBase
    {
        public DetalleCtaCte()
        {
            InverseImputacion = new HashSet<DetalleCtaCte>();
        }

        public string Periodo { get; set; }
        public decimal? Debe { get; set; }
        public decimal? Haber { get; set; }
        public int ComprobanteId { get; set; }
        public int PacienteId { get; set; }
        public int? ImputacionId { get; set; }

        public virtual Comprobante Comprobante { get; set; }
        public virtual DetalleCtaCte Imputacion { get; set; }
        public virtual Paciente Paciente { get; set; }
        public virtual ICollection<DetalleCtaCte> InverseImputacion { get; set; }
    }
}
