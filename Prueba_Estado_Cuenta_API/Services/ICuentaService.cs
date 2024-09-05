namespace Prueba_Estado_Cuenta_API.Services
{
    public interface ICuentaService
    {
        public Task<double> obtenerSaldoActual(int IdCliente);
        public Task<string> obtenerInteresBonificable(int IdCliente);
        public Task<string> obtenerSaldoDisponible(int idCliente);
        Task<string> obtenerCuotaMinima(int idCliente);
        Task<string> obtenerCuotaContadoInteres(int idCliente);
    }
}
