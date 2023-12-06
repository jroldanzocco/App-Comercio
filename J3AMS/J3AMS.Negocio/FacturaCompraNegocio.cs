using J3AMS.Dominio;
using System;
using System.Collections.Generic;

namespace J3AMS.Negocio
{
    public class FacturaCompraNegocio
    {
        private readonly AccesoADatos _datos;
        public FacturaCompraNegocio()
        {
            _datos = new AccesoADatos();
        }
        public List<FacturaCompra> Listar()
        {
            List<FacturaCompra> facturaCompras = new List<FacturaCompra>();

            try
            {
                string query = "SELECT Numero, IdProveedor, Importe, FechaEmision, Comprador, RazonSocial + ' ' + NombreFantasia AS Apenom FROM FacturasCompras\r\nINNER JOIN Proveedores C ON C.Id = IdProveedor";

                _datos.SetConsulta(query);
                _datos.EjecutarLectura();

                while (_datos.Lector.Read())
                {
                    facturaCompras.Add(new FacturaCompra
                    {
                        Numero = (int)_datos.Lector["Numero"],
                        IdProveedor = (int)_datos.Lector["IdProveedor"],
                        FechaEmision = (DateTime)_datos.Lector["FechaEmision"],
                        proveedor = _datos.Lector["Apenom"] as string ?? string.Empty,
                        Importe = (Decimal)_datos.Lector["Importe"],
                        Comprador = _datos.Lector["Comprador"] as string ?? string.Empty
                    });
                }

                return facturaCompras;
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

        public void Add(FacturaCompra facturaCompra, string usuario)
        {
            try
            {
                _datos.SetConsulta("INSERT INTO FacturasCompras (IdProveedor, Importe, FechaEmision, Comprador, Activo) " +
                                         "VALUES (@IdProveedor, @Importe, GETDATE(), @Comprador, 1)");
                _datos.SetParametro("@IdProveedor", facturaCompra.IdProveedor);
                _datos.SetParametro("@Importe", facturaCompra.Importe);
                _datos.SetParametro("@Comprador", usuario);
                _datos.EjecutarLectura();

            }
            catch (Exception ex)
            {

                throw new Exception("Error al guardar la factura en la base de datos", ex);
            }
            finally
            {
                _datos.CerrarConexion();
            }
        }

        public void Add(FacturaCompra facturaCompra, object v)
        {
            throw new NotImplementedException();
        }
    }
}