﻿using J3AMS.Dominio;
using System;
using System.Collections.Generic;

namespace J3AMS.Negocio
{
    public class VentaNegocio : IABML<Venta>
    {
        private readonly AccesoADatos _datos;
        public VentaNegocio()
        {
            _datos = new AccesoADatos();
        }
        public List<Venta> Listar(string id = "")
        {
            var listVentas = new List<Venta>();

            try
            {
                _datos.SetConsulta("SELECT V.Id, V.NumeroFactura, DV.IdArticulo, DV.Cantidad, V.Activo " +
                                   "FROM Ventas V " +
                                   "INNER JOIN DetallesVentas DV ON V.Id = DV.IdVenta");

                if (!string.IsNullOrEmpty(id))
                {
                    _datos.SetConsulta("SELECT V.Id, V.NumeroFactura, DV.IdArticulo, DV.Cantidad, V.Activo " +
                                       "FROM Ventas V " +
                                       "INNER JOIN DetallesVentas DV ON V.Id = DV.IdVenta " +
                                       "WHERE V.Id = @Id");
                    _datos.SetParametro("@Id", id);
                }

                _datos.EjecutarLectura();

                while (_datos.Lector.Read())
                {
                    var venta = new Venta
                    {
                        Id = (int)_datos.Lector["Id"],
                        NumeroFactura = (int)_datos.Lector["NumeroFactura"],
                        Activo = (bool)_datos.Lector["Activo"]
                    };

                    var detalleVenta = new DetalleVenta
                    {
                        IdArticulo = (int)_datos.Lector["IdArticulo"],
                        Cantidad = (int)_datos.Lector["Cantidad"]
                    };
                    venta.DetallesVenta.Add(detalleVenta);

                    listVentas.Add(venta);
                }

                return listVentas;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar ventas con detalles", ex);
            }
            finally
            {
                _datos.CerrarConexion();
            }
        }
        public void Add(Venta newEntity)
        {
            AccesoADatos datos = new AccesoADatos();
            try
            {

                datos.SetConsulta("SELECT MAX(Numero) AS UltimaFactura FROM FacturasVentas ");
                datos.EjecutarLectura();

                int IdVenta = 0;

                if (datos.Lector.Read())
                {
                    IdVenta = (int)datos.Lector["UltimaFactura"];
                }


                if (IdVenta > 0)
                {
                    foreach (var detalle in newEntity.DetallesVenta)
                    {
                        AccesoADatos datosDetalle = new AccesoADatos();

                        datosDetalle.SetConsulta("INSERT INTO DetallesVentas (IdVenta, IdArticulo, Cantidad, PrecioUnitario) VALUES (@IdVenta, @IdArticulo, @Cantidad, @Precio)");

                        datosDetalle.SetParametro("@IdVenta", IdVenta);
                        datosDetalle.SetParametro("@IdArticulo", detalle.IdArticulo);
                        datosDetalle.SetParametro("@Cantidad", detalle.Cantidad);
                        datosDetalle.SetParametro("@Precio", detalle.PrecioUnitario);

                        datosDetalle.EjecutarLectura();
                        datosDetalle.CerrarConexion();
                    }
                }
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