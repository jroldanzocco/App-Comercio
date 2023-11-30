using System.Collections.Generic;

namespace J3AMS.Dominio
{
    public class Compra
    {
        public int Id { get; set; }
        public int NumeroFactura { get; set; }
        public bool Facturada { get; set; }
        public bool Activo { get; set; }
        public List<DetalleCompra> DetalleCompra { get; set; } = new List<DetalleCompra>();
    }
}
