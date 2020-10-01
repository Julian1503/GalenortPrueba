using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Presentacion.Models
{
    public class ComprobanteModel
    {
        [JsonProperty("id")]

        public int ComprobanteId { get; set; }
        public string NumeroComprobante { get; set; }
        public decimal Monto { get; set; }
        public EstadoComprobanteModel EstadoComprobante { get; set; }
        public PacienteModel Paciente { get; set; }
        public TipoComprobanteModel TipoComprobante { get; set; }
    }
}
