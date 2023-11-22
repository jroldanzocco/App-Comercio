using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J3AMS.Dominio
{
    public class Venta
    {
        public int Id { get; set; }
        public int Articulo { get; set; }
        public int Cantidad { get; set; }
        public int NumeroFactura { get; set; }
        public bool Facturada { get; set; }
        public bool Activo { get; set; }
    }
}
