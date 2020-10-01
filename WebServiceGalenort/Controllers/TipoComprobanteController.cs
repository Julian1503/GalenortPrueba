using Galenort.Aplicacion.TipoComprobante;
using Galenort.Dominio.Entidades;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebServiceGalenort.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    [Produces("application/json")]
    public class TipoComprobanteController : ControllerBase
    {
        private ITipoComprobanteServicio _tipoComprobanteServicio;
        public TipoComprobanteController(ITipoComprobanteServicio tipoComprobanteServicio)
        {
            _tipoComprobanteServicio = tipoComprobanteServicio;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var tipoComprobantes = await _tipoComprobanteServicio.GetAll();

            if (tipoComprobantes == null)
            {
                return NotFound();
            }

            return Ok(tipoComprobantes);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var tipoComprobante = await _tipoComprobanteServicio.GetById(id);

            if (tipoComprobante == null)
            {
                return NotFound();
            }
            return Ok(tipoComprobante);
        }

        [HttpGet]
        [Route("{filtro}")]
        public async Task<IActionResult> GetByFilter(string filtro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var tipoComprobantes = await _tipoComprobanteServicio.GetByFilter(filtro);

            if (tipoComprobantes == null)
            {
                return NotFound();
            }
            return Ok(tipoComprobantes);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TipoComprobante tipoComprobante)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _tipoComprobanteServicio.Create(tipoComprobante);

            return Ok(tipoComprobante);
        }

        [HttpPut]
        public async Task<IActionResult> Update(TipoComprobante tipoComprobante)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }


            await _tipoComprobanteServicio.Update(tipoComprobante);

            return Ok(tipoComprobante);

        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var tipoComprobante = await _tipoComprobanteServicio.GetById(id);

            if (tipoComprobante == null)
            {
                return NotFound();
            }

            await _tipoComprobanteServicio.Delete(tipoComprobante);

            return Ok(tipoComprobante);
        }

    }
}
