namespace Prueba_Estado_Cuenta_App.Services
{
    public interface ICuentaService
    {
        public Task<double> obtenerSaldoActual(int idCliente);
        public Task<string> obtenerSaldoDisponible(int idCliente);
        public Task<string> obtenerMontoInteresBonficable(int idCliente);
        public Task<string> obtenerCuotaMinima(int idCliente);
        public Task<string> obtenerContadoInteres(int idCliente);
        public Task<string> obtenerTotalPagar(int idCliente);
    }
}
