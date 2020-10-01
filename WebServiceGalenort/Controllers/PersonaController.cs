using Galenort.Aplicacion;
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
    public class PersonaController : ControllerBase
    {
        private IPersonaServicio _personaServicio;
        public PersonaController(IPersonaServicio personaServicio)
        {
            _personaServicio = personaServicio;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var personas = await _personaServicio.GetAll();

            if (personas == null)
            {
                return NotFound();
            }

            return Ok(personas);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var persona = await _personaServicio.GetById(id);

            if (persona == null)
            {
                return NotFound();
            }
            return Ok(persona);
        }

        [HttpGet]
        [Route("{filtro}")]
        public async Task<IActionResult> GetByFilter(string filtro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var personas = await _personaServicio.GetByFilter(filtro);

            if (personas == null)
            {
                return NotFound();
            }
            return Ok(personas);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Persona persona)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _personaServicio.Create(persona);

            return Ok(persona);
        }
        [HttpPut]
        public async Task<IActionResult> Update(Persona persona)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }


            await _personaServicio.Update(persona);

            return Ok(persona);

        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var persona = await _personaServicio.GetById(id);

            if (persona == null)
            {
                return NotFound();
            }

            await _personaServicio.Delete(persona);

            return Ok(persona);
        }


    }
}
