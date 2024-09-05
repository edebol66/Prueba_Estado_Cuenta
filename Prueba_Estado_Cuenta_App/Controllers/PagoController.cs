using Microsoft.AspNetCore.Mvc;
using Prueba_Estado_Cuenta_App.Models.ViewModels;
using Prueba_Estado_Cuenta_App.Services;

namespace Prueba_Estado_Cuenta_App.Controllers
{
    public class PagoController : Controller
    {
        private readonly IPagoService _pagoService;

        public PagoController(IPagoService pagoService)
        {
            _pagoService = pagoService;
        }

        [HttpGet]
        public IActionResult Crear( int IdCliente)
        {
            try
            {
                var modelo = new PagoVM
                {
                    IdCliente = IdCliente
                };

                return View(modelo);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> Crear(PagoVM pago)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var actualizacionPago = new PagoVM
                    {
                        IdCliente = pago.IdCliente,
                        FechaPago = pago.FechaPago,
                        Monto = pago.Monto
                    };

                    bool exito = await _pagoService.realizarPago(actualizacionPago);
                    if (exito)
                    {
                        TempData["SuccessMessage"] = "La compra se ha guardado exitosamente.";
                        return RedirectToAction("Index", "Cliente");
                    }
                }
                return View(pago);
            }catch (Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
        }
    }
}
