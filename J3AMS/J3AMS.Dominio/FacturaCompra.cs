using System;
using System.Collections.Generic;

namespace J3AMS.Dominio
{
    public class FacturaCompra
    {
        public int Numero { get; set; }
        public DateTime FechaEmision { get; set; }
        public string proveedor { get; set; }
        public int IdProveedor { get; set; }
        public string Comprador { get; set; }
        public List<Producto> ProductosComprados { get; set; }
        public decimal Importe { get; set; }
    }
}
