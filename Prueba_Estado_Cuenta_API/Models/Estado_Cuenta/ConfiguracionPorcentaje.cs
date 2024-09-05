using System;
using System.Collections.Generic;

namespace Prueba_Estado_Cuenta_API.Models.Estado_Cuenta
{
    public partial class ConfiguracionPorcentaje
    {
        public int IdConfiguracionPorcentajes { get; set; }
        public string NombreConfiguracion { get; set; } = null!;
        public double? DatoConfiguracion { get; set; }
    }
}
