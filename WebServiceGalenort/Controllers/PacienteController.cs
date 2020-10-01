using Galenort.Aplicacion.Paciente;
using Galenort.Dominio.Entidades;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebServiceGalenort.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    [Produces("application/json")]
    public class PacienteController : ControllerBase
    {
        private IPacienteServicio _pacienteServicio;
        public PacienteController(IPacienteServicio pacienteServicio)
        {
            _pacienteServicio = pacienteServicio;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var pacientes = await _pacienteServicio.GetAll();

            if (pacientes == null)
            {
                return NotFound();
            }

            return Ok(pacientes);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var paciente = await _pacienteServicio.GetById(id);

            if (paciente == null)
            {
                return NotFound();
            }
            return Ok(paciente);
        }

        [HttpGet]
        [Route("{filtro}")]
        public async Task<IActionResult> GetByFilter(string filtro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var pacientes = await _pacienteServicio.GetByFilter(filtro);

            if (pacientes == null)
            {
                return NotFound();
            }
            return Ok(pacientes);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Paciente paciente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _pacienteServicio.Create(paciente);

            return Ok(paciente);
        }
        [HttpPut]
        public async Task<IActionResult> Update(Paciente paciente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _pacienteServicio.Update(paciente);

            return Ok(paciente);

        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var paciente = await _pacienteServicio.GetById(id);

            if (paciente == null)
            {
                return NotFound();
            }

            await _pacienteServicio.Delete(paciente);

            return Ok(paciente);
        }

    }
}
