namespace WebServiceGalenort.Models
{
    public class DetalleComprobanteModel
    {
        public int DetalleComprobanteId { get; set; }
        public string Concepto { get; set; }
        public string Periodo { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int Cantidad { get; set; }
        public int ComprobanteId { get; set; }
        public bool Estado { get; set; }
    }
}
