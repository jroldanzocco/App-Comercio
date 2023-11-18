using J3AMS.Dominio;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Repository.SqlServer
{
    public class CategoriaIvaRepository : Repository, ICategoriaIvaRepository
    {
        public CategoriaIvaRepository(SqlConnection connection, SqlTransaction transaction)
        {
            _connection = connection;
            _transaction = transaction;
        }
        public CategoriaIva Get(int id)
        {
            try
            {
                var command = CrearComando("SELECT Id, " +
                                           "Descripcion, " +
                                           "PorcentajeIva " +
                                           "FROM CategoriasIva " +
                                           "WHERE Id = @ID");

                command.Parameters.AddWithValue("ID", id);

                using (var lector = command.ExecuteReader())
                {
                    lector.Read();

                    return new CategoriaIva()
                    {
                        Id = (byte)lector["Id"],
                        Descripcion = lector["Descripcion"] as string ?? string.Empty,
                        PorcentajeIva = (decimal)lector["PorcentajeIva"],
                    };
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IEnumerable<CategoriaIva> GetAll()
        {
            try
            {
                var ListCategoriaIva = new List<CategoriaIva>();

                var command = CrearComando("SELECT Id, " +
                                           "Descripcion, " +
                                           "PorcentajeIva " +
                                           "FROM CategoriasIva");

                using (var lector = command.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        ListCategoriaIva.Add(new CategoriaIva()
                        {
                            Id = (byte)lector["ID"],
                            Descripcion = lector["Descripcion"] as string ?? string.Empty,
                            PorcentajeIva = (decimal)lector["ID"],
                        });
                    }
                }
                return ListCategoriaIva;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
