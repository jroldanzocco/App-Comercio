using J3AMS.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J3AMS.Negocio
{
    public class TipoNegocio : IABML<Tipo>
    {
        private readonly AccesoADatos _datos;

        public TipoNegocio()
        {
            _datos = new AccesoADatos();
        }

        public void Add(Tipo newEntity)
        {
            try
            {
                var query = "INSERT INTO Tipos(Descripcion, Activo) " +
                            "VALUES(@Descripcion,1)";

                _datos.SetConsulta(query);
                _datos.SetParametro("Descripcion", newEntity.Descripcion);
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

        public void Delete(Tipo newEntity)
        {
            try
            {
                _datos.SetParametro("@id", newEntity.Id);
                _datos.SetConsulta("DELETE FROM Tipos WHERE Id = @id");
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

        public Tipo Get(int id)
        {
            var aux = new Tipo();

            try
            {
                var query = "SELECT Id, " +
                            "Descripcion, " +
                            "Activo " +
                            "FROM Tipos " +
                            "WHERE Id = @id";

                _datos.SetConsulta(query);
                _datos.SetParametro("id", id);
                _datos.EjecutarLectura();

                while (_datos.Lector.Read())
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

        public List<Tipo> Listar(string id = "")
        {
            var listTipos = new List<Tipo>();

            try
            {
                var query = "SELECT Id, " +
                            "Descripcion, " +
                            "Activo " +
                            "FROM Tipos";

                _datos.SetConsulta(query);
                _datos.EjecutarLectura();

                while (_datos.Lector.Read())
                {
                    listTipos.Add(new Tipo()
                    {
                        Id = (byte)_datos.Lector["Id"],
                        Descripcion = _datos.Lector["Descripcion"] as string ?? string.Empty,
                        Activo = Convert.ToBoolean(_datos.Lector["Activo"]),
                    });
                }
                return listTipos;
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

        public void LogicDelete(Tipo entity)
        {
            try
            {
                var query = "UPDATE Tipos " +
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

        public void Update(Tipo entity)
        {
            try
            {
                var query = "UPDATE Tipos " +
                            "SET Descripcion = @Descripcion " +
                            "WHERE ID = @ID";

                _datos.SetConsulta(query);
                _datos.SetParametro("@Descripcion", entity.Descripcion);
                _datos.SetParametro("@ID", entity.Id);

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
