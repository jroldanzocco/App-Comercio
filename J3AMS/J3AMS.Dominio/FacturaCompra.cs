using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J3AMS.Dominio
{
    public class FacturaCompra
    {
        public int Numero { get; set; }
        public DateTime FechaEmision { get; set; }
        public int IdProveedor { get; set; }
        public List<Producto> ProductosComprados { get; set; }
        public decimal Importe { get; set; }
    }
}
