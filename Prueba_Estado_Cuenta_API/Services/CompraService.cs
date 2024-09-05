using AutoMapper;
using Prueba_Estado_Cuenta_API.Models.Estado_Cuenta;
using Prueba_Estado_Cuenta_API.Models.DTO_Estado_Cuenta;
using Prueba_Estado_Cuenta_API.Repository;
using Prueba_Estado_Cuenta_API.MiddleWare;
namespace Prueba_Estado_Cuenta_API.Services
{
    public class CompraService : ICompraService
    {
        private readonly IRepository<Compra> _repository;
        private readonly IRepository<Cuentum> _repositoryCuenta;
        RetornoErrores retorno = new RetornoErrores();

        public CompraService(IRepository<Compra> repository,IRepository<Cuentum> repositoyCuenta)
        {
            _repository = repository;
            _repositoryCuenta = repositoyCuenta;
        }

        public List<CompraMesDTO> retornoCompraMes(int idCliente)
        {
            try
            {
                return _repository.obtenerComprasMesActual(idCliente);
            }catch (Exception ex)
            {
                retorno.retornoErroresServicio(ex);
                return new List<CompraMesDTO>();
            }
        }

        public string agregarCompra(RequestAgregarCompra agregarCompraDTO)
        {
            try
            {
                _repository.realizarCompraActualizarSaldo(agregarCompraDTO);

                return "Compra almacenada correctamente";
            }
            catch (Exception ex)
            {
                retorno.retornoErroresServicio(ex);
                return "";
            }
        }

        public string obtenerMontoMesActualPasado(int idCliente)
        {
            try
            {
                var monto = _repository.obtenerMontoActualPasado(idCliente);
                var retornoMontoParseado = $"{monto:F2}";
                return retornoMontoParseado;
            }catch (Exception ex)
            {
                retorno.retornoErroresServicio(ex);
                return "";
            }
        }

        public List<HistorialPagoComprasDTO> obtenerHistorialComprasPagos(int idCliente)
        {
            try
            {
                var retornoHistorial = _repository.obtenerHistorialPagoCompras(idCliente);
                return retornoHistorial;
            }catch(Exception ex)
            {
                retorno.retornoErroresServicio(ex);
                return new List<HistorialPagoComprasDTO>();
            }
        }
    }
}
