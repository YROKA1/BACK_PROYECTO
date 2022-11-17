using System;
using System.Collections.Generic;

namespace RADER.Models
{
    public partial class Empresa
    {


        public int IdEmpresa { get; set; }
        public string RazonsocialEmpresa { get; set; } = null!;
        public string DireccionEmpresa { get; set; } = null!;
        public string? TelefonoEmpresa { get; set; }
        public string? LocalidadEmpresa { get; set; }

    }
}
