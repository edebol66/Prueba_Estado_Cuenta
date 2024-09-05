using System;
using System.Collections.Generic;

namespace Prueba_Estado_Cuenta_API.Models.Estado_Cuenta
{
    public partial class Pago
    {
        public int IdPago { get; set; }
        public int IdCuenta { get; set; }
        public double Monto { get; set; }
        public DateTime? FechaPago { get; set; }

        public virtual Cuentum IdCuentaNavigation { get; set; } = null!;
    }
}
