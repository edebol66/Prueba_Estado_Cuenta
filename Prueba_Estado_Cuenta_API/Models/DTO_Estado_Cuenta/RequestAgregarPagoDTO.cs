using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Prueba_Estado_Cuenta_API.Models.DTO_Estado_Cuenta
{
    public class RequestAgregarPagoDTO
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int? IdCliente { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public double? Monto { get; set; }
        public DateTime? FechaPago { get; set; }
    }
}
