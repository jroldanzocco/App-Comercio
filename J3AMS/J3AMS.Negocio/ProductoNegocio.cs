﻿using J3AMS.Dominio;
using System;
using System.Collections.Generic;

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
                _datos.SetConsulta("SELECT A.Id AS IdArt, A.Descripcion, T.Id AS IdTipo, T.Descripcion AS Tipo, M.Id AS IdMarca, M.Descripcion AS Marca, P.Id AS IdProv, P.NombreFantasia AS Proveedor, A.PrecioCompra AS PCompra, A.PrecioVenta AS PVenta, A.Stock AS Stock, A.StockMinimo AS StMin, A.Activo " +
                                 "FROM Productos A " +
                                 "LEFT JOIN Marcas M ON A.IdMarca = M.Id " +
                                 "LEFT JOIN Tipos T ON A.IdTipo = T.Id " +
                                 "LEFT JOIN Proveedores P ON A.IdProveedor = P.Id");

                if (id != "")
                {
                    _datos.SetConsulta("SELECT A.Id AS IdArt, A.Descripcion, T.Id AS IdTipo, T.Descripcion AS Tipo, M.Id AS IdMarca, M.Descripcion AS Marca, P.Id AS IdProv, P.NombreFantasia AS Proveedor, A.PrecioCompra AS PCompra, A.PrecioVenta AS PVenta, A.Stock AS Stock, A.StockMinimo AS StMin, A.Activo " +
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
                        Id = (int)_datos.Lector["IdArt"],
                        Descripcion = _datos.Lector["Descripcion"] as string ?? string.Empty,
                        PrecioCompra = (decimal)_datos.Lector["PCompra"],
                        PrecioVenta = (decimal)_datos.Lector["PVenta"],
                        StockMinimo = (int)_datos.Lector["StMin"],
                        Stock = (int)_datos.Lector["Stock"],
                        Tipo = new Tipo
                        {
                            Id = (byte)_datos.Lector["IdTipo"],
                            Descripcion = _datos.Lector["Tipo"] as string ?? string.Empty
                        },
                        Marca = new Marca
                        {
                            Id = (byte)_datos.Lector["IdMarca"],
                            Descripcion = _datos.Lector["Marca"] as string ?? string.Empty,
                        },
                        Proveedor = new Proveedor
                        {
                            Id = (int)_datos.Lector["IdProv"],
                            NombreFantasia = _datos.Lector["Proveedor"] as string ?? string.Empty,
                        },
                        Activo = (bool)_datos.Lector["Activo"]
                    }); ;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _datos.CerrarConexion();
            }
            return listProductos;
        }
        public void Add(Producto newEntity)
        {
            AccesoADatos datos = new AccesoADatos();
            try
            {
                datos.SetConsulta("INSERT INTO Productos (Descripcion, IdTipo, IdMarca, IdProveedor, PrecioCompra, PrecioVenta, Stock, Activo) " +
                                 "VALUES (@descripcion, @tipo, @marca, @proveedor, @precioCompra, @precioVenta, @stock, 1)");

                datos.SetParametro("@descripcion", newEntity.Descripcion);
                datos.SetParametro("@tipo", newEntity.Tipo.Id);
                datos.SetParametro("@marca", newEntity.Marca.Id);
                datos.SetParametro("@proveedor", newEntity.Proveedor.Id);
                datos.SetParametro("@precioCompra", newEntity.PrecioCompra);
                datos.SetParametro("@precioVenta", newEntity.PrecioVenta);
                datos.SetParametro("@stockMinimo", newEntity.Stock);

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
            AccesoADatos datos = new AccesoADatos();
            try
            {
                datos.SetConsulta("DELETE FROM Productos WHERE Id = @id");
                datos.SetParametro("@id", id);
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

                datos.SetConsulta("SELECT P.Descripcion, T.Id, T.Descripcion, M.Id, M.Descripcion, R.RazonSocial, P.PrecioCompra, P.PrecioVenta, P.StockMinimo FROM Productos P\r\n" +
                    "INNER JOIN Tipos T ON P.IdTipo = T.Id\r\nINNER JOIN Marcas M ON P.IdMarca = M.Id\r\nINNER JOIN Proveedores R ON P.IdProveedor = R.Id\r\nWHERE P.Id = @Id");
                datos.SetParametro("@Id", id);
                datos.EjecutarLectura();

                while (_datos.Lector.Read())
                {

                    aux.Descripcion = _datos.Lector["P.Descripcion"] as string ?? string.Empty;
                    aux.PrecioCompra = (decimal)_datos.Lector["P.PrecioCompra"];
                    aux.PrecioVenta = (decimal)_datos.Lector["P.PrecioVenta"];
                    aux.StockMinimo = (int)_datos.Lector["P.StockMinimo"];
                    aux.Tipo = new Tipo
                    {
                        Id = (byte)_datos.Lector["T.Id"],
                        Descripcion = _datos.Lector["T.Descripcion"] as string ?? string.Empty
                    };
                    aux.Marca = new Marca
                    {
                        Id = (byte)_datos.Lector["M.Id"],
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
                datos.SetConsulta("UPDATE Productos SET Descripcion = @Descripcion, IdTipo = @Tipo, IdMarca= @Marca, IdProveedor = @Proveedor, PrecioCompra = @PCompra, PrecioVenta = @PVenta, Stock = @Stock, StockMinimo = @StockMin" +
                    "\r\nWHERE Id = @Id");
                datos.SetParametro("@Descripcion", aux.Descripcion);
                datos.SetParametro("@Tipo", aux.Tipo.Id);
                datos.SetParametro("@Marca", aux.Marca.Id);
                datos.SetParametro("@Proveedor", aux.Marca.Id);
                datos.SetParametro("@PCompra", aux.PrecioCompra);
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
        public Producto ObtenerPorId(int id)
        {
            try
            {
                Producto producto = new Producto();

                _datos.SetConsulta("SELECT A.Id AS IdArt, A.Descripcion, T.Id AS IdTipo, T.Descripcion AS Tipo, M.Id AS IdMarca, M.Descripcion AS Marca, P.Id AS IdProv, P.NombreFantasia AS Proveedor, A.PrecioCompra, A.PrecioVenta, A.Stock, A.StockMinimo " +
                                  "FROM Productos A " +
                                  "LEFT JOIN Marcas M ON A.IdMarca = M.Id " +
                                  "LEFT JOIN Tipos T ON A.IdTipo = T.Id " +
                                  "LEFT JOIN Proveedores P ON A.IdProveedor = P.Id " +
                                  "WHERE A.Id = @Id");

                _datos.SetParametro("@Id", id);
                _datos.EjecutarLectura();

                while (_datos.Lector.Read())
                {
                    producto = new Producto
                    {
                        Id = (int)_datos.Lector["IdArt"],
                        Descripcion = _datos.Lector["Descripcion"] as string ?? string.Empty,
                        Tipo = new Tipo
                        {
                            Id = (byte)_datos.Lector["IdTipo"],
                            Descripcion = _datos.Lector["Tipo"] as string ?? string.Empty
                        },
                        Marca = new Marca
                        {
                            Id = (byte)_datos.Lector["IdMarca"],
                            Descripcion = _datos.Lector["Marca"] as string ?? string.Empty,
                        },
                        Proveedor = new Proveedor
                        {
                            Id = (int)_datos.Lector["IdProv"],
                            NombreFantasia = _datos.Lector["Proveedor"] as string ?? string.Empty,
                        },
                        PrecioCompra = (decimal)_datos.Lector["PrecioCompra"],
                        PrecioVenta = (decimal)_datos.Lector["PrecioVenta"],
                        Stock = (int)_datos.Lector["Stock"],
                        StockMinimo = (int)_datos.Lector["StockMinimo"]
                    };
                }

                return producto;
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
        public void ActualizarStock(Producto producto, int cantidad)
        {
            AccesoADatos datos = new AccesoADatos();
            try
            {
                {
                    datos.SetConsulta("UPDATE Productos SET Stock = Stock + @Cantidad WHERE Id = @Id");

                    datos.SetParametro("@Cantidad", cantidad);
                    datos.SetParametro("@Id", producto.Id);

                    datos.EjecutarLectura();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al actualizar el stock: {ex.Message}");
            }
        }
        public Producto Get(int id)
        {
            try
            {
                Producto aux = null;

                _datos.SetConsulta("SELECT A.Id AS IdArt, A.Descripcion, T.Id AS IdTipo, T.Descripcion AS Tipo, M.Id AS IdMarca, M.Descripcion AS Marca, P.Id AS IdProv, P.NombreFantasia AS Proveedor, A.PrecioCompra AS PCompra, A.PrecioVenta AS PVenta, A.Stock AS Stock, A.StockMinimo AS StMin, A.Activo " +
                                  "FROM Productos A " +
                                  "LEFT JOIN Marcas M ON A.IdMarca = M.Id " +
                                  "LEFT JOIN Tipos T ON A.IdTipo = T.Id " +
                                  "LEFT JOIN Proveedores P ON A.IdProveedor = P.Id " +
                                  "WHERE A.Id = @Id"
                                  );
                _datos.SetParametro("@Id", id);

                _datos.EjecutarLectura();
                while (_datos.Lector.Read())
                {
                    aux = new Producto
                    {
                        Id = (int)_datos.Lector["IdArt"],
                        Descripcion = _datos.Lector["Descripcion"] as string ?? string.Empty,
                        PrecioCompra = (decimal)_datos.Lector["PCompra"],
                        PrecioVenta = (decimal)_datos.Lector["PVenta"],
                        StockMinimo = (int)_datos.Lector["StMin"],
                        Stock = (int)_datos.Lector["Stock"],
                        Tipo = new Tipo
                        {
                            Id = (byte)_datos.Lector["IdTipo"],
                            Descripcion = _datos.Lector["Tipo"] as string ?? string.Empty
                        },
                        Marca = new Marca
                        {
                            Id = (byte)_datos.Lector["IdMarca"],
                            Descripcion = _datos.Lector["Marca"] as string ?? string.Empty,
                        },
                        Proveedor = new Proveedor
                        {
                            Id = (int)_datos.Lector["IdProv"],
                            NombreFantasia = _datos.Lector["Proveedor"] as string ?? string.Empty,
                        },
                        Activo = (bool)_datos.Lector["Activo"]
                    };
                }
                return aux;
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
        public void LogicDelete(int id)
        {
            try
            {
                _datos.SetConsulta("UPDATE Productos SET Activo = 0 WHERE id = @idDelete");
                _datos.SetParametro("@idDelete", id);
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
