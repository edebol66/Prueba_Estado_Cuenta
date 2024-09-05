using Microsoft.AspNetCore.Mvc;
using Prueba_Estado_Cuenta_API.Services;
using Prueba_Estado_Cuenta_API.MiddleWare;

namespace Prueba_Estado_Cuenta_API.Controllers
{
    public class CuentaController : Controller
    {
        private readonly ICuentaService _cuentaService;
        RetornoErrores retornoErrores = new RetornoErrores();

        public CuentaController(ICuentaService cuentaService)
        {
            _cuentaService = cuentaService;
        }

        [HttpGet("obtenerSaldoActual/{IdCliente:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> consultarSaldoActual(int IdCliente)
        {
            try
            {
                var obtenerSaldoActual = await _cuentaService.obtenerSaldoActual(IdCliente);
                return Ok(obtenerSaldoActual);
            }
            catch (Exception ex)
            {
                retornoErrores.retornoErrorControlador(ex);
                return BadRequest();
            }
        }

        [HttpGet("obtenerSaldoDisponible/{IdCliente:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> consultarSaldoDisponible(int IdCliente)
        {
            try
            {
                var saldoDisponible = await _cuentaService.obtenerSaldoDisponible(IdCliente);
                return Ok(saldoDisponible);
            }
            catch (Exception ex)
            {
                retornoErrores.retornoErrorControlador(ex);
                return BadRequest();
            }
        }

        [HttpGet("obtenerInteresBonificable/{IdCliente:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> consultarInteresBonificable(int IdCliente)
        {
            try
            {
                var retornoInteresBonificable = await _cuentaService.obtenerInteresBonificable(IdCliente);
                return Ok(retornoInteresBonificable);
            }
            catch (Exception ex)
            {
                retornoErrores.retornoErrorControlador(ex);
                return BadRequest();
            }
        }

        [HttpGet("obtenerCuotaMinima/{IdCliente:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> consultarCuotaMinima(int IdCliente)
        {
            try
            {
                var retornoCuotaMinima = await _cuentaService.obtenerCuotaMinima(IdCliente);
                return Ok(retornoCuotaMinima);
            }
            catch (Exception ex)
            {
                retornoErrores.retornoErrorControlador(ex);
                return BadRequest();
            }
        }

        [HttpGet("obtenerTotalPagarContado/{IdCliente:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> consultarCuotaTotalPagar(int IdCliente)
        {
            try
            {
                var obtenerSaldoActual = await _cuentaService.obtenerSaldoActual(IdCliente);

                var retornoCuotaTotalPagar = $"{obtenerSaldoActual:F2}";
                return Ok(retornoCuotaTotalPagar);
            }
            catch (Exception ex)
            {
                retornoErrores.retornoErrorControlador(ex);
                return BadRequest();
            }
        }

        [HttpGet("obtenerTotalContadoIntereses/{IdCliente:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> consultarCuotaContadoIntereses(int IdCliente)
        {
            try
            {
                var retornoCuotaTotalPagar = await _cuentaService.obtenerCuotaContadoInteres(IdCliente);
                
                return Ok(retornoCuotaTotalPagar);
            }
            catch (Exception ex)
            {
                retornoErrores.retornoErrorControlador(ex);
                return BadRequest();
            }
        }
    }
}
