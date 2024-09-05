using Microsoft.AspNetCore.Mvc;
using Prueba_Estado_Cuenta_API.Services;
using Prueba_Estado_Cuenta_API.Models.DTO_Estado_Cuenta;
using Prueba_Estado_Cuenta_API.MiddleWare;

namespace Prueba_Estado_Cuenta_API.Controllers
{
    public class CompraController : Controller
    {
        private readonly ICompraService _compraService;
        RetornoErrores retorno = new RetornoErrores();

        public CompraController(ICompraService compraService)
        {
            _compraService = compraService;
        }

        [HttpGet("obtenerCompraMesActual/{IdCliente:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult consultarCompraMesActual(int IdCliente)
        {
            try
            {
                var comprasMesActual = _compraService.retornoCompraMes(IdCliente);
                return Ok(comprasMesActual);
            }
            catch (Exception ex)
            {
                retorno.retornoErrorControlador(ex);
                return BadRequest();
            }
        }

        [HttpPost("agregarCompra")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult agregarNuevaCompra([FromBody] RequestAgregarCompra agregarCompra)
        {
            try
            {
                if(!ModelState.IsValid) return BadRequest(ErrorHelper.getModelStateError(ModelState));
                var nuevaCompra = _compraService.agregarCompra(agregarCompra);
                return Ok(nuevaCompra);
            }
            catch (Exception ex)
            {
                retorno.retornoErrorControlador(ex);
                return BadRequest();
            }
        }

        [HttpGet("obtenerMontoMesAntAct/{IdCliente:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult consultarMontoMesAnteriorctual(int IdCliente)
        {
            try
            {
                var montoComprasActual = _compraService.obtenerMontoMesActualPasado(IdCliente);
                return Ok(montoComprasActual);
            }
            catch (Exception ex)
            {
                retorno.retornoErrorControlador(ex);
                return BadRequest();
            }
        }

        [HttpGet("obtenerHistorial/{IdCliente:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult consultarHistorialCompraPago(int IdCliente)
        {
            try
            {
                var historialCompraPago = _compraService.obtenerHistorialComprasPagos(IdCliente);
                return Ok(historialCompraPago);
            }
            catch (Exception ex)
            {
                retorno.retornoErrorControlador(ex);
                return BadRequest();
            }
        }
    }
}
