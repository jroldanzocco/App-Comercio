using J3AMS.Dominio.DTOs.Usuario;

namespace J3AMS.Dominio
{

    public class UsuarioDto : RegisterUsuarioDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Rol { get; set; } = null;
        public int IdRol { get; set; }

    }
}
