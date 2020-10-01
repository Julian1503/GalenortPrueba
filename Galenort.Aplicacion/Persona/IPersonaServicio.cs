using System.Collections.Generic;
using System.Threading.Tasks;

namespace Galenort.Aplicacion
{
    public interface IPersonaServicio
    {
        Task<IEnumerable<Dominio.Entidades.Persona>> GetAll();
        Task<IEnumerable<Dominio.Entidades.Persona>> GetByFilter(string filtro);
        Task<Dominio.Entidades.Persona> GetById(int id);
        Task Create(Dominio.Entidades.Persona persona);
        Task Update(Dominio.Entidades.Persona persona);
        Task Delete(Dominio.Entidades.Persona persona);
    }
}
