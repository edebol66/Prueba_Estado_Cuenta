namespace Prueba_Estado_Cuenta_API.Models.DTO_Estado_Cuenta
{
    public class CompraMesDTO
    {
        public string Descripcion { get; set; } = null!;
        public double Monto { get; set; }
        public DateTime? FechaCompra { get; set; }
    }
}
