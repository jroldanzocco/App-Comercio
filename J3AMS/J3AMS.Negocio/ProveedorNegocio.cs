using J3AMS.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J3AMS.Negocio
{
    public class ProveedorNegocio : IABML<Proveedor>
    {
        private readonly AccesoADatos _datos;

        public ProveedorNegocio()
        {
            _datos = new AccesoADatos();
        }
        public List<Proveedor> Listar(string id = "")
        {
            var listProveedores = new List<Proveedor>();

            try
            {
                _datos.SetConsulta("SELECT Id, NombreFantasia, Domicilio, Telefono, Celular, Email, Activo FROM Proveedores");
                _datos.EjecutarLectura();

                while (_datos.Lector.Read())
                {
                    listProveedores.Add(new Proveedor()
                    {
                        Id = (int)_datos.Lector["Id"],
                        NombreFantasia = _datos.Lector["NombreFantasia"] as string ?? string.Empty,
                        Domicilio = _datos.Lector["Domicilio"] as string ?? string.Empty,
                        Telefono = _datos.Lector["Telefono"] as string ?? string.Empty,
                        Celular = _datos.Lector["Celular"] as string ?? string.Empty,
                        Email = _datos.Lector["Email"] as string ?? string.Empty,
                        Activo = (bool)_datos.Lector["Activo"]
                    });
                }
                return listProveedores;
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


        public void Add(Proveedor newEntity)
        {
            AccesoADatos datos = new AccesoADatos();

            try
            {
                datos.SetConsulta("INSERT INTO Proveedores(RazonSocial, NombreFantasia, CUIT, Domicilio, Telefono, IdCategoriaIva, PlazoPago, Activo)\r\n" +
                    "VALUES(@Razon, @Nombre, @CUIT, @Domicilio, @Telefono, 1, 1, 1)");
                datos.SetParametro("@Razon", newEntity.RazonSocial);
                datos.SetParametro("@Nombre", newEntity.NombreFantasia);
                datos.SetParametro("@CUIT", newEntity.CUIT);
                datos.SetParametro("@Domicilio", newEntity.Domicilio);
                datos.SetParametro("@Telefono", newEntity.Telefono);
                datos.SetParametro("@Activo", true);
                datos.EjecutarLectura();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
        public void Delete(Proveedor newEntity)
        {
            AccesoADatos datos = new AccesoADatos();
            try
            {
                datos.SetParametro("@id", newEntity.Id);
                datos.SetConsulta("DELETE FROM Proveedores WHERE Id = @id");

                Console.WriteLine("Proveedor eliminado con éxito.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar el proveedor.");
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public void SoftDelete(Proveedor newEntity)
        {
            AccesoADatos datos = new AccesoADatos();
            try
            {
                datos.SetParametro("@idDelete", newEntity.Id);
                datos.SetConsulta("UPDATE Proveedores SET Activo = 0 WHERE id = @idDelete");
                datos.EjecutarLectura();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
    }
}
