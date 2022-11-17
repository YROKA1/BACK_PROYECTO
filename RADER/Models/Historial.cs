using System;
using System.Collections.Generic;

namespace RADER.Models
{
    public partial class Historial
    {
       

        public int IdHistorial { get; set; }
        public int IdComponente { get; set; }
        public DateTime FechaNovedad { get; set; }
        public string? NovedadComponente { get; set; }
        public int IdEstado { get; set; }
        public int IdUsuario { get; set; }
        public string SugerenciaUsuario { get; set; } = null!;


    }
}
