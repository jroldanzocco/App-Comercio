using J3AMS.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace J3AMS.UI
{
    public partial class BuscarCompras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Session.Add("error", "No estás logueado");
                Response.Redirect("Default.aspx", false);
            }

            if (!IsPostBack)
            {
                CargarFacturas();
            }
        }
        private void CargarFacturas()
        {
            FacturaCompraNegocio negocio = new FacturaCompraNegocio();
            Session.Add("ListaFacturas", negocio.Listar());
            repFacturas.DataSource = Session["ListaFacturas"];
            repFacturas.DataBind();

        }
        protected void btnDetalle_Click(object sender, EventArgs e)
        {
            string[] numero = ((Button)sender).CommandArgument.Split(',');
            Response.Redirect("DetalleFactura.aspx?Numero=" + numero[0] + "&Proveedor=" + numero[1] + "&Comp=" + numero[2]);
        }
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("PaginaPrincipal.aspx");
        }
    }
}