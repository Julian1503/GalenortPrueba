namespace WebServiceGalenort.Models
{
    public class ComprobanteModel
    {
        public int ComprobanteId { get; set; }
        public string NumeroComprobante { get; set; }
        public decimal Monto { get; set; }
        public int EstadoComprobanteId { get; set; }
        public int PacienteId { get; set; }
        public int TipoComprobanteId { get; set; }
        public bool Estado { get; set; }
    }
}
