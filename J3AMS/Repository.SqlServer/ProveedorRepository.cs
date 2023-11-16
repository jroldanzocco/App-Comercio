using J3AMS.Dominio;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.SqlServer
{
    public class ProveedorRepository : Repository, IProveedorRepository
    {
        public ProveedorRepository(SqlConnection connection, SqlTransaction transaction)
        {
            _connection = connection;
            _transaction = transaction;
        }

        public void Add(Proveedor entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Proveedor Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Proveedor> GetAll()
        {
            var command = CrearComando("SELECT Id, NombreFantasia, Domicilio, Telefono, Celular, Email, Activo FROM Proveedores");
            var listProveedores = new List<Proveedor>();

            using (var lector = command.ExecuteReader())
            {
                while (lector.Read())
                {
                    listProveedores.Add(new Proveedor()
                    {
                        Id = (int)lector["Id"],
                        NombreFantasia = lector["NombreFantasia"] as string ?? string.Empty,
                        Domicilio = lector["Domicilio"] as string ?? string.Empty,
                        Telefono = lector["Telefono"] as string ?? string.Empty,
                        Celular = lector["Celular"] as string ?? string.Empty,
                        Email = lector["Email"] as string ?? string.Empty,
                        Activo = (bool)lector["Activo"]
                    });
                }
            }

            return listProveedores;
        }

        public void Update(Proveedor entity)
        {
            throw new NotImplementedException();
        }
    }
}
