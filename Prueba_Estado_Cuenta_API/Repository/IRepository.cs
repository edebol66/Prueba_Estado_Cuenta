using Prueba_Estado_Cuenta_API.Models.DTO_Estado_Cuenta;
using Prueba_Estado_Cuenta_API.Models.Estado_Cuenta;
namespace Prueba_Estado_Cuenta_API.Repository
{
    public interface IRepository<TEntity>
    {
        public void guardarDb(TEntity entidad);
        public List<ObtenerClienteDTO> obtenerClientes();
        public void aplicarCambiosDb();
        public Task<TEntity> obtenerRegistroTabla(int id);
        public List<NumeroLimiteTarjeta> limiteNumeroTarjetaCredito(int idCliente);
        public List<CompraMesDTO> obtenerComprasMesActual(int idCliente);
        public void realizarCompraActualizarSaldo(RequestAgregarCompra requestAgregarCompra);
        public void realizarPagoActualizarSaldo(RequestAgregarPagoDTO requestAgregarPagoDTO);
        public double obtenerMontoActualPasado(int idCliente);
        public Task<ConfiguracionPorcentaje> obtenerConfiguracionPorcentaje(string nombreConfig);
        public List<HistorialPagoComprasDTO> obtenerHistorialPagoCompras(int idCliente);
    }
}
