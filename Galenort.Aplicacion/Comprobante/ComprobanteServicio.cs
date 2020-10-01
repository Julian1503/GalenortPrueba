using Galenort.Aplicacion.Comprobante.Comprobante;
using Galenort.Dominio.Extension;
using Galenort.Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Galenort.Aplicacion.Comprobante
{
    public class ComprobanteServicio : IComprobanteServicio
    {
        private IRepositorio<Dominio.Entidades.Comprobante> _repositorio;

        public ComprobanteServicio(IRepositorio<Dominio.Entidades.Comprobante> repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<IEnumerable<Dominio.Entidades.Comprobante>> GetAll()
        {
            return await _repositorio.GetAll();
        }

        public async Task<IEnumerable<Dominio.Entidades.Comprobante>> GetByFilter(string filtro)
        {
            Expression<Func<Dominio.Entidades.Comprobante, bool>> exp = x => true;
            exp = exp.And(x => x.NumeroComprobante.StartsWith(filtro));
            return await _repositorio.GetByFilter(exp, x => x.OrderBy(y => y.NumeroComprobante), null, false);
        }

        public async Task<Dominio.Entidades.Comprobante> GetById(int id)
        {
            return await _repositorio.GetById(id, null, false);
        }

        public async Task Create(Dominio.Entidades.Comprobante comprobante)
        {
            await _repositorio.Create(comprobante);
        }

        public async Task Update(Dominio.Entidades.Comprobante comprobante)
        {
            await _repositorio.Update(comprobante);
        }

        public async Task Delete(Dominio.Entidades.Comprobante comprobante)
        {
            await _repositorio.Delete(comprobante);
        }
    }
}
