using J3AMS.Dominio;
using J3AMS.Negocio.Interfaces;
using System.Collections.Generic;
using System.Linq;
using UnitOfWork.Interface;

namespace J3AMS.Negocio
{
    public class ProveedorNegocio : IProveedorNegocio
    {
        private IUnitOfWork _unitOfWork;

        public ProveedorNegocio(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<Proveedor> Listar()
        {
            using (var connection = _unitOfWork.Create())
            {
                var listaProveedores = connection.Repositories.ProveedorRepository.GetAll();
                foreach(var proveedor in listaProveedores)
                {
                    proveedor.CategoriaIva = connection.Repositories.CategoriaIvaRepository.Get(proveedor.IdCategoriaIva);
                }

                return listaProveedores.ToList();
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

        public Proveedor GetById(int id)
        {
            using (var connection = _unitOfWork.Create())
            {
                var proveedor = connection.Repositories.ProveedorRepository.Get(id);
                proveedor.CategoriaIva = connection.Repositories.CategoriaIvaRepository.Get(proveedor.IdCategoriaIva);    

                return proveedor;

            }
        }
    }
}
