using J3AMS.Data;
using System;
using System.Data.SqlClient;
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
                _transaction.Rollback();
                _transaction = null;
            }

            if (_connection != null)
            {
                _connection.Close();
                _connection = null;
            }

            Repositories = null;
        }

        public void SaveChanges()
        {
            if (_transaction == null)
                throw new InvalidOperationException
                 ("Transaction have already been committed. Check your transaction handling.");

            _transaction.Commit();
            _transaction = null;
        }
    }
}
