using J3AMS.Dominio;
using J3AMS.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace J3AMS.UI
{
    public partial class DetalleFactura : System.Web.UI.Page
    {
        private List<DetalleVenta> detalles = new List<DetalleVenta>();
        private ClienteNegocio clienteNegocio = new ClienteNegocio();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Session.Add("error", "No estás logueado");
                Response.Redirect("Default.aspx", false);
            }

            string numero = Request.QueryString[0];
            lblNumeroFactura.Text = "Factura Número: " + numero;

            CargarDetallesVenta();
            lblTotal.Text = "Total: $" + CalcularTotal(detalles).ToString();

            string cliente = Request.QueryString[1];
            lblCliente.Text = "Cliente: " + clienteNegocio.Listar(cliente)[0].NombreCompleto;
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("BuscarVentas.aspx");
        }

        private void CargarDetallesVenta()
        {
            string numero = Request.QueryString["Numero"];
            Session.Add("ListaDetalles", ConsultarDetalles(numero));
            repDetallesFactura.DataSource = Session["ListaDetalles"];
            repDetallesFactura.DataBind();
        }

        private List<DetalleVenta> ConsultarDetalles(string numero)
        {
            AccesoADatos datos = new AccesoADatos();
            
            try
            {
            datos.SetConsulta("SELECT P.Descripcion, D.Cantidad, D.PrecioUnitario\r\nFROM Productos P\r\nINNER JOIN DetallesVentas D ON P.Id = D.IdArticulo\r\nINNER JOIN FacturasVentas F ON F.Numero = D.IdVenta\r\nWHERE F.Numero = @Numero");
            datos.SetParametro("@Numero", int.Parse(numero));
            datos.EjecutarLectura();

            while(datos.Lector.Read())
                {
                    detalles.Add(new DetalleVenta
                    {
                        Descripcion = datos.Lector["Descripcion"] as string ?? string.Empty,
                        Cantidad = (int)datos.Lector["Cantidad"],
                        PrecioUnitario = (Decimal)datos.Lector["PrecioUnitario"]
                    }
                        );
                }
                return detalles;
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

        private Decimal CalcularTotal(List<DetalleVenta> detalles)
        {
            Decimal total = 0;

            foreach (DetalleVenta aux in detalles)
            {
                total += (aux.PrecioUnitario * aux.Cantidad);
            }

            return total;
        }
    }
}