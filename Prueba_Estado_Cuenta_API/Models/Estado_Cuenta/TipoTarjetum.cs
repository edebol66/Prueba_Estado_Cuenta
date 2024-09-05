using System;
using System.Collections.Generic;

namespace Prueba_Estado_Cuenta_API.Models.Estado_Cuenta
{
    public partial class TipoTarjetum
    {
        public TipoTarjetum()
        {
            Tarjeta = new HashSet<Tarjetum>();
        }

        public int IdTipoTarjeta { get; set; }
        public string TipoTarjeta { get; set; } = null!;
        public double Limite { get; set; }

        public virtual ICollection<Tarjetum> Tarjeta { get; set; }
    }
}
