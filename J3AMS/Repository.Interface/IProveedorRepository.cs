using J3AMS.Dominio;
using Repository.Interface.Actions;

namespace Repository.Interface
{
    public interface IProveedorRepository : IReadRepository<Proveedor, int>, ICreateRepository<Proveedor>, IUpdateRepository<Proveedor>, IRemoveRepository<int>
    {

    }
}
