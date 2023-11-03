using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J3AMS.Dominio
{
    public class Articulo
    {
        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Tipo { get; set; }
        public Marca _Marca { get; set; }
        public string Proveedor { get; set; }
        public int Stock { get; set; }
    }
}
