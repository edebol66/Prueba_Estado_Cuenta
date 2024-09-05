using Prueba_Estado_Cuenta_App.Models.ModelsGeneral;

namespace Prueba_Estado_Cuenta_App.Models
{
    public class EstadoCuentaVM
    {
        public Cliente? Cliente { get; set; }
        public TarjetaLimite? TarjetaLimites { get; set; }
        public Saldo? Saldo { get; set; }
        public IEnumerable<Compra>? Compra { get; set; }
        public string? inicialesFecha { get; set; }
    }
}
