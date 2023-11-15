using J3AMS.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Threading;

namespace J3AMS.Negocio
{
    public class ProductoNegocio : IABML<Producto>
    {
        private readonly AccesoADatos _datos;

        public ProductoNegocio()
        {
            _datos = new AccesoADatos();
        }
        public List<Producto> Listar(string id = "")
        {
            var listProductos = new List<Producto>();

            try
            {
                _datos.SetConsulta("SELECT A.Id, A.Descripcion, T.Descripcion AS Tipo, M.Descripcion AS Marca, P.NombreFantasia AS Proveedor, A.PrecioCosto, A.Stock, A.StockMinimo " +
                                  "FROM Productos A " +
                                  "LEFT JOIN Marcas M ON A.IdMarca = M.Id " +
                                  "LEFT JOIN Tipos T ON A.IdTipo = T.Id " +
                                  "LEFT JOIN Proveedores P ON A.IdProveedor = P.Id");

                if(id != "")
                {
                    _datos.SetConsulta("SELECT A.Id, A.Descripcion, T.Descripcion AS Tipo, M.Descripcion AS Marca, P.Id, P.NombreFantasia AS Proveedor, A.PrecioCosto, A.Stock, A.StockMinimo " +
                                  "FROM Productos A " +
                                  "LEFT JOIN Marcas M ON A.IdMarca = M.Id " +
                                  "LEFT JOIN Tipos T ON A.IdTipo = T.Id " +
                                  "LEFT JOIN Proveedores P ON A.IdProveedor = P.Id " +
                                  "WHERE A.Id = @Id"
                                  );
                    _datos.SetParametro("@Id", id);
                }

                _datos.EjecutarLectura();

                while (_datos.Lector.Read())
                {
                    listProductos.Add(new Producto
                    {
                        Id = (int)_datos.Lector["Id"],
                        Descripcion = _datos.Lector["Descripcion"] as string ?? string.Empty,
                        //VERIFICAR LA CONSULTA
                        //StockMinimo = (int)_datos.Lector["A.StockMinimo"],
                        Tipo = new Tipo
                        {
                            Id = (int)_datos.Lector["Id"],
                            Descripcion = _datos.Lector["Tipo"] as string ?? string.Empty
                        },
                        Marca = new Marca
                        {
                            Id = (int)_datos.Lector["Id"],
                            Descripcion = _datos.Lector["Marca"] as string ?? string.Empty,
                        },
                        Proveedor = new Proveedor
                        {
                            Id = (int)_datos.Lector["Id"],
                            NombreFantasia = _datos.Lector["Proveedor"] as string ?? string.Empty,
                        }
                        // Nos falta agregar la propiedad Proveedor
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
                datos.SetConsulta("INSERT INTO Productos (Descripcion, IdTipo, IdMarca, IdProveedor, PrecioCosto, PrecioVenta, Stock, StockMinimo, Activo) " +
                                 "VALUES (@descripcion, @tipo, @marca, @proveedor, @precioCosto, @precioVenta, 0, @stockMinimo, 1)");

                datos.SetParametro("@descripcion", newEntity.Descripcion);
                datos.SetParametro("@tipo", newEntity.Tipo.Id);
                datos.SetParametro("@marca", newEntity.Marca.Id);
                datos.SetParametro("@proveedor", newEntity.Proveedor.Id);
                datos.SetParametro("@precioCosto", newEntity.PrecioCosto);
                datos.SetParametro("@precioVenta", newEntity.PrecioVenta);
                datos.SetParametro("@stockMinimo", newEntity.StockMinimo);

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
        public void Delete(Producto newEntity)
        {
            AccesoADatos datos = new AccesoADatos();
            try
            {
                datos.SetConsulta("DELETE FROM Productos WHERE Id = @id");
                datos.SetParametro("@id", newEntity.Id);
                datos.EjecutarLectura();

                Console.WriteLine("Producto eliminado con éxito.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar el producto.");
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public Producto FiltrarPorId(int id)
        {
            AccesoADatos datos = new AccesoADatos();
            try
            {
                Producto aux = new Producto();

                datos.SetConsulta("SELECT P.Descripcion, T.Id, T.Descripcion, M.Id, M.Descripcion, R.RazonSocial, P.PrecioCosto, P.PrecioVenta, P.StockMinimo FROM Productos P\r\n" +
                    "INNER JOIN Tipos T ON P.IdTipo = T.Id\r\nINNER JOIN Marcas M ON P.IdMarca = M.Id\r\nINNER JOIN Proveedores R ON P.IdProveedor = R.Id\r\nWHERE P.Id = @Id");
                datos.SetParametro("@Id", id);
                datos.EjecutarLectura();

                while (_datos.Lector.Read())
                {
                    
                    aux.Descripcion = _datos.Lector["P.Descripcion"] as string ?? string.Empty;
                    aux.PrecioCosto = (Decimal)_datos.Lector["P.PrecioCosto"];
                    aux.PrecioVenta = (Decimal)_datos.Lector["P.PrecioVenta"];
                    aux.StockMinimo = (int)_datos.Lector["P.StockMinimo"];
                    aux.Tipo = new Tipo
                    {
                        Id = (int)_datos.Lector["T.Id"],
                        Descripcion = _datos.Lector["T.Descripcion"] as string ?? string.Empty
                    };
                    aux.Marca = new Marca
                    {
                        Id = (int)_datos.Lector["M.Id"],
                        Descripcion = _datos.Lector["M.Descripcion"] as string ?? string.Empty
                    };
                        // Nos falta agregar la propiedad Proveedor                 
                }

                return aux;
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

        public void Update(Producto aux)
        {
            AccesoADatos datos = new AccesoADatos();
            try
            {
            datos.SetConsulta("UPDATE Productos SET Descripcion = @Descripcion, IdTipo = @Tipo, IdMarca= @Marca, IdProveedor = @Proveedor, PrecioCosto = @PCosto, PrecioVenta = @PVenta, Stock = @Stock, StockMinimo = @StockMin" +
                "\r\nWHERE Id = @Id");
            datos.SetParametro("@Descripcion", aux.Descripcion);
            datos.SetParametro("@Tipo", aux.Tipo.Id);
            datos.SetParametro("@Marca", aux.Marca.Id);
            datos.SetParametro("@Proveedor", aux.Marca.Id);
            datos.SetParametro("@PCosto", aux.PrecioCosto);
            datos.SetParametro("@PVenta", aux.PrecioVenta);
            datos.SetParametro("@Stock", aux.Stock);
            datos.SetParametro("@StockMin", aux.StockMinimo);
            datos.SetParametro("Id", aux.Id);

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
