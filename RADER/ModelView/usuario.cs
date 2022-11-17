namespace RADER.ModelView
{
    public class usuarioView
    {

        public int Id_Usuario { get; set; }
        public string Clave_Usuario { get; set; } = null!;
        public int Id_Perfil { get; set; }
        public string? Nombre_Usuario { get; set; }
    }
}
