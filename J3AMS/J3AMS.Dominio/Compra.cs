using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J3AMS.Dominio
{
    public class Compra
    {
        public int Id { get; set; }
        public int IdArticulo { get; set; }
        public int Cantidad { get; set; }
        public int NumeroFactura { get; set; }
        public bool Facturada { get; set; }
        public bool Activo { get; set; }
    }
}
