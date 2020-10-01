
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Galenort.Aplicacion.DetalleCtaCte
{
    public interface IDetalleCtaCteServicio
    {
        Task<IEnumerable<Dominio.Entidades.DetalleCtaCte>> GetAll();
        Task<IEnumerable<Dominio.Entidades.DetalleCtaCte>> GetByFilter(string filtro);
        Task<Dominio.Entidades.DetalleCtaCte> GetById(int id);
        Task Create(Dominio.Entidades.DetalleCtaCte detalleCtaCte);
        Task Update(Dominio.Entidades.DetalleCtaCte detalleCtaCte);
        Task Delete(Dominio.Entidades.DetalleCtaCte detalleCtaCte);
        Task<IEnumerable<Dominio.Entidades.DetalleCtaCte>> GetByPaciente(int pacienteid);
        Task<IEnumerable<Dominio.Entidades.DetalleCtaCte>> GetByDeuda(int pacienteid);
    }
}
