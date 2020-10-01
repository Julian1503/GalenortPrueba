using Galenort.Dominio.Extension;
using Galenort.Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Galenort.Aplicacion.Parentezco
{
    public class ParentezcoServicio : IParentezcoServicio
    {

        private IRepositorio<Dominio.Entidades.Parentezco> _repositorio;

        public ParentezcoServicio(IRepositorio<Dominio.Entidades.Parentezco> repositorio)
        {
            _repositorio = repositorio;


        }

        public async Task<IEnumerable<Dominio.Entidades.Parentezco>> GetAll()
        {
            return await _repositorio.GetAll();
        }

        public async Task<IEnumerable<Dominio.Entidades.Parentezco>> GetByFilter(string filtro)
        {
            Expression<Func<Dominio.Entidades.Parentezco, bool>> exp = x => true;
            exp = exp.And(x => x.Descripcion.StartsWith(filtro));
            return await _repositorio.GetByFilter(exp, x => x.OrderBy(y => y.Descripcion), null, false);
        }

        public async Task<Dominio.Entidades.Parentezco> GetById(int id)
        {
            return await _repositorio.GetById(id, null, false);
        }

        public async Task Create(Dominio.Entidades.Parentezco parentezco)
        {
            await _repositorio.Create(parentezco);
        }

        public async Task Update(Dominio.Entidades.Parentezco parentezco)
        {
            await _repositorio.Update(parentezco);
        }

        public async Task Delete(Dominio.Entidades.Parentezco parentezco)
        {
            await _repositorio.Delete(parentezco);
        }
    }
}
