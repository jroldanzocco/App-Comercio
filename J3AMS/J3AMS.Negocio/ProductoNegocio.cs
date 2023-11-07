using J3AMS.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                _datos.SetConsulta("SELECT A.ProductoID, A.Nombre, A.PrecioCompra, A.PorcentajeGanancia, A.StockActual, A.StockMinimo, A.MarcaID, M.Nombre Marca, A.TipoID, T.Nombre Tipo,A.ProveedorID, P.Nombre Proveedor  FROM Productos A left join Marcas M on A.MarcaID = M.MarcaID left join Tipos T on A.TipoID = T.TipoID left join Proveedores P on A.ProveedorID = p.ProveedorID\r\n");
                _datos.EjecutarLectura();

                while (_datos.Lector.Read())
                {
                    listProductos.Add(new Producto()
                    {
                        Id = (int)_datos.Lector["ProductoID"],
                        Nombre = _datos.Lector["Nombre"] as string ?? string.Empty,
                        PrecioCompra = (decimal)_datos.Lector["PrecioCompra"],
                        PorcentajeGanancia = (decimal)_datos.Lector["PorcentajeGanancia"],
                        Stock = (int)_datos.Lector["StockActual"],
                        StockMinimo = (int)_datos.Lector["StockMinimo"],
                        Marca = new Marca()
                        {
                            Id = (int)_datos.Lector["MarcaID"],
                            Nombre = _datos.Lector["Marca"] as string ?? string.Empty,
                        },
                        Tipo = new Tipo()
                        {
                            Id = (int)_datos.Lector["TipoID"],
                            Nombre = _datos.Lector["Tipo"] as string ?? string.Empty
                        },
                        Proveedor = new Proveedor()
                        {
                            Id = (int)_datos.Lector["ProveedorID"],
                            Nombre = _datos.Lector["Proveedor"] as string ?? string.Empty
                        },

                    });;
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
    }
}
