using Galenort.Aplicacion.DetalleCtaCte;
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
    public class DetalleCtaCteController : ControllerBase
    {
        private IDetalleCtaCteServicio _detalleCtaCteServicio;
        public DetalleCtaCteController(IDetalleCtaCteServicio detalleCtaCteServicio)
        {
            _detalleCtaCteServicio = detalleCtaCteServicio;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var detalleCtaCtes = await _detalleCtaCteServicio.GetAll();

            if (detalleCtaCtes == null)
            {
                return NotFound();
            }

            return Ok(detalleCtaCtes);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var detalleCtaCte = await _detalleCtaCteServicio.GetById(id);

            if (detalleCtaCte == null)
            {
                return NotFound();
            }
            return Ok(detalleCtaCte);
        }

        [HttpGet]
        [Route("{filtro}")]
        public async Task<IActionResult> GetByFilter(string filtro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var detalleCtaCtes = await _detalleCtaCteServicio.GetByFilter(filtro);

            if (detalleCtaCtes == null)
            {
                return NotFound();
            }
            return Ok(detalleCtaCtes);
        }

        [HttpGet]
        [Route("GetByPaciente/{pacienteid:int}")]
        public async Task<IActionResult> GetByFilter(int pacienteid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var detalleCtaCtes = await _detalleCtaCteServicio.GetByPaciente(pacienteid);

            if (detalleCtaCtes == null)
            {
                return NotFound();
            }
            return Ok(detalleCtaCtes);
        }


        [HttpGet]
        [Route("GetByDeuda/{pacienteid:int}")]
        public async Task<IActionResult> GetByDeuda(int pacienteid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var detalleCtaCtes = await _detalleCtaCteServicio.GetByDeuda(pacienteid);

            if (detalleCtaCtes == null)
            {
                return NotFound();
            }
            return Ok(detalleCtaCtes);
        }


        [HttpPost]
        public async Task<IActionResult> Create(DetalleCtaCte detalleCtaCte)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _detalleCtaCteServicio.Create(detalleCtaCte);

            return Ok(detalleCtaCte);
        }
        [HttpPut]
        public async Task<IActionResult> Update(DetalleCtaCte detalleCtaCte)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }


            await _detalleCtaCteServicio.Update(detalleCtaCte);

            return Ok(detalleCtaCte);

        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var detalleCtaCte = await _detalleCtaCteServicio.GetById(id);

            if (detalleCtaCte == null)
            {
                return NotFound();
            }

            await _detalleCtaCteServicio.Delete(detalleCtaCte);

            return Ok(detalleCtaCte);
        }

    }
}
