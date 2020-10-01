using System.Collections.Generic;
using System.Threading.Tasks;

namespace Galenort.Aplicacion.Paciente
{
    public interface IPacienteServicio
    {
        Task<IEnumerable<Dominio.Entidades.Paciente>> GetAll();
        Task<IEnumerable<Dominio.Entidades.Paciente>> GetByFilter(string filtro);
        Task<Dominio.Entidades.Paciente> GetById(int id);
        Task Create(Dominio.Entidades.Paciente paciente);
        Task Update(Dominio.Entidades.Paciente paciente);
        Task Delete(Dominio.Entidades.Paciente paciente);
    }
}
