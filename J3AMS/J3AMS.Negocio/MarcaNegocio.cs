using J3AMS.Dominio;
using System;
using System.Collections.Generic;

namespace J3AMS.Negocio
{
    public class MarcaNegocio : IABML<Marca>
    {
        private readonly AccesoADatos _datos;

        public MarcaNegocio()
        {
            _datos = new AccesoADatos();
        }

        public void Add(Marca newEntity)
        {
            try
            {
                var query = "INSERT INTO Marcas(Descripcion, Activo) " +
                            "VALUES(@Descripcion,1)";

                _datos.SetConsulta(query);
                _datos.SetParametro("Descripcion", newEntity.Descripcion);
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                _datos.CerrarConexion();
            }
        }

        public void Delete(Marca newEntity)
        {
            try
            {
                _datos.SetParametro("@id", newEntity.Id);
                _datos.SetConsulta("DELETE FROM Marcas WHERE Id = @id");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _datos.CerrarConexion();
            }
        }

        public Marca Get(int id)
        {
            var aux = new Marca();

            try
            {
                var query = "SELECT Id, " +
                            "Descripcion, " +
                            "Activo " +
                            "FROM Marcas " +
                            "WHERE Id = @id";

                _datos.SetConsulta(query);
                _datos.SetParametro("id", id);

                while(_datos.Lector.Read())
                {
                    aux.Id = (byte)_datos.Lector["Id"]; ;
                    aux.Descripcion = _datos.Lector["Descripcion"] as string ?? string.Empty; ;
                    aux.Activo = Convert.ToBoolean(_datos.Lector["Activo"]);
                }
                return aux;
            }
            catch (Exception e)
            {

                throw e;
            }
            finally
            {
                _datos.CerrarConexion();
            }
        }

        public List<Marca> Listar(string id = "")
        {
            var listMarcas = new List<Marca>();

            try
            {
                var query = "SELECT Id, " +
                            "Descripcion, " +
                            "Activo " +
                            "FROM Marcas";

                _datos.SetConsulta(query);
                _datos.EjecutarLectura();

                while (_datos.Lector.Read())
                {
                    listMarcas.Add(new Marca()
                    {
                        Id = (byte)_datos.Lector["Id"],
                        Descripcion = _datos.Lector["Descripcion"] as string ?? string.Empty,
                        Activo = Convert.ToBoolean(_datos.Lector["Id"]),
                    });
                }
                return listMarcas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _datos.CerrarConexion();
            }

        }

        public void LogicDelete(Marca entity)
        {
            try
            {
                var query = "UPDATE Marcas " +
                            "SET Activo = 0 " +
                            "WHERE ID = @ID";

                _datos.SetConsulta(query);
                _datos.SetParametro("ID", entity.Id);

                _datos.EjecutarLectura();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _datos.CerrarConexion();
            }
        }

        public void Update(Marca entity)
        {
            try
            {
                var query = "UPDATE Marcas " +
                            "SET Descripcion = '@Descripcion', " +
                            "Activo = '@Activo' " +
                            "WHERE ID = @ID";

                _datos.SetConsulta(query);
                _datos.SetParametro("ID", entity.Id);
                _datos.SetParametro("Descripcion", entity.Descripcion);
                _datos.SetParametro("Activo", entity.Activo);

                _datos.EjecutarLectura();
            }
            catch (Exception ex)
            {
                throw ex; 
            }
            finally
            {
                _datos.CerrarConexion();
            }
        }
    }
}
