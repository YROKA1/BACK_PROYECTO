using System;
using System.Collections.Generic;

namespace RADER.Models
{
    public partial class Componente
    {
 

        public int IdComponente { get; set; }
        public string NombreComponente { get; set; } = null!;
        public string? DescripcionComponente { get; set; }
        public int IdDispositivo { get; set; }
        public DateTime FechacompraComponente { get; set; }
        public DateTime? FinvidautilComponente { get; set; }
    }
}
