using System.ComponentModel.DataAnnotations;

namespace J3AMS.Dominio.DTOs.Usuario
{
    public class LoginDto
    {
        [Required(ErrorMessage = "El nombre de usuario es requerido")]
        [MaxLength(255)]
        [RegularExpression("^[a-zA-Z0-9]+$", ErrorMessage = "El usuario solo puede contener letras y numeros")]
        public string UserName { get; set; } = null;

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "La contraseña es requerida")]
        [Display(Name = "Contraseña")]
        public string Password { get; set; } = null;
    }
}
