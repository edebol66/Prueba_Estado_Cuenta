using Prueba_Estado_Cuenta_API.Models.Estado_Cuenta;
using Prueba_Estado_Cuenta_API.Models.DTO_Estado_Cuenta;
using Prueba_Estado_Cuenta_API.Repository;
using Prueba_Estado_Cuenta_API.MiddleWare;
namespace Prueba_Estado_Cuenta_API.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IRepository<Cliente> _repositorio;
        RetornoErrores retornoError = new RetornoErrores(); 

        public ClienteService (IRepository<Cliente> repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<string> obtenerNombreCliente(int idCliente)
        {
            try
            {
                var obtenerNombre = await _repositorio.obtenerRegistroTabla(idCliente);
                return obtenerNombre.Nombre.ToString() + " " + obtenerNombre.Apellido.ToString();
            }catch (Exception ex)
            {
                retornoError.retornoErroresServicio(ex);
                return "";
            }
        }

        public List<ObtenerClienteDTO> obtenerClientes()
        {
            try
            {
                var obtenerCliente = _repositorio.obtenerClientes();
                return obtenerCliente;
            }catch(Exception ex)
            {
                retornoError.retornoErroresServicio(ex);
                return new List<ObtenerClienteDTO>();
            }
        }
    }
}
