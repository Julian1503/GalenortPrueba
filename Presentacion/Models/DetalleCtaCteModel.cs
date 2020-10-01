using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Presentacion.Models
{
    public class DetalleCtaCteModel
    {
        [JsonProperty("id")]

        public int DetalleCtaCteId { get; set; }
        public string Periodo { get; set; }
        public decimal? Debe { get; set; }
        public decimal? Haber { get; set; }
        public ComprobanteModel Comprobante { get; set; }
        public PacienteModel Paciente { get; set; }
        public DetalleCtaCteModel DetalleCtaCte { get; set; }
    }
}
