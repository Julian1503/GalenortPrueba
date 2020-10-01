using Galenort.Dominio.Extension;
using Galenort.Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Galenort.Aplicacion.Persona
{
    public class PersonaServicio : IPersonaServicio
    {
        private IRepositorio<Dominio.Entidades.Persona> _repositorio;

        public PersonaServicio(IRepositorio<Dominio.Entidades.Persona> repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<IEnumerable<Dominio.Entidades.Persona>> GetAll()
        {
            return await _repositorio.GetAll(x => x.OrderBy(y => y.Apellido), null, false);
        }

        public async Task<IEnumerable<Dominio.Entidades.Persona>> GetByFilter(string filtro)
        {
            Expression<Func<Dominio.Entidades.Persona, bool>> exp = x => true;
            exp = exp.And(x => x.Apellido.StartsWith(filtro));
            return await _repositorio.GetByFilter(exp, x => x.OrderBy(y => y.Apellido), null, false);
        }

        public async Task<Dominio.Entidades.Persona> GetById(int id)
        {
            return await _repositorio.GetById(id, null, false);
        }

        public async Task Create(Dominio.Entidades.Persona persona)
        {
            await _repositorio.Create(persona);
        }

        public async Task Update(Dominio.Entidades.Persona persona)
        {
            await _repositorio.Update(persona);
        }

        public async Task Delete(Dominio.Entidades.Persona persona)
        {
            await _repositorio.Delete(persona);
        }
    }
}
