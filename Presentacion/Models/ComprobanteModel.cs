namespace Presentacion.Models
{
    public class ComprobanteModel
    {
        public int ComprobanteId { get; set; }
        public string NumeroComprobante { get; set; }
        public decimal Monto { get; set; }
        public EstadoComprobanteModel EstadoComprobante { get; set; }
        public PacienteModel Paciente { get; set; }
        public TipoComprobanteModel TipoComprobante { get; set; }
    }
}
