using System;
using System.Collections.Generic;

namespace RADER.Models
{
    public partial class Alertum
    {
        public int IdAlerta { get; set; }
        public int IdHistorial { get; set; }
        public string TipoAlerta { get; set; } = null!;
        public int IdPerfil { get; set; }

    }
}
