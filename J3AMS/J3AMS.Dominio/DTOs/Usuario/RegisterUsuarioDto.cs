namespace J3AMS.Dominio.DTOs.Usuario
{
    public class RegisterUsuarioDto : LoginDto
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }
}
