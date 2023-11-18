using Repository.Interface;

namespace UnitOfWork.Interface
{
    public interface IUnitOfWorkRepository
    {
        IProveedorRepository ProveedorRepository { get; }
        ICategoriaIvaRepository CategoriaIvaRepository { get; }
    }
}
