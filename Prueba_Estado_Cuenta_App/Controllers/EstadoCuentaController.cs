using Microsoft.AspNetCore.Mvc;
using Prueba_Estado_Cuenta_App.Models;
using Prueba_Estado_Cuenta_App.Models.ModelsGeneral;
using Prueba_Estado_Cuenta_App.Services;

namespace Prueba_Estado_Cuenta_App.Controllers
{
    public class EstadoCuentaController : Controller
    {
        private readonly IClienteService _clienteService;
        private readonly ITarjetaService _tarjetaService;
        private readonly ICuentaService _cuentaService;
        private readonly ICompraService _compraService;

        public EstadoCuentaController(IClienteService clienteService,ITarjetaService tarjetaService,
            ICuentaService cuentaService, ICompraService compraService)
        {
            _clienteService = clienteService;
            _tarjetaService = tarjetaService;
            _cuentaService = cuentaService;
            _compraService = compraService;
        }
        
        public async Task<IActionResult> Index(int idCliente)
        {
            try
            {
                Cliente cliente = new();
                Saldo saldoA = new();
                var tarjetaLimite = await _tarjetaService.obtenerLimiteTarjeta(idCliente);
                var nombreCliente = await _clienteService.obtenerNombreCliente(idCliente);
                var saldoDisponible = await _cuentaService.obtenerSaldoDisponible(idCliente);
                var saldoActual = await _cuentaService.obtenerSaldoActual(idCliente);
                var comprasMesActual = await _compraService.obtenerCompraMesActual(idCliente);
                var montoTotalCompras = await _compraService.obtenerMontoTotalCompras(idCliente);
                var inicialFecha = _compraService.obtenerInicialesMes();
                var interesBonficable = await _cuentaService.obtenerMontoInteresBonficable(idCliente);
                var cuotaMinima = await _cuentaService.obtenerCuotaMinima(idCliente);
                var contadoConInteres = await _cuentaService.obtenerContadoInteres(idCliente);
                var totalPagar = await _cuentaService.obtenerTotalPagar(idCliente);

                cliente.Nombre = nombreCliente;

                saldoA.saldoDisponible = saldoDisponible;
                saldoA.saldoActual = saldoActual;
                saldoA.montoTotal = montoTotalCompras;
                saldoA.interesBonificable = interesBonficable;
                saldoA.contadoConInteres = contadoConInteres;
                saldoA.totalPagar = totalPagar;
                saldoA.cuotaMinima = cuotaMinima;

                var viewModel = new EstadoCuentaVM
                {
                    Cliente = cliente,
                    TarjetaLimites = tarjetaLimite,
                    Saldo = saldoA,
                    Compra = comprasMesActual,
                    inicialesFecha = inicialFecha

                };
                return View(viewModel);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
        }
    }
}
