using Microsoft.AspNetCore.Mvc;
using Prueba_Estado_Cuenta_App.Models;
using Prueba_Estado_Cuenta_App.Services;

namespace Prueba_Estado_Cuenta_App.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                var resultado = await _clienteService.obtenerNombres();

                return View(resultado);
            }
            catch(Exception ex)
            {

                return RedirectToAction("Error", "Home");
            }
            
        }
    }
}
