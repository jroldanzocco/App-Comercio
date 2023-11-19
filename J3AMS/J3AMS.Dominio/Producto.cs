using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J3AMS.Dominio
{
    public class Producto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        [StringLength(100, ErrorMessage = "Maximo 100 caracteres")]
        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        public Tipo Tipo { get; set; }
        public Marca Marca { get; set; }
        public Proveedor Proveedor { get; set; }
        public decimal PrecioCosto { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        public decimal PrecioVenta { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        public int Stock { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        public int StockMinimo { get; set; }
        public int Cantidad { get; set; }
    }
}
