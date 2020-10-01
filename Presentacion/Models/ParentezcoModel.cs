using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Presentacion.Models
{
    public class ParentezcoModel
    {
        [JsonProperty("id")]
        public int ParentezcoId { get; set; }
        public string Descripcion { get; set; }
        public int Codigo { get; set; }
    }
}
