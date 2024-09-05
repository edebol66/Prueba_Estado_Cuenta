using System;
using System.Collections.Generic;

namespace Prueba_Estado_Cuenta_API.Models.Estado_Cuenta
{
    public partial class Cliente
    {
        public Cliente()
        {
            Cuenta = new HashSet<Cuentum>();
        }

        public int IdCliente { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public string Telefono { get; set; } = null!;

        public virtual ICollection<Cuentum> Cuenta { get; set; }
    }
}
