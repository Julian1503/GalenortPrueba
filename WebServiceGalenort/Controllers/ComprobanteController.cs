using Galenort.Aplicacion.Comprobante.Comprobante;
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
    public class ComprobanteController : ControllerBase
    {
        private IComprobanteServicio _comprobanteServicio;
        public ComprobanteController(IComprobanteServicio comprobanteServicio)
        {
            _comprobanteServicio = comprobanteServicio;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var comprobantes = await _comprobanteServicio.GetAll();

            if (comprobantes == null)
            {
                return NotFound();
            }

            return Ok(comprobantes);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var comprobante = await _comprobanteServicio.GetById(id);

            if (comprobante == null)
            {
                return NotFound();
            }
            return Ok(comprobante);
        }

        [HttpGet]
        [Route("{filtro}")]
        public async Task<IActionResult> GetByFilter(string filtro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var comprobantes = await _comprobanteServicio.GetByFilter(filtro);

            if (comprobantes == null)
            {
                return NotFound();
            }
            return Ok(comprobantes);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Comprobante comprobante)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _comprobanteServicio.Create(comprobante);

            return Ok(comprobante);
        }
        [HttpPut]
        public async Task<IActionResult> Update(Comprobante comprobante)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }


            await _comprobanteServicio.Update(comprobante);

            return Ok(comprobante);

        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var comprobante = await _comprobanteServicio.GetById(id);

            if (comprobante == null)
            {
                return NotFound();
            }

            await _comprobanteServicio.Delete(comprobante);

            return Ok(comprobante);
        }

    }
}
