using System;
using System.Collections.Generic;

namespace RADER.Models
{
    public partial class Archivos
    {
 

        public int IdArchivo { get; set; }
        public string? NombreArchivo { get; set; }
        public string? ExtensionArchivo { get; set; }
        public float? CapacidadArchivo { get; set; }
        public string? UbicacionArchivo { get; set; }
    }
}
