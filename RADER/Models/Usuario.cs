using System;
using System.Collections.Generic;

namespace RADER.Models
{
    public partial class Usuario
    {
   

        public int IdUsuario { get; set; }
        public string ClaveUsuario { get; set; } = null!;
        public int IdPerfil { get; set; }
        public string? NombreUsuario { get; set; }

    }
}
