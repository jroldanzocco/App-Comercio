using J3AMS.Dominio;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

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
                throw ex;
            }
        }

        public void Delete(int id)
        {
            try
            {
                var command = CrearComando("UPDATE Proveedores SET Activo = 0 WHERE Id = " + id);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Proveedor Get(int id)
        {
            try
            {
                var command = CrearComando("SELECT " +
                                           "Id, " +
                                           "RazonSocial, " +
                                           "NombreFantasia, " +
                                           "CUIT, " +
                                           "Domicilio, " +
                                           "Telefono, " +
                                           "Celular, " +
                                           "Email, " +
                                           "IdCategoriaIva, " +
                                           "PlazoPago, " +
                                           "Activo, " +
                                           "FROM Proveedores" +
                                           "WHERE P.Id = @ID");

                command.Parameters.AddWithValue("ID", id);

                using (var lector = command.ExecuteReader())
                {
                    lector.Read();

                    return new Proveedor
                    {
                        Id = (int)lector["Id"],
                        RazonSocial = lector["RazonSocial"] as string ?? string.Empty,
                        NombreFantasia = lector["NombreFantasia"] as string ?? string.Empty,
                        CUIT = lector["NombreFantasia"] as string ?? string.Empty,
                        Domicilio = lector["Domicilio"] as string ?? string.Empty,
                        Telefono = lector["Telefono"] as string ?? string.Empty,
                        Celular = lector["Celular"] as string ?? string.Empty,
                        Email = lector["Email"] as string ?? string.Empty,
                        IdCategoriaIva = (byte)lector["IdCategoriaIva"],
                        PlazoPago = (byte)lector["PlazoPago"],
                        Activo = (bool)lector["Activo"]
                    };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Proveedor> GetAll()
        {
            var listProveedores = new List<Proveedor>();
            try
            {
                var command = CrearComando("SELECT Id, RazonSocial, NombreFantasia, CUIT, Domicilio, Telefono, Celular, Email, IdCategoriaIva, PlazoPago, Activo FROM Proveedores");


                using (var lector = command.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        listProveedores.Add(new Proveedor()
                        {
                            Id = (int)lector["Id"],
                            RazonSocial = lector["RazonSocial"] as string ?? string.Empty,
                            NombreFantasia = lector["NombreFantasia"] as string ?? string.Empty,
                            CUIT = lector["NombreFantasia"] as string ?? string.Empty,
                            Domicilio = lector["Domicilio"] as string ?? string.Empty,
                            Telefono = lector["Telefono"] as string ?? string.Empty,
                            Celular = lector["Celular"] as string ?? string.Empty,
                            Email = lector["Email"] as string ?? string.Empty,
                            IdCategoriaIva = (byte)lector["IdCategoriaIva"],
                            PlazoPago = (byte)lector["PlazoPago"],
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
            try
            {
                var query = "UPDATE Proveedores " +
                            "SET RazonSocial = '@RazonSocial', " +
                            "NombreFantasia = '@Nombre', " +
                            "CUIT = '@CUIT', " +
                            "Domicilio = '@Domicilio', " +
                            "Telefono = '@Telefono', " +
                            "Celular = '@Celular', " +
                            "Email = '@Email', " +
                            "IdCategoriaIva = @IdIva, " +
                            "PlazoPago = PlazoPago, " +
                            "WHERE ID = @ID";

                var command = CrearComando(query);

                command.Parameters.AddWithValue("ID", entity.Id);
                command.Parameters.AddWithValue("RazonSocial", entity.RazonSocial);
                command.Parameters.AddWithValue("Nombre", entity.NombreFantasia);
                command.Parameters.AddWithValue("CUIT", entity.CUIT);
                command.Parameters.AddWithValue("Domicilio", entity.Domicilio);
                command.Parameters.AddWithValue("Telefono", entity.Telefono);
                command.Parameters.AddWithValue("Celular", entity.Celular);
                command.Parameters.AddWithValue("Email", entity.Email);
                command.Parameters.AddWithValue("IdIva", entity.CategoriaIva.Id);
                command.Parameters.AddWithValue("PlazoPago", entity.PlazoPago);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
