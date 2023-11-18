using J3AMS.Data;
using System;
using System.Data.SqlClient;
using System.Runtime.Remoting.Contexts;
using UnitOfWork.Interface;

namespace UnitOfWork.SqlServer
{
    public class UnitOfWorkAdapter : IUnitOfWorkAdapter
    {
        private SqlConnection _connection {  get; set; }
        private SqlTransaction _transaction { get; set; }
        public IUnitOfWorkRepository Repositories {get;set;}

        public UnitOfWorkAdapter()
        {
            _connection = new SqlConnection(Parametros.ConnectionString);
            _connection.Open();

            _transaction = _connection.BeginTransaction();

            Repositories = new UnitOfWorkRepository(_connection, _transaction);
        }

        public void Dispose()
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
            }

            if (_connection != null)
            {
                _connection.Close();
                _connection.Dispose();
            }

            Repositories = null;
        }

        public void SaveChanges()
        {
            _transaction.Commit();
        }
    }
}
