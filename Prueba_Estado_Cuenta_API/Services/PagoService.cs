using AutoMapper;
using Prueba_Estado_Cuenta_API.Models.Estado_Cuenta;
using Prueba_Estado_Cuenta_API.Models.DTO_Estado_Cuenta;
using Prueba_Estado_Cuenta_API.Repository;
using Prueba_Estado_Cuenta_API.MiddleWare;

namespace Prueba_Estado_Cuenta_API.Services
{
    public class PagoService : IPagoService
    {
        private readonly IRepository<Pago> _repository;
        RetornoErrores retornoError = new RetornoErrores();
        public PagoService(IRepository<Pago> repository)
        {
            _repository = repository;
        }

        public string realizarPago(RequestAgregarPagoDTO agregarPagoDTO)
        {
            try
            {
                _repository.realizarPagoActualizarSaldo(agregarPagoDTO);

                return "Pago realizado exitosamente";
            }
            catch (Exception ex)
            {
                retornoError.retornoErroresServicio(ex);
                return "";
            }
        }
    }
}
