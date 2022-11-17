using System;
using System.Collections.Generic;

namespace RADER.Models
{
    public partial class Sugerencium
    {
        public int IdSugerencia { get; set; }
        public int IdUsuario { get; set; }
        public string DescripcionSugerencia { get; set; } = null!;

        
    }
}
