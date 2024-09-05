using Prueba_Estado_Cuenta_API.Models.Estado_Cuenta;
using Prueba_Estado_Cuenta_API.Models.DTO_Estado_Cuenta;
using Prueba_Estado_Cuenta_API.Repository;
using Prueba_Estado_Cuenta_API.MiddleWare;

namespace Prueba_Estado_Cuenta_API.Services
{
    public class TarjetaServices : ITarjetaService
    {
        private readonly IRepository<Tarjetum> _repositorio;
        RetornoErrores retornoError = new RetornoErrores();

        public TarjetaServices(IRepository<Tarjetum> repositorio)
        {
            _repositorio = repositorio;
        }

        public ResponseNumeroLimiteTarjeta retornoLimiteNumeroTarjeta(int idCliente)
        {
            try
            {
                var obtenerDatosLimiteTarjeta = _repositorio.limiteNumeroTarjetaCredito(idCliente);

                var resultado = obtenerDatosLimiteTarjeta.FirstOrDefault();

                if(resultado != null)
                {
                    return new ResponseNumeroLimiteTarjeta
                    {
                        NumeroTarjeta = resultado.NumeroTarjeta,
                        Limite = resultado.Limite
                    };
                }

                return new ResponseNumeroLimiteTarjeta();
            }catch (Exception ex)
            {
                retornoError.retornoErroresServicio(ex);
                return null!;
            }
        }
    }
}
