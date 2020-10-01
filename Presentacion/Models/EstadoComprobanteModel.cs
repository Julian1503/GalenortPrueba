using Newtonsoft.Json;

namespace Presentacion.Models
{
    public class EstadoComprobanteModel
    {
        [JsonProperty("id")]
        public int EstadoComprobanteId { get; set; }
        public string Descripcion { get; set; }
    }
}
