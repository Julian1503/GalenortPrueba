using Galenort.Aplicacion.DetalleComprobante;
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
    public class DetalleComprobanteController : ControllerBase
    {
        private IDetalleComprobanteServicio _detalleComprobanteServicio;
        public DetalleComprobanteController(IDetalleComprobanteServicio detalleComprobanteServicio)
        {
            _detalleComprobanteServicio = detalleComprobanteServicio;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var detalleComprobantes = await _detalleComprobanteServicio.GetAll();

            if (detalleComprobantes == null)
            {
                return NotFound();
            }

            return Ok(detalleComprobantes);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var detalleComprobante = await _detalleComprobanteServicio.GetById(id);

            if (detalleComprobante == null)
            {
                return NotFound();
            }
            return Ok(detalleComprobante);
        }

        [HttpGet]
        [Route("{filtro}")]
        public async Task<IActionResult> GetByFilter(string filtro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var detalleComprobantes = await _detalleComprobanteServicio.GetByFilter(filtro);

            if (detalleComprobantes == null)
            {
                return NotFound();
            }
            return Ok(detalleComprobantes);
        }
        [HttpPost]
        public async Task<IActionResult> Create(DetalleComprobante detalleComprobante)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _detalleComprobanteServicio.Create(detalleComprobante);

            return Ok(detalleComprobante);
        }
        [HttpPut]
        public async Task<IActionResult> Update(DetalleComprobante detalleComprobante)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }


            await _detalleComprobanteServicio.Update(detalleComprobante);

            return Ok(detalleComprobante);

        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var detalleComprobante = await _detalleComprobanteServicio.GetById(id);

            if (detalleComprobante == null)
            {
                return NotFound();
            }

            await _detalleComprobanteServicio.Delete(detalleComprobante);

            return Ok(detalleComprobante);
        }

    }
}
