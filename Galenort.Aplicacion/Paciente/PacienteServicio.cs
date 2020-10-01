using Galenort.Dominio.Extension;
using Galenort.Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Galenort.Aplicacion.Paciente
{
    public class PacienteServicio : IPacienteServicio
    {

        private IRepositorio<Dominio.Entidades.Paciente> _repositorio;

        public PacienteServicio(IRepositorio<Dominio.Entidades.Paciente> repositorio)
        {
            _repositorio = repositorio;


        }

        public async Task<IEnumerable<Dominio.Entidades.Paciente>> GetAll()
        {
            return await _repositorio.GetAll();
        }

        public async Task<IEnumerable<Dominio.Entidades.Paciente>> GetByFilter(string filtro)
        {
            Expression<Func<Dominio.Entidades.Paciente, bool>> exp = x => true;
            exp = exp.And(x => x.Apellido.StartsWith(filtro));
            return await _repositorio.GetByFilter(exp, x => x.OrderBy(y => y.Apellido), null, false);
        }

        public async Task<Dominio.Entidades.Paciente> GetById(int id)
        {
            return await _repositorio.GetById(id, null, false);

        }

        public async Task Create(Dominio.Entidades.Paciente paciente)
        {
            await _repositorio.Create(paciente);
        }

        public async Task Update(Dominio.Entidades.Paciente paciente)
        {
            await _repositorio.Update(paciente);
        }

        public async Task Delete(Dominio.Entidades.Paciente paciente)
        {
            await _repositorio.Delete(paciente);
        }
    }
}
