using System.Collections.Generic;
using System.Threading.Tasks;

namespace Galenort.Aplicacion.Parentezco
{
    public interface IParentezcoServicio
    {
        Task<IEnumerable<Dominio.Entidades.Parentezco>> GetAll();
        Task<IEnumerable<Dominio.Entidades.Parentezco>> GetByFilter(string filtro);
        Task<Dominio.Entidades.Parentezco> GetById(int id);
        Task Create(Dominio.Entidades.Parentezco parentezco);
        Task Update(Dominio.Entidades.Parentezco parentezco);
        Task Delete(Dominio.Entidades.Parentezco parentezco);
    }
}
