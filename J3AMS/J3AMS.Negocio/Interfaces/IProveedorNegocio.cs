using J3AMS.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J3AMS.Negocio.Interfaces
{
    public interface IProveedorNegocio
    {
        List<Proveedor> Listar();
        void Delete(int id);
    }
}
