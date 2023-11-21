using System.ComponentModel.DataAnnotations;

namespace J3AMS.Dominio
{
    public class Producto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        [StringLength(255, ErrorMessage = "Maximo 255 caracteres")]
        public string Descripcion { get; set; }
        [Range(0, 255, ErrorMessage = "El valor debe estar entre 0 y 255.")]
        public byte IdTipo { get; set; }
        [Range(0, 255, ErrorMessage = "El valor debe estar entre 0 y 255.")]
        public byte IdMarca { get; set; }
        [Range(0, 255, ErrorMessage = "El valor debe estar entre 0 y 255.")]
        public byte IdProveedor { get; set; }
        [Required]
        public Tipo Tipo { get; set; }
        [Required]
        public Marca Marca { get; set; }
        [Required]
        public Proveedor Proveedor { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        [Range(typeof(decimal), "0", "79228162514264337593543950335", ErrorMessage = "Por favor, ingrese un número entero.")]
        public decimal PrecioCosto { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        public decimal PrecioVenta { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        [Range(0, int.MaxValue, ErrorMessage = "El stock no puede ser menor a 0.")]
        public int Stock { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        [Range(0, int.MaxValue, ErrorMessage = "El stock no puede ser menor a 0.")]
        public int StockMinimo { get; set; }
        public int Cantidad { get; set; }
        public bool Activo { get; set; }
    }
}
