using System.ComponentModel.DataAnnotations;

namespace J3AMS.Dominio
{
    public class CategoriaIva
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        [StringLength(255, ErrorMessage = "El campo no puede superar los 255 caracteres")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        public decimal PorcentajeIva { get; set; }

        public override string ToString()
        {
            return Descripcion;
        }
    }
}
