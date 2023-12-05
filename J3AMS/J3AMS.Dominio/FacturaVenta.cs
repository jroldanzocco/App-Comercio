using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J3AMS.Dominio
{
    public class FacturaVenta
    {
        public int Numero { get; set; }
        public DateTime FechaEmision { get; set; }
        public string cliente { get; set; }
        public int IdCliente { get; set; }
        public string Vendedor { get; set; }
        public List<Producto> ProductosVendidos { get; set; }
        public decimal Importe { get; set; }
    }

}
