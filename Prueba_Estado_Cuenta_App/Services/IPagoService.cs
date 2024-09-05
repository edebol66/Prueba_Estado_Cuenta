using Prueba_Estado_Cuenta_App.Models.ViewModels;
using System.Text.Json;

namespace Prueba_Estado_Cuenta_App.Services
{
    public interface IPagoService
    {
        public Task<bool> realizarPago(PagoVM pago);
    }
}
