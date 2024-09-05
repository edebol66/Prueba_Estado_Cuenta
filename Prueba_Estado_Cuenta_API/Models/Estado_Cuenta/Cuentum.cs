using System;
using System.Collections.Generic;

namespace Prueba_Estado_Cuenta_API.Models.Estado_Cuenta
{
    public partial class Cuentum
    {
        public Cuentum()
        {
            Compras = new HashSet<Compra>();
            Pagos = new HashSet<Pago>();
            Tarjeta = new HashSet<Tarjetum>();
        }

        public int IdCuenta { get; set; }
        public int IdCliente { get; set; }
        public int IdTipoCuenta { get; set; }
        public string NumeroCuenta { get; set; } = null!;
        public double Saldo { get; set; }
        public DateTime? FechaCuenta { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; } = null!;
        public virtual TipoCuentum IdTipoCuentaNavigation { get; set; } = null!;
        public virtual ICollection<Compra> Compras { get; set; }
        public virtual ICollection<Pago> Pagos { get; set; }
        public virtual ICollection<Tarjetum> Tarjeta { get; set; }
    }
}
