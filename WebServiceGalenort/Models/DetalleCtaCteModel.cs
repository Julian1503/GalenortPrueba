namespace WebServiceGalenort.Models
{
    public class DetalleCtaCteModel
    {
        public int DetalleCtaCteId { get; set; }
        public string Periodo { get; set; }
        public decimal? Debe { get; set; }
        public decimal? Haber { get; set; }
        public int ComprobanteId { get; set; }
        public int PacienteId { get; set; }
        public int? ImputacionId { get; set; }
        public bool Estado { get; set; }
    }
}
