using Galenort.Dominio.Extension;
using Galenort.Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Galenort.Aplicacion.EstadoComprobante
{
    public class EstadoComprobanteServicio : IEstadoComprobanteServicio
    {

        private IRepositorio<Dominio.Entidades.EstadoComprobante> _repositorio;

        public EstadoComprobanteServicio(IRepositorio<Dominio.Entidades.EstadoComprobante> repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<IEnumerable<Dominio.Entidades.EstadoComprobante>> GetAll()
        {
            var estadoComprobantes = await _repositorio.GetAll();
            return estadoComprobantes;
        }

        public async Task<IEnumerable<Dominio.Entidades.EstadoComprobante>> GetByFilter(string filtro)
        {
            Expression<Func<Dominio.Entidades.EstadoComprobante, bool>> exp = x => true;
            exp = exp.And(x => x.Descripcion.StartsWith(filtro));
            return await _repositorio.GetByFilter(exp, x => x.OrderBy(y => y.Descripcion), null, false);
        }

        public async Task<Dominio.Entidades.EstadoComprobante> GetById(int id)
        {
            return await _repositorio.GetById(id, null, false);
        }

        public async Task Create(Dominio.Entidades.EstadoComprobante estadoComprobante)
        {
            await _repositorio.Create(estadoComprobante);
        }

        public async Task Update(Dominio.Entidades.EstadoComprobante estadoComprobante)
        {
            await _repositorio.Update(estadoComprobante);
        }

        public async Task Delete(Dominio.Entidades.EstadoComprobante estadoComprobante)
        {
            await _repositorio.Delete(estadoComprobante);
        }
    }
}
