namespace Prueba_Estado_Cuenta_App.Models.ViewModels
{
    public class HistorialPagoComprasVM
    {
        public string? Tipo_Transaccion { get; set; }
        public string? Descripcion { get; set; }
        public double Monto { get; set; }
        public DateTime? Fecha { get; set; }
    }
}
