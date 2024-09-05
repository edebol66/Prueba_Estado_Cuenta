using Prueba_Estado_Cuenta_API.Models.Estado_Cuenta;
using Prueba_Estado_Cuenta_API.Models.DTO_Estado_Cuenta;
using Prueba_Estado_Cuenta_API.Repository;
using Prueba_Estado_Cuenta_API.MiddleWare;
namespace Prueba_Estado_Cuenta_API.Services
{
    public class CuentaService : ICuentaService
    {
        private readonly IRepository<Cuentum> _repositorio;
        private readonly ITarjetaService _tarjetaService;
        RetornoErrores retornoError = new RetornoErrores();

        public CuentaService(IRepository<Cuentum> repositorio,ITarjetaService tarjetaService)
        {
            _repositorio = repositorio;
            _tarjetaService = tarjetaService;
        }

        public async Task<double> obtenerSaldoActual(int IdCliente)
        {
            try
            {
                var saldoActual = await _repositorio.obtenerRegistroTabla(IdCliente);
                if(saldoActual is null) return 0;
                return saldoActual.Saldo;
            }catch (Exception ex)
            {
                retornoError.retornoErroresServicio(ex);
                return 0;
            }
        }
        public async Task<string> obtenerInteresBonificable(int IdCliente)
        {
            try
            {
                double saldoActual = await obtenerSaldoActual(IdCliente);
                var tazaInteresBonificable = await _repositorio.obtenerConfiguracionPorcentaje("IntBonificable");
                var interesBonificable = (saldoActual * tazaInteresBonificable.DatoConfiguracion);
                var retornoInteresBonificable = $"{interesBonificable:F2}";
                return retornoInteresBonificable;

            }
            catch(Exception ex)
            {
                retornoError.retornoErroresServicio(ex);
                return "";
            }
        }

        public async Task<string> obtenerSaldoDisponible(int idCliente)
        {
            try
            {
                double saldoActual = await obtenerSaldoActual(idCliente);
                var obtenerLimite = _tarjetaService.retornoLimiteNumeroTarjeta(idCliente);

                if(obtenerLimite.NumeroTarjeta is null && obtenerLimite.Limite==0){
                    obtenerLimite.Limite = 0;
                }

                var saldoDisponible = (obtenerLimite.Limite - saldoActual);
                var retornoSaldoActual = $"{saldoDisponible:F2}";
                return retornoSaldoActual;
            }
            catch (Exception ex)
            {
                retornoError.retornoErroresServicio(ex);
                return "";
            } 
        }

        public async Task<string> obtenerCuotaMinima(int idCliente)
        {
            try
            {
                double saldoActual = await obtenerSaldoActual(idCliente);
                var porcentajeCuotaMinima = await _repositorio.obtenerConfiguracionPorcentaje("SaldoMinimo");

                var cuotaMinima = (saldoActual * porcentajeCuotaMinima.DatoConfiguracion);
                var retornoCuotaMinima = $"{cuotaMinima:F2}";
                return retornoCuotaMinima;
            }
            catch (Exception ex)
            {
                retornoError.retornoErroresServicio(ex);
                return "";
            }
        }

        public async Task<string> obtenerCuotaContadoInteres(int idCliente)
        {
            try
            {
                double saldoActual = await obtenerSaldoActual(idCliente);
                var interesBonificable = await obtenerInteresBonificable(idCliente);

                var totalContadoIntereses = (double.Parse(interesBonificable) + saldoActual);
                var retornoCuotaContadoInteres = $"{totalContadoIntereses:F2}";
                return retornoCuotaContadoInteres;
            }
            catch (Exception ex)
            {
                retornoError.retornoErroresServicio(ex);
                return "";
            }
        }
    }
}
