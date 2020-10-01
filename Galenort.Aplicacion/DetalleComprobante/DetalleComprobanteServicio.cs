using Galenort.Dominio.Extension;
using Galenort.Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Galenort.Aplicacion.DetalleComprobante
{
    public class DetalleComprobanteServicio : IDetalleComprobanteServicio
    {

        private IRepositorio<Dominio.Entidades.DetalleComprobante> _repositorio;

        public DetalleComprobanteServicio(IRepositorio<Dominio.Entidades.DetalleComprobante> repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<IEnumerable<Dominio.Entidades.DetalleComprobante>> GetAll()
        {
            return await _repositorio.GetAll();
        }

        public async Task<IEnumerable<Dominio.Entidades.DetalleComprobante>> GetByFilter(string filtro)
        {
            Expression<Func<Dominio.Entidades.DetalleComprobante, bool>> exp = x => true;
            exp = exp.And(x => x.Concepto.StartsWith(filtro));
            return await _repositorio.GetByFilter(exp, x => x.OrderBy(y => y.Periodo), null, false);
        }

        public async Task<Dominio.Entidades.DetalleComprobante> GetById(int id)
        {
            return await _repositorio.GetById(id, null, false);
        }

        public async Task Create(Dominio.Entidades.DetalleComprobante detalleComprobante)
        {
            await _repositorio.Create(detalleComprobante);
        }

        public async Task Update(Dominio.Entidades.DetalleComprobante detalleComprobante)
        {
            await _repositorio.Update(detalleComprobante);
        }

        public async Task Delete(Dominio.Entidades.DetalleComprobante detalleComprobante)
        {
            await _repositorio.Delete(detalleComprobante);
        }
    }
}
