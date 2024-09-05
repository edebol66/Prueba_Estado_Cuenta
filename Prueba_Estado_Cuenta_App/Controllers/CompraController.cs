using Microsoft.AspNetCore.Mvc;
using Prueba_Estado_Cuenta_App.Models.ViewModels;
using Prueba_Estado_Cuenta_App.Services;

namespace Prueba_Estado_Cuenta_App.Controllers
{
    public class CompraController : Controller
    {
        private readonly ICompraService _compraService;

        public CompraController(ICompraService compraService)
        {
            _compraService = compraService;
        }

        [HttpGet]
        public IActionResult create(int IdCliente)
        {
            try
            {
                var modelo = new CompraVM
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
        public async Task<IActionResult> Create(CompraVM compra)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var actualizacionCompra = new CompraVM
                    {
                        IdCliente = compra.IdCliente,
                        Descripcion = compra.Descripcion,
                        FechaCompra = compra.FechaCompra,
                        Monto = compra.Monto
                    };

                    bool exito = await _compraService.realizarCompra(actualizacionCompra);
                    if (exito)
                    {
                        TempData["SuccessMessage"] = "La compra se ha guardado exitosamente.";
                        return RedirectToAction("Index", "Cliente");
                    }
                }
                return View(compra);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Historial(int IdCliente)
        {
            try
            {
                var peticionHisotiral = await _compraService.obtenerHistorialPagoCompras(IdCliente);
                return View("Historial",peticionHisotiral);
            }catch (Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
        }
    }
}
