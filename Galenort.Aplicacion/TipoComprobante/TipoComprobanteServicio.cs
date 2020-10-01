using Galenort.Dominio.Extension;
using Galenort.Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Galenort.Aplicacion.TipoComprobante
{
    public class TipoComprobanteServicio : ITipoComprobanteServicio
    {

        private IRepositorio<Dominio.Entidades.TipoComprobante> _repositorio;

        public TipoComprobanteServicio(IRepositorio<Dominio.Entidades.TipoComprobante> repositorio)
        {
            _repositorio = repositorio;


        }

        public async Task<IEnumerable<Dominio.Entidades.TipoComprobante>> GetAll()
        {
            return await _repositorio.GetAll();
        }

        public async Task<IEnumerable<Dominio.Entidades.TipoComprobante>> GetByFilter(string filtro)
        {
            Expression<Func<Dominio.Entidades.TipoComprobante, bool>> exp = x => true;
            exp = exp.And(x => x.Descripcion.StartsWith(filtro));
            return await _repositorio.GetByFilter(exp, x => x.OrderBy(y => y.Descripcion), null, false);
        }

        public async Task<Dominio.Entidades.TipoComprobante> GetById(int id)
        {
            return await _repositorio.GetById(id, null, false);
        }

        public async Task Create(Dominio.Entidades.TipoComprobante tipoComprobante)
        {
            await _repositorio.Create(tipoComprobante);
        }

        public async Task Update(Dominio.Entidades.TipoComprobante tipoComprobante)
        {
            await _repositorio.Update(tipoComprobante);
        }

        public async Task Delete(Dominio.Entidades.TipoComprobante tipoComprobante)
        {
            await _repositorio.Delete(tipoComprobante);
        }
    }
}
