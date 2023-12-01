using System.ComponentModel.DataAnnotations;

namespace J3AMS.Dominio
{
    public class Cliente
    {
        [Required]
        public int Id { get; set; }
        [RegularExpression(@"^[A-Za-z]+(?: [A-Za-z]+)*$", ErrorMessage = "El apellido no es válido.")]
        [Required(ErrorMessage = "El campo es requerido")]
        [StringLength(255, ErrorMessage = "Maximo 255 caracteres")]
        public string Apellidos { get; set; }
        [RegularExpression(@"^[A-Za-z]+(?: [A-Za-z]+)*$", ErrorMessage = "El nombre no es válido.")]
        [Required(ErrorMessage = "El campo es requerido")]
        [StringLength(255, ErrorMessage = "Maximo 255 caracteres")]
        public string Nombres { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        [StringLength(9, ErrorMessage = "Maximo 9 digitos")]
        [RegularExpression(@"^[A-Za-z]+(?: [A-Za-z]+)*$", ErrorMessage = "El DNI solo debe tener numeros.")]
        public string NombreCompleto => $"{Nombres} {Apellidos}";
        public string DNI { get; set; }
        [StringLength(255, ErrorMessage = "Maximo 255 caracteres")]
        public string Domicilio { get; set; }
        [StringLength(255, ErrorMessage = "Maximo 255 caracteres")]
        [RegularExpression(@"^[0-9()+\s\-]+$ ", ErrorMessage = "Telefono invalido.")]
        public string Telefono { get; set; }
        [StringLength(255, ErrorMessage = "Maximo 255 caracteres")]
        [RegularExpression(@"^[0-9()+\s\-]+$ ", ErrorMessage = "Celular invalido")]
        public string Celular { get; set; }
        [RegularExpression(@"^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$", ErrorMessage = "El correo debe ser valido.")]
        [StringLength(100, ErrorMessage = "Maximo 100 caracteres")]
        public string Email { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        [Range(0, 255, ErrorMessage = "El valor debe estar entre 0 y 255.")]
        public byte IdCategoriaIva { get; set; }
        public CategoriaIva categoriaIva { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        public byte Plazo { get; set; }
        public bool Activo { get; set; }
    }
}
