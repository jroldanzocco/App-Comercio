using J3AMS.Dominio;
using System.Collections.Generic;

namespace J3AMS.Negocio.Interfaces
{
    public interface IProveedorNegocio
    {
        List<Proveedor> Listar();
        void Delete(int id);
        void Insert(Proveedor proveedor);
    }
}
