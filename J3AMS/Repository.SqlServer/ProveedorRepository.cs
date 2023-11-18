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
            try
            {
                var command = CrearComando("INSERT INTO Proveedores" +
                                           "(RazonSocial, NombreFantasia, CUIT, Domicilio, " +
                                           "Telefono, Celular, Email, IdCategoriaIva, PlazoPago, Activo) " +
                                           "VALUES(@Razon, @Nombre, @CUIT, @Domicilio, @Telefono, @Celular, " +
                                           "@Email, 1, 1, 1)");

                command.Parameters.AddWithValue("@Razon", entity.RazonSocial);
                command.Parameters.AddWithValue("@Nombre", entity.NombreFantasia);
                command.Parameters.AddWithValue("@CUIT", entity.CUIT);
                command.Parameters.AddWithValue("@Domicilio", entity.Domicilio);
                command.Parameters.AddWithValue("@Telefono", entity.Telefono);
                command.Parameters.AddWithValue("@Celular", entity.Celular);
                command.Parameters.AddWithValue("@Email", entity.Email);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void Delete(int id)
        {
            try
            {
                var command = CrearComando("UPDATE Proveedores SET Activo = 0 WHERE Id = " + id);

                command.ExecuteNonQuery();

                Console.WriteLine("Proveedor eliminado con éxito.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar el proveedor.");
            }
        }

        public Proveedor Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Proveedor> GetAll()
        {
            var listProveedores = new List<Proveedor>();
            try
            {
                var command = CrearComando("SELECT Id, NombreFantasia, Domicilio, Telefono, Celular, Email, Activo FROM Proveedores");
                

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
            }
            catch (Exception ex)
            {
                throw ex;
            }
            

            return listProveedores;
        }

        public void Update(Proveedor entity)
        {
            throw new NotImplementedException();
        }
    }
}
