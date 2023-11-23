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
                _datos.SetConsulta("DESARROLLAR");

                if (id != "")
                {
                    _datos.SetConsulta("DESARROLLAR");
                    _datos.SetParametro("@Id", id);
                }

                _datos.EjecutarLectura();

                while (_datos.Lector.Read())
                {
                    listCompras.Add(new Compra
                    {
                        Id = (int)_datos.Lector["Id"],
                        IdArticulo = (int)_datos.Lector["IdArticulo"],
                        Cantidad = (int)_datos.Lector["Cantidad"],
                        NumeroFactura = (int)_datos.Lector["NumeroFactura"],
                        //Facturada - Hay que ponerlo en la BD como "cero" por default
                        //Facturado - Hay que ponerlo en la BD como "uno" por default
                    });
                }
                return listCompras;
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
        public void Add(Compra newEntity)
        {
            AccesoADatos datos = new AccesoADatos();
            try
            {
                datos.SetConsulta("INSERT INTO Compras (IdArticulo, Cantidad, NumeroFactura, Facturada, Activo)\r\nVALUES (@IdArticulo, @Cantidad, @NumeroFactura, 0, 1)");

                datos.SetParametro("@IdArticulo", newEntity.IdArticulo);
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
