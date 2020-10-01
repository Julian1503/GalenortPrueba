using System.Collections.Generic;
using System.Threading.Tasks;

namespace Galenort.Aplicacion.DetalleComprobante
{
    public interface IDetalleComprobanteServicio
    {
        Task<IEnumerable<Dominio.Entidades.DetalleComprobante>> GetAll();
        Task<IEnumerable<Dominio.Entidades.DetalleComprobante>> GetByFilter(string filtro);
        Task<Dominio.Entidades.DetalleComprobante> GetById(int id);
        Task Create(Dominio.Entidades.DetalleComprobante detalleComprobante);
        Task Update(Dominio.Entidades.DetalleComprobante detalleComprobante);
        Task Delete(Dominio.Entidades.DetalleComprobante detalleComprobante);
    }
}
