using System;
using System.Collections.Generic;

namespace RADER.Models
{
    public partial class Perfil
    {
        public Perfil()
        {
           
        }

        public int IdPerfil { get; set; }
        public string NombrePerfil { get; set; } = null!;
        public string DescripcionPerfil { get; set; } = null!;

   
    }
}
