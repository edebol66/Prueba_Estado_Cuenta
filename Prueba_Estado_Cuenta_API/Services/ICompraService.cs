using Prueba_Estado_Cuenta_API.Models.DTO_Estado_Cuenta;

namespace Prueba_Estado_Cuenta_API.Services
{
    public interface ICompraService
    {
        public List<CompraMesDTO> retornoCompraMes(int idCliente);
        public string agregarCompra(RequestAgregarCompra agregarCompraDTO);
        public string obtenerMontoMesActualPasado(int idCliente);
        public List<HistorialPagoComprasDTO> obtenerHistorialComprasPagos(int idCliente);
    }
}
