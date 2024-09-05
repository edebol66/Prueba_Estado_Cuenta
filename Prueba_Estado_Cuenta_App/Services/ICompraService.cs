using Prueba_Estado_Cuenta_App.Models.ViewModels;
using Prueba_Estado_Cuenta_App.Models.ModelsGeneral;

namespace Prueba_Estado_Cuenta_App.Services
{
    public interface ICompraService
    {
        public Task<List<Compra>> obtenerCompraMesActual(int idCliente);
        public Task<string> obtenerMontoTotalCompras(int idCliente);
        public string obtenerInicialesMes();
        public Task<bool> realizarCompra(CompraVM compra);
        Task<List<HistorialPagoComprasVM>> obtenerHistorialPagoCompras(int idCliente);
    }
}
