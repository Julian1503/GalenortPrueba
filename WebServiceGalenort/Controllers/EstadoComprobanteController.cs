using Galenort.Aplicacion.EstadoComprobante;
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
    public class EstadoComprobanteController : ControllerBase
    {
        private IEstadoComprobanteServicio _estadoComprobanteServicio;
        public EstadoComprobanteController(IEstadoComprobanteServicio estadoComprobanteServicio)
        {
            _estadoComprobanteServicio = estadoComprobanteServicio;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var estadoComprobantes = await _estadoComprobanteServicio.GetAll();

            if (estadoComprobantes == null)
            {
                return NotFound();
            }

            return Ok(estadoComprobantes);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var estadoComprobante = await _estadoComprobanteServicio.GetById(id);

            if (estadoComprobante == null)
            {
                return NotFound();
            }
            return Ok(estadoComprobante);
        }

        [HttpGet]
        [Route("{filtro}")]
        public async Task<IActionResult> GetByFilter(string filtro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var estadoComprobantes = await _estadoComprobanteServicio.GetByFilter(filtro);

            if (estadoComprobantes == null)
            {
                return NotFound();
            }
            return Ok(estadoComprobantes);
        }
        [HttpPost]
        public async Task<IActionResult> Create(EstadoComprobante estadoComprobante)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _estadoComprobanteServicio.Create(estadoComprobante);

            return Ok(estadoComprobante);
        }
        [HttpPut]
        public async Task<IActionResult> Update(EstadoComprobante estadoComprobante)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }


            await _estadoComprobanteServicio.Update(estadoComprobante);

            return Ok(estadoComprobante);

        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var estadoComprobante = await _estadoComprobanteServicio.GetById(id);

            if (estadoComprobante == null)
            {
                return NotFound();
            }
            await _estadoComprobanteServicio.Delete(estadoComprobante);

            return Ok(estadoComprobante);
        }

    }
}
