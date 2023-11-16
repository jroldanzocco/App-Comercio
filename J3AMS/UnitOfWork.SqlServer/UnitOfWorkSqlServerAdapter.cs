using J3AMS.Data;
using System.Data.SqlClient;
using UnitOfWork.Interface;

namespace UnitOfWork.SqlServer
{
    public class UnitOfWorkSqlServerAdapter : IUnitOfWorkAdapter
    {
        private SqlConnection _connection {  get; set; }
        private SqlTransaction _transaction { get; set; }
        public IUnitOfWorkRepository Repositories {get;set;}

        public UnitOfWorkSqlServerAdapter()
        {
            _connection = new SqlConnection(Parametros.ConnectionString);
            _connection.Open();

            _transaction = _connection.BeginTransaction();

            Repositories = new UnitOfWorkSqlServerRepository(_connection, _transaction);
        }

        public void Dispose()
        {
            if(_transaction != null)
                _transaction.Dispose();
            if(_connection != null)
            {
                _connection.Close();
                _connection.Dispose();
            }

            Repositories = null;
        }

        public void saveChanges()
        {
            _transaction.Commit();
        }
    }
}
