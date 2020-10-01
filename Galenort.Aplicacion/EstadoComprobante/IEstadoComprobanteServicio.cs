using System.Collections.Generic;
using System.Threading.Tasks;

namespace Galenort.Aplicacion.EstadoComprobante
{
    public interface IEstadoComprobanteServicio
    {
        Task<IEnumerable<Dominio.Entidades.EstadoComprobante>> GetAll();
        Task<IEnumerable<Dominio.Entidades.EstadoComprobante>> GetByFilter(string filtro);
        Task<Dominio.Entidades.EstadoComprobante> GetById(int id);
        Task Create(Dominio.Entidades.EstadoComprobante estadoComprobante);
        Task Update(Dominio.Entidades.EstadoComprobante estadoComprobante);
        Task Delete(Dominio.Entidades.EstadoComprobante estadoComprobante);
    }
}
