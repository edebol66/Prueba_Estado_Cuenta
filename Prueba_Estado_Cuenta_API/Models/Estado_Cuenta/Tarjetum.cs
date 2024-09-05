using System;
using System.Collections.Generic;

namespace Prueba_Estado_Cuenta_API.Models.Estado_Cuenta
{
    public partial class Tarjetum
    {
        public int IdTarjeta { get; set; }
        public int IdTipoTarjeta { get; set; }
        public int IdCuenta { get; set; }
        public string NumeroTarjeta { get; set; } = null!;
        public DateTime? FechaCreacion { get; set; }

        public virtual Cuentum IdCuentaNavigation { get; set; } = null!;
        public virtual TipoTarjetum IdTipoTarjetaNavigation { get; set; } = null!;
    }
}
