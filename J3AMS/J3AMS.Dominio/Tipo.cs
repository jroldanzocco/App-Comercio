using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J3AMS.Dominio
{
    public class Tipo
    {
        public byte Id { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        [StringLength(255, ErrorMessage = "Maximo 255 caracteres")]
        public string Descripcion { get; set; }
        public bool Activo { get; set; }

        public override string ToString()
        {
            return Descripcion;
        }
    }
}
