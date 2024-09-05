using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
namespace Prueba_Estado_Cuenta_API.Models.DTO_Estado_Cuenta
{
    public class RequestAgregarCompra
    {
        [Required(ErrorMessage ="El campo {0} es requerido")]
        public int? IdCliente { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Descripcion { get; set; } = null!;
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public double? Monto { get; set; }
        public DateTime? FechaCompra { get; set; }
    }
}
