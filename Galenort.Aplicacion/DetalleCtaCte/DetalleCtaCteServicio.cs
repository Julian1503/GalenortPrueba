using Galenort.Dominio.Extension;
using Galenort.Dominio.Repositorio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Galenort.Aplicacion.DetalleCtaCte
{
    public class DetalleCtaCteServicio : IDetalleCtaCteServicio
    {

        private IRepositorio<Dominio.Entidades.DetalleCtaCte> _repositorio;

        public DetalleCtaCteServicio(IRepositorio<Dominio.Entidades.DetalleCtaCte> repositorio)
        {
            _repositorio = repositorio;


        }

        public async Task<IEnumerable<Dominio.Entidades.DetalleCtaCte>> GetAll()
        {
            return await _repositorio.GetAll(x => x.OrderBy(y => y.Periodo));
        }

        public async Task<IEnumerable<Dominio.Entidades.DetalleCtaCte>> GetByFilter(string filtro)
        {
            Expression<Func<Dominio.Entidades.DetalleCtaCte, bool>> exp = x => true;
            exp = exp.And(x => x.Periodo.StartsWith(filtro));
            return await _repositorio.GetByFilter(exp, x => x.OrderBy(y => y.Periodo), null, false);
        }

        public async Task<Dominio.Entidades.DetalleCtaCte> GetById(int id)
        {

            return await _repositorio.GetById(id, x => x.Include(y => y.Comprobante).Include(y => y.Imputacion));
        }

        public async Task Create(Dominio.Entidades.DetalleCtaCte detalleCtaCte)
        {

            await _repositorio.Create(detalleCtaCte);
        }

        public async Task Update(Dominio.Entidades.DetalleCtaCte detalleCtaCte)
        {

            await _repositorio.Update(detalleCtaCte);
        }

        public async Task Delete(Dominio.Entidades.DetalleCtaCte detalleCtaCte)
        {

            await _repositorio.Delete(detalleCtaCte);
        }

        public async Task<IEnumerable<Dominio.Entidades.DetalleCtaCte>> GetByPaciente(int pacienteid)
        {
            Expression<Func<Dominio.Entidades.DetalleCtaCte, bool>> exp = x => true;
            exp = exp.And(x => x.PacienteId == pacienteid);
            return await _repositorio.GetByFilter(exp, x => x.OrderBy(y => y.Periodo), x => x.Include(y => y.Comprobante).Include(y => y.Imputacion), false);

        }

        public async Task<IEnumerable<Dominio.Entidades.DetalleCtaCte>> GetByDeuda(int pacienteid)
        {
            Expression<Func<Dominio.Entidades.DetalleCtaCte, bool>> exp = x => true;

            exp = exp.And(x => x.PacienteId == pacienteid).And(x => x.ImputacionId == null).And(x => x.InverseImputacion.Where(y => y.ImputacionId == x.Id).Sum(y => y.Haber) != x.Debe);
            return await _repositorio.GetByFilter(exp, x => x.OrderBy(y => y.Periodo), x => x.Include(y => y.Comprobante).Include(y => y.Imputacion), false);

        }
    }
}
