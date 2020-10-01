using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Presentacion.Models
{
    public class TipoComprobanteModel
    {
        [JsonProperty("id")]

        public int TipoComprobanteId { get; set; }
        public string Descripcion { get; set; }
    }
}
