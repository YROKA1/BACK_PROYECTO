using System;
using System.Collections.Generic;

namespace RADER.Models
{
    public partial class Estado
    {
  

        public int IdEstado { get; set; }
        public string NombreEstado { get; set; } = null!;
        public string DescripcionEstado { get; set; } = null!;
        public string? Acciones { get; set; }

       
    }
}
