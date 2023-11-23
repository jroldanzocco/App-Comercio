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
                _datos.SetConsulta("SELECT Id, NumeroFactura FROM Ventas");

                if (!string.IsNullOrEmpty(id))
                {
                    _datos.SetConsulta("SELECT Id, NumeroFactura FROM Ventas WHERE Id = @Id");
                    _datos.SetParametro("@Id", id);
                }

                _datos.EjecutarLectura();

                while (_datos.Lector.Read())
                {
                    listVentas.Add(new Venta
                    {
                        Id = (int)_datos.Lector["Id"],
                        NumeroFactura = (int)_datos.Lector["NumeroFactura"],
                        //Activo = (int)_datos.Lector["Activo"],
                    });
                }

                return listVentas;
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
        public void Add(Venta newEntity)
        {
            AccesoADatos datos = new AccesoADatos();

            try
            {
                datos.SetConsulta("INSERT INTO Ventas (NumeroFactura, Facturada, Activo) OUTPUT INSERTED.Id VALUES (0, 0, 1)");

                datos.EjecutarLectura();

                int IdVenta = 0;

                if (datos.Lector.Read())
                {
                    IdVenta = Convert.ToInt32(datos.Lector["Id"]);
                }

                if (IdVenta > 0)
                {
                    foreach (var detalle in newEntity.DetallesVenta)
                    {
                        AccesoADatos datosDetalle = new AccesoADatos();

                        datosDetalle.SetConsulta("INSERT INTO DetallesVentas (IdVenta, IdArticulo, Cantidad) VALUES (@IdVenta, @IdArticulo, @Cantidad)");

                        datosDetalle.SetParametro("@IdVenta", IdVenta);
                        datosDetalle.SetParametro("@IdArticulo", detalle.IdArticulo);
                        datosDetalle.SetParametro("@Cantidad", detalle.Cantidad);

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