using System;
using System.Collections.Generic;

namespace Prueba_Estado_Cuenta_API.Models.Estado_Cuenta
{
    public partial class Compra
    {
        public int IdCompras { get; set; }
        public int IdCuenta { get; set; }
        public string Descripcion { get; set; } = null!;
        public double Monto { get; set; }
        public DateTime? FechaCompra { get; set; }

        public virtual Cuentum IdCuentaNavigation { get; set; } = null!;
    }
}
