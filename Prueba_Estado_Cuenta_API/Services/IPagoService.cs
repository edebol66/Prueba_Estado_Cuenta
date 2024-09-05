using Prueba_Estado_Cuenta_API.Models.DTO_Estado_Cuenta;
namespace Prueba_Estado_Cuenta_API.Services
{
    public interface IPagoService
    {
        public string realizarPago(RequestAgregarPagoDTO agregarPagoDTO);
    }
}
