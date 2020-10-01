using Galenort.Aplicacion.Parentezco;
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
    public class ParentezcoController : ControllerBase
    {
        private IParentezcoServicio _parentezcoServicio;
        public ParentezcoController(IParentezcoServicio parentezcoServicio)
        {
            _parentezcoServicio = parentezcoServicio;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var parentezcos = await _parentezcoServicio.GetAll();

            if (parentezcos == null)
            {
                return NotFound();
            }

            return Ok(parentezcos);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var parentezco = await _parentezcoServicio.GetById(id);

            if (parentezco == null)
            {
                return NotFound();
            }
            return Ok(parentezco);
        }

        [HttpGet]
        [Route("{filtro}")]
        public async Task<IActionResult> GetByFilter(string filtro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var parentezcos = await _parentezcoServicio.GetByFilter(filtro);

            if (parentezcos == null)
            {
                return NotFound();
            }
            return Ok(parentezcos);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Parentezco parentezco)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _parentezcoServicio.Create(parentezco);

            return Ok(parentezco);
        }
        [HttpPut]
        public async Task<IActionResult> Update(Parentezco parentezco)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _parentezcoServicio.Update(parentezco);

            return Ok(parentezco);

        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var parentezco = await _parentezcoServicio.GetById(id);

            if (parentezco == null)
            {
                return NotFound();
            }

            await _parentezcoServicio.Delete(parentezco);

            return Ok(parentezco);
        }

    }
}
