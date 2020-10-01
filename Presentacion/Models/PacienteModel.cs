namespace Presentacion.Models
{
    public class PacienteModel
    {
        public int PacienteId { get; set; }
        public string Apellido { get; set; }
        public int? CodigoVinculante { get; set; }
        public ParentezcoModel Parentezco { get; set; }
    }
}
