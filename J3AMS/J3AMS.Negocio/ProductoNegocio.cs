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
                _datos.SetConsulta("SELECT \r\n\tA.Id, \r\n\tA.Descripcion, \r\n\tT.Descripcion AS Tipo,\r\n\tM.Descripcion AS Marca,\r\n\tP.NombreFantasia AS Proveedor,\r\n\tA.PrecioCosto, \r\n\tA.Stock, \r\n\tA.StockMinimo\r\nFROM Productos A\r\nleft join Marcas M on A.Marca = M.Id \r\nleft join Tipos T on A.Tipo = T.Id \r\nleft join Proveedores P on A.Proveedor = P.Id");
                _datos.EjecutarLectura();

                while (_datos.Lector.Read())
                {
                    listProductos.Add(new Producto()
                    {
                        Id = (int)_datos.Lector["Id"],
                        Descripcion = _datos.Lector["Descripcion"] as string ?? string.Empty,
                        PrecioCosto = (decimal)_datos.Lector["PrecioCosto"],
                        /*PorcentajeGanancia = (decimal)_datos.Lector["PorcentajeGanancia"],*/
                        Stock = (int)_datos.Lector["StockActual"],
                        StockMinimo = (int)_datos.Lector["StockMinimo"],
                        Marca = new Marca()
                        {
                            Id = (int)_datos.Lector["Id"],
                            Descripcion = _datos.Lector["Marca"] as string ?? string.Empty,
                        },
                        Tipo = new Tipo()
                        {
                            Id = (int)_datos.Lector["Id"],
                            Descripcion = _datos.Lector["Tipo"] as string ?? string.Empty
                        },
                        Proveedor = new Proveedor()
                        {
                            Id = (int)_datos.Lector["Id"],
                            NombreFantasia = _datos.Lector["NombreFantasia"] as string ?? string.Empty
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
