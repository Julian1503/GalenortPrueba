using System.Collections.Generic;
using System.Threading.Tasks;

namespace Galenort.Aplicacion.TipoComprobante
{
    public interface ITipoComprobanteServicio
    {
        Task<IEnumerable<Dominio.Entidades.TipoComprobante>> GetAll();
        Task<IEnumerable<Dominio.Entidades.TipoComprobante>> GetByFilter(string filtro);
        Task<Dominio.Entidades.TipoComprobante> GetById(int id);
        Task Create(Dominio.Entidades.TipoComprobante tipoComprobante);
        Task Update(Dominio.Entidades.TipoComprobante tipoComprobante);
        Task Delete(Dominio.Entidades.TipoComprobante tipoComprobante);
    }
}
