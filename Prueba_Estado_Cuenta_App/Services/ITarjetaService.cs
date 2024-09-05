using Prueba_Estado_Cuenta_App.Models;

namespace Prueba_Estado_Cuenta_App.Services
{
    public interface ITarjetaService
    {
        public Task<TarjetaLimite> obtenerLimiteTarjeta(int idCliente);
    }
}
