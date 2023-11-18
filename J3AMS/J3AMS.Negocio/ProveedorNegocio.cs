using J3AMS.Dominio;
using J3AMS.Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.Interface;

namespace J3AMS.Negocio
{
    public class ProveedorNegocio : IProveedorNegocio
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
                datos.SetConsulta("INSERT INTO Proveedores" +
                                  "(RazonSocial, NombreFantasia, CUIT, Domicilio, " +
                                  "Telefono, Celular, Email, IdCategoriaIva, PlazoPago, Activo) " +
                                  "VALUES(@Razon, @Nombre, @CUIT, @Domicilio, @Telefono, @Celular, " +
                                  "@Email, 1, 1, 1)");

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
        public void Delete(int id)
        {
            using (var connection = _unitOfWork.Create())
            {
                connection.Repositories.ProveedorRepository.Delete(id);

                connection.SaveChanges();
            }
        }

        public void Insert(Proveedor proveedor)
        {
            using (var connection = _unitOfWork.Create())
            {
                connection.Repositories.ProveedorRepository.Add(proveedor);

                connection.SaveChanges();
            }
        }
    }
}
