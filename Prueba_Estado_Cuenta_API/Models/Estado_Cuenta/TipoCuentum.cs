using System;
using System.Collections.Generic;

namespace Prueba_Estado_Cuenta_API.Models.Estado_Cuenta
{
    public partial class TipoCuentum
    {
        public TipoCuentum()
        {
            Cuenta = new HashSet<Cuentum>();
        }

        public int IdTipoCuenta { get; set; }
        public string TipoCuenta { get; set; } = null!;

        public virtual ICollection<Cuentum> Cuenta { get; set; }
    }
}
