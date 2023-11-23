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
        public int NumeroFactura { get; set; }
        public bool Facturada { get; set; }
        public bool Activo { get; set; }
        public Compra()
        {
            DetallesCompra = new List<DetalleCompra>();
        }
        public List<DetalleCompra> DetallesCompra { get; set; }
    }
}
