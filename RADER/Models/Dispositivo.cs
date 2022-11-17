using System;
using System.Collections.Generic;

namespace RADER.Models
{
    public partial class Dispositivo
    {


        public int IdDispositivo { get; set; }
        public string NombreDispositivo { get; set; } = null!;
        public int IdEmpresa { get; set; }
        public string LargoDispositivo { get; set; } = null!;
        public string AnchoDispositivo { get; set; } = null!;
        public string AltoDispositivo { get; set; } = null!;
        public string PesoDispositivo { get; set; } = null!;

    }
}
