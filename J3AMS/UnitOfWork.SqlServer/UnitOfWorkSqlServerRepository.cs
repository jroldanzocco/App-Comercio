using Repository.Interface;
using Repository.SqlServer;
using System.Data.SqlClient;
using UnitOfWork.Interface;

namespace UnitOfWork.SqlServer
{
    public class UnitOfWorkSqlServerRepository : IUnitOfWorkRepository
    {
        public IProveedorRepository ProveedorRepository { get; }
        public UnitOfWorkSqlServerRepository(SqlConnection connection, SqlTransaction transaction)
        {
            ProveedorRepository = new ProveedorRepository(connection, transaction);
        }
    }
}
