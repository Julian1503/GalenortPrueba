namespace WebServiceGalenort.Models
{
    public class PacienteModel
    {
        public int PacienteId { get; set; }
        public string Apellido { get; set; }
        public int? CodigoVinculante { get; set; }
        public int ParentezcoId { get; set; }
        public bool Estado { get; set; }
    }
}
