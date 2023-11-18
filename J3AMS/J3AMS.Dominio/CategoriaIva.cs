using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J3AMS.Dominio
{
    public class CategoriaIva
    {
        public byte Id { get; set; }
        public string Descripcion { get; set; }
        public decimal PorcentajeIva { get; set; }
        public override string ToString()
        {
            return Descripcion;
        }
    }
}
