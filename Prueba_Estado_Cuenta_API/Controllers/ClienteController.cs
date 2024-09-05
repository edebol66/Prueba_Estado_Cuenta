using Microsoft.AspNetCore.Mvc;
using Prueba_Estado_Cuenta_API.Services;
using Prueba_Estado_Cuenta_API.MiddleWare;

namespace Prueba_Estado_Cuenta_API.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteService _clienteService;
        RetornoErrores retornoErrores = new RetornoErrores();

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet("obtenerNombreCliente/{IdCliente:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> consultarNombreCliente(int IdCliente)
        {
            try
            {
                var obtenerNombreCliente = await _clienteService.obtenerNombreCliente(IdCliente);
                return Ok(obtenerNombreCliente);
            }catch (Exception ex)
            {
                retornoErrores.retornoErrorControlador(ex);
                return BadRequest();
            }
        }

        [HttpGet("obtenerClientes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult consultarClientes()
        {
            try
            {
                var obtenerNombreCliente = _clienteService.obtenerClientes();
                return Ok(obtenerNombreCliente);
            }
            catch (Exception ex)
            {
                retornoErrores.retornoErrorControlador(ex);
                return BadRequest();
            }
        }
    }
}
