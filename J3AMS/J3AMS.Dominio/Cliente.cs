using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J3AMS.Dominio
{
    public class Cliente
    {
        public int Id { get; set; }
        [RegularExpression(@"^[A-Za-z]+(?: [A-Za-z]+)*$", ErrorMessage = "El nombre no es válido.")]
        [Required(ErrorMessage = "El campo es requerido")]
        [StringLength(50, ErrorMessage = "Maximo 50 caracteres")]
        public string Apellidos { get; set; }
        [StringLength(100, ErrorMessage = "Maximo 100 caracteres")] 
        public string Nombres { get; set; }
        [StringLength(100, ErrorMessage = "Maximo 100 caracteres")]
        public string DNI { get; set; }
        public string Domicilio { get; set; }
        [StringLength(20, ErrorMessage = "Maximo 20 caracteres")]
        public string Telefono { get; set; }
        public string Celular { get; set; }

        public CategoriaIva categoriaIva { get; set; }
        public int Plazo { get; set; }

        [RegularExpression(@"^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$", ErrorMessage = "El correo debe ser valido.")]
        [StringLength(100, ErrorMessage = "Maximo 100 caracteres")]
        public string Email { get; set; }
    }
}
