using System.Collections.Generic;
using System.Threading.Tasks;

namespace Galenort.Aplicacion.Comprobante.Comprobante
{
    public interface IComprobanteServicio
    {
        Task<IEnumerable<Dominio.Entidades.Comprobante>> GetAll();
        Task<IEnumerable<Dominio.Entidades.Comprobante>> GetByFilter(string filtro);
        Task<Dominio.Entidades.Comprobante> GetById(int id);
        Task Create(Dominio.Entidades.Comprobante comprobante);
        Task Update(Dominio.Entidades.Comprobante comprobante);
        Task Delete(Dominio.Entidades.Comprobante comprobante);
    }
}
