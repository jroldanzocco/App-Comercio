using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace J3AMS.UI
{
    public partial class BuscarFacturas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarFacturasPorNumero();
        }

        private void BuscarFacturasPorNumero()
        {
            try
            {
                long numeroFactura;
                if (long.TryParse(txtNumeroFactura.Text.Trim(), out numeroFactura))
                {
                    //DataTable dtResultados = BuscarEnBaseDeDatos(numeroFactura);

                    //gvResultados.DataSource = dtResultados;
                    //gvResultados.DataBind();
                }
                else
                {
                    Response.Write("Número de factura no válido.");
                }
            }
            catch (Exception ex)
            {
                Response.Write($"Error al buscar facturas: {ex.Message}");
            }
        }
        //DESARROLLAR
        //private DataTable BuscarEnBaseDeDatos(long numeroFactura)
        //{

        //}
        protected void btnVolverAlMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("PaginaPrincipal.aspx");
        }
        protected void btnImprimir_Click(object sender, EventArgs e)
        {

        }
    }
}
