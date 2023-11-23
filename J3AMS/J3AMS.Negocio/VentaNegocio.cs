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
                _datos.SetConsulta("DESARROLLAR");

                if (id != "")
                {
                    _datos.SetConsulta("DESARROLLAR");
                    _datos.SetParametro("@Id", id);
                }

                _datos.EjecutarLectura();

                while (_datos.Lector.Read())
                {
                    listVentas.Add(new Venta
                    {
                        Id = (int)_datos.Lector["Id"],
                        Articulo = (int)_datos.Lector["Articulo"],
                        Cantidad = (int)_datos.Lector["Cantidad"],
                        NumeroFactura = (int)_datos.Lector["NumeroFactura"],
                        //Facturada - Hay que ponerlo en la BD como "cero" por default
                        //Facturado - Hay que ponerlo en la BD como "uno" por default
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
                datos.SetConsulta("INSERT INTO Ventas (Articulo, Cantidad, NumeroFactura, Facturada, Activo)\r\nVALUES (@Articulo, @Cantidad, 0, 0, 1)");

                datos.SetParametro("@Articulo", newEntity.Articulo);
                datos.SetParametro("@Cantidad", newEntity.Cantidad);
                //datos.SetParametro("@NumeroFactura", newEntity.NumeroFactura);
                //datos.SetParametro("@Facturada", newEntity.Facturada);
                datos.SetParametro("@Activo", newEntity.Activo);

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

