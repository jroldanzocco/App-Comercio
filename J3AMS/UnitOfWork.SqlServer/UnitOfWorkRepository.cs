using Repository.Interface;
using Repository.SqlServer;
using System.Data.SqlClient;
using UnitOfWork.Interface;

namespace UnitOfWork.SqlServer
{
    public class UnitOfWorkRepository : IUnitOfWorkRepository
    {
        public IProveedorRepository ProveedorRepository { get; }
        public ICategoriaIvaRepository CategoriaIvaRepository { get; }
        public UnitOfWorkRepository(SqlConnection connection, SqlTransaction transaction)
        {
            ProveedorRepository = new ProveedorRepository(connection, transaction);
            CategoriaIvaRepository = new CategoriaIvaRepository(connection, transaction);
        }
    }
}
