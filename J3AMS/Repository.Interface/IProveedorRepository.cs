using J3AMS.Dominio;
using Repository.Interface.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IProveedorRepository : IReadRepository<Proveedor,int>, ICreateRepository<Proveedor>, IUpdateRepository<Proveedor>, IRemoveRepository<int>
    {
        
    }
}
