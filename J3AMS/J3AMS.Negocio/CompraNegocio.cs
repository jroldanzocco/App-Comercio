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
    public class CompraNegocio : IABML<Compra>
    {
        private readonly AccesoADatos _datos;
        public CompraNegocio()
        {
            _datos = new AccesoADatos();
        }
        public List<Compra> Listar(string id = "")
        {
            var listCompras = new List<Compra>();

            try
            {
                _datos.SetConsulta("SELECT C.Id, C.NumeroFactura, DC.IdArticulo, DC.Cantidad, C.Activo " +
                                   "FROM Compras C " +
                                   "INNER JOIN DetallesCompras DC ON C.Id = DC.IdCompra");

                if (!string.IsNullOrEmpty(id))
                {
                    _datos.SetConsulta("SELECT C.Id, C.NumeroFactura, DC.IdArticulo, DC.Cantidad, C.Activo " +
                                       "FROM Compras C " +
                                       "INNER JOIN DetallesCompras DC ON C.Id = DC.IdCompra " +
                                       "WHERE C.Id = @Id");
                    _datos.SetParametro("@Id", id);
                }

                _datos.EjecutarLectura();

                while (_datos.Lector.Read())
                {
                    var Compra = new Compra
                    {
                        Id = (int)_datos.Lector["Id"],
                        NumeroFactura = (int)_datos.Lector["NumeroFactura"],
                        Activo = (bool)_datos.Lector["Activo"]
                    };

                    var detalleCompra = new DetalleCompra
                    {
                        IdArticulo = (int)_datos.Lector["IdArticulo"],
                        Cantidad = (int)_datos.Lector["Cantidad"]
                    };
                    Compra.DetalleCompra.Add(detalleCompra);

                    listCompras.Add(Compra);
                }

                return listCompras;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar compras con detalles", ex);
            }
            finally
            {
                _datos.CerrarConexion();
            }
        }
        public void Add(Compra newEntity)
        {
            AccesoADatos datos = new AccesoADatos();

            try
            {
                datos.SetConsulta("INSERT INTO Compras (NumeroFactura, Facturada, Activo) OUTPUT INSERTED.Id VALUES (0, 0, 1)");

                datos.EjecutarLectura();

                int IdCompra = 0;

                if (datos.Lector.Read())
                {
                    IdCompra = Convert.ToInt32(datos.Lector["Id"]);
                }

                if (IdCompra > 0)
                {
                    foreach (var detalle in newEntity.DetalleCompra)
                    {
                        AccesoADatos datosDetalle = new AccesoADatos();

                        datosDetalle.SetConsulta("INSERT INTO DetallesCompras (IdCompra, IdArticulo, Cantidad) VALUES (@IdCompra, @IdArticulo, @Cantidad)");

                        datosDetalle.SetParametro("@IdCompra", IdCompra);
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
