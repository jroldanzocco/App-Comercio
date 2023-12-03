using J3AMS.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J3AMS.Negocio
{
    public class FacturaVentaNegocio
    {
        private readonly AccesoADatos _datos;

        public FacturaVentaNegocio()
        {
            _datos = new AccesoADatos();
        }

        public List<FacturaVenta> Listar()
        {
            List<FacturaVenta> facturaVentas = new List<FacturaVenta>();

            try
            {
                string query = "SELECT Numero, IdCliente, Importe, FechaEmision FROM FacturasVentas";

                _datos.SetConsulta(query);
                _datos.EjecutarLectura();

                while(_datos.Lector.Read())
                {
                    facturaVentas.Add(new FacturaVenta
                    {
                        Numero = (int)_datos.Lector["Numero"],
                        FechaEmision = (DateTime)_datos.Lector["FechaEmision"],
                        IdCliente = (int)_datos.Lector["IdCliente"],
                        Importe = (Decimal)_datos.Lector["Importe"]
                    });
                }

                return facturaVentas;
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
