using Galenort.Dominio;

#nullable disable

namespace Galenort.Dominio.Entidades
{
    public partial class DetalleComprobante : EntityBase
    {
        public string Concepto { get; set; }
        public string Periodo { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int Cantidad { get; set; }
        public int ComprobanteId { get; set; }

        public virtual Comprobante Comprobante { get; set; }
    }
}
