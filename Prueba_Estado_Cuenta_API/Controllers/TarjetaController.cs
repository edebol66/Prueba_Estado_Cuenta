using Microsoft.AspNetCore.Mvc;
using Prueba_Estado_Cuenta_API.Models.Estado_Cuenta;
using Prueba_Estado_Cuenta_API.Models.DTO_Estado_Cuenta;
using Prueba_Estado_Cuenta_API.Services;
using Prueba_Estado_Cuenta_API.MiddleWare;


namespace Prueba_Estado_Cuenta_API.Controllers
{
    public class TarjetaController : Controller
    {
        private readonly ITarjetaService _tarjetaService;
        RetornoErrores retornoErrores= new RetornoErrores();

        public TarjetaController(ITarjetaService tarjetaService)
        {
            _tarjetaService = tarjetaService;
        }

        [HttpGet("ConsultarLimiteNumero/{IdCliente:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult consultaLimiteNumeroTarjeta(int IdCliente)
        {
            try
            {
                var informacion = _tarjetaService.retornoLimiteNumeroTarjeta(IdCliente);

                return Ok(informacion);

            }catch (Exception ex)
            {
                retornoErrores.retornoErrorControlador(ex);
                return BadRequest();
            }
        }

    }
}
