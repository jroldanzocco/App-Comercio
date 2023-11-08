using J3AMS.Dominio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace J3AMS.Negocio
{
    public class ProductoNegocio : IABML<Producto>
    {
        private readonly AccesoADatos _datos;

        public ProductoNegocio()
        {
            _datos = new AccesoADatos();
        }
        public List<Producto> Listar()
        {
            var listProductos = new List<Producto>();

            try
            {
                _datos.SetConsulta("");
                _datos.EjecutarLectura();

                while (_datos.Lector.Read())
                {
                    listProductos.Add(new Producto()
                    {
                        Id = (int)_datos.Lector["Id"],
                        Descripcion = _datos.Lector["Descripcion"] as string ?? string.Empty,

                        Tipo = new Tipo()
                        {
                            Id = (int)_datos.Lector["Id"],
                            Descripcion = _datos.Lector["Tipo"] as string ?? string.Empty
                        },
                        Marca = new Marca()
                        {
                            Id = (int)_datos.Lector["Id"],
                            Descripcion = _datos.Lector["Marca"] as string ?? string.Empty,
                        },

                        Proveedor = new Proveedor()
                        {
                            Id = (int)_datos.Lector["Id"],
                            NombreFantasia = _datos.Lector["NombreFantasia"] as string ?? string.Empty
                        },

                    });
                }
                return listProductos;
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
        public void Add(Producto newEntity)
        {
            AccesoADatos datos = new AccesoADatos();
            try
            {
                datos.SetConsulta("INSERT INTO Productos (Codigo, Descripcion, Tipo, Marca, Proveedor, PrecioCosto, PrecioVenta, Stock, StockMinimo, Activo) " +
                                 "VALUES (@codigo, @descripcion, @tipo, @marca, @proveedor, 1, 2, 10, 0, 1)");

                datos.SetParametro("@codigo", newEntity.Codigo);
                datos.SetParametro("@descripcion", newEntity.Descripcion);
                datos.SetParametro("@tipo", newEntity.Tipo.Id);
                datos.SetParametro("@marca", newEntity.Marca.Id);
                datos.SetParametro("@proveedor", newEntity.Proveedor.Id);

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
