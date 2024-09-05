namespace Prueba_Estado_Cuenta_API.Models.DTO_Estado_Cuenta
{
    public class HistorialPagoComprasDTO
    {
        public string? Tipo_Transaccion { get; set; }
        public string? Descripcion { get; set; }
        public double Monto { get; set; }
        public DateTime? Fecha { get; set; }
    }
}
