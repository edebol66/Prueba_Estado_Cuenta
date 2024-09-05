using Microsoft.AspNetCore.Mvc;
using Prueba_Estado_Cuenta_API.Services;
using Prueba_Estado_Cuenta_API.Models.DTO_Estado_Cuenta;
using Prueba_Estado_Cuenta_API.MiddleWare;

namespace Prueba_Estado_Cuenta_API.Controllers
{
    public class PagoController : Controller
    {
        private readonly IPagoService _pagoService;
        RetornoErrores retornoErrores = new RetornoErrores();

        public PagoController(IPagoService pagoService)
        {
            _pagoService = pagoService;
        }

        [HttpPost("agregarPago")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult agregarNuevaCompra([FromBody] RequestAgregarPagoDTO agregarPagoDTO)
        {
            try
            {
                var nuevoPago = _pagoService.realizarPago(agregarPagoDTO);
                return Ok(nuevoPago);
            }
            catch (Exception ex)
            {
                retornoErrores.retornoErrorControlador(ex);
                return BadRequest();
            }
        }
    }
}
