using Prueba_Estado_Cuenta_App.Models;

namespace Prueba_Estado_Cuenta_App.Services
{
    public interface IClienteService
    {
        public Task<List<Cliente>> obtenerNombres();
        public Task<string> obtenerNombreCliente(int idCliente);
    }
}
