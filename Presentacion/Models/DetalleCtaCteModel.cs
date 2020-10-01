namespace Presentacion.Models
{
    public class DetalleCtaCteModel
    {
        public int DetalleCtaCteId { get; set; }
        public string Periodo { get; set; }
        public decimal? Debe { get; set; }
        public decimal? Haber { get; set; }
        public ComprobanteModel Comprobante { get; set; }
        public PacienteModel Paciente { get; set; }
        public DetalleCtaCteModel DetalleCtaCte { get; set; }
    }
}
