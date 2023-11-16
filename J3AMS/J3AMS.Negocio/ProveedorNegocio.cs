using J3AMS.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.Interface;

namespace J3AMS.Negocio
{
    public class ProveedorNegocio
    {
        private readonly AccesoADatos _datos;
        private IUnitOfWork _unitOfWork;

        public ProveedorNegocio(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _datos = new AccesoADatos();
        }
        public List<Proveedor> Listar()
        {

            using (var connection = _unitOfWork.Create())
            {
                var listaProveedores = connection.Repositories.ProveedorRepository.GetAll();
                
                return listaProveedores.ToList();
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
