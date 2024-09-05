using System.ComponentModel.DataAnnotations;
namespace Prueba_Estado_Cuenta_App.Models.ViewModels
{
    public class CompraVM
    {
        public int IdCliente { get; set; }
        [Required(ErrorMessage = "El campo Descripción es obligatorio.")]
        public string? Descripcion { get; set; }
        [Required(ErrorMessage = "El campo Monto es obligatorio.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El monto debe ser mayor que cero.")]
        public double Monto { get; set; }
        [Required(ErrorMessage = "El campo Fecha de Compra es obligatorio.")]
        [DataType(DataType.Date)]
        public DateTime? FechaCompra { get; set; }
    }
}
