using System.ComponentModel.DataAnnotations;

namespace J3AMS.Dominio.DTOs.Usuario
{
    public class RegisterUsuarioDto : LoginDto
    {
        [Required(ErrorMessage = "El campo Correo Electrónico es obligatorio.")]
        [EmailAddress(ErrorMessage = "Ingrese una dirección de correo electrónico válida.")]
        [MaxLength(255, ErrorMessage ="Longitud maxima 255 caracteres.")]
        public string Email { get; set; }
    }
}
