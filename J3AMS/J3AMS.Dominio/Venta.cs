using System;
using System.Collections.Generic;

namespace J3AMS.Dominio
{
    public class Venta
    {
        public int Id { get; set; }
        public int NumeroFactura { get; set; }
        public bool Facturada { get; set; }
        public bool Activo { get; set; }
        public Venta()
        {
            DetallesVenta = new List<DetalleVenta>();
        }
        public List<DetalleVenta> DetallesVenta { get; set; }
    }
}

