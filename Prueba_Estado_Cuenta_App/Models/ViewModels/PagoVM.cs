using System.ComponentModel.DataAnnotations;

namespace Prueba_Estado_Cuenta_App.Models.ViewModels
{
    public class PagoVM
    {
        public int IdCliente { get; set; }
        [Required(ErrorMessage = "El campo Monto es obligatorio.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El monto debe ser mayor que cero.")]
        public double Monto { get; set; }
        [Required(ErrorMessage = "El campo Fecha de pago es obligatorio.")]
        [DataType(DataType.Date)]
        public DateTime? FechaPago { get; set; }
    }
}
