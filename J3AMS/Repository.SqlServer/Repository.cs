using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.SqlServer
{
    public abstract class Repository
    {
        protected SqlConnection _connection;
        protected SqlTransaction _transaction;

        protected SqlCommand CrearComando(string query)
        {
            return new SqlCommand(query, _connection, _transaction);
        }

        protected SqlParameter SetParametro(string nombre, object valor, SqlDbType tipoDato)
        {
            SqlParameter parametro = new SqlParameter();
            parametro.ParameterName = nombre;
            parametro.Value = valor ?? DBNull.Value;
            parametro.SqlDbType = tipoDato;

            return parametro;
        }
    }
}
