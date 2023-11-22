using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace J3AMS.UI
{
    public partial class PaginaPrincipal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Session.Add("error", "No estás logueado");
                Response.Redirect("Default.aspx");
            }
        }

        protected void btnProductos_Click(object sender, EventArgs e)
        {
            Response.Redirect("BuscarArticulo.aspx");
        }

        protected void btnClientes_Click(object sender, EventArgs e)
        {
            Response.Redirect("BuscarCliente.aspx");
        }
        protected void btnNuevaVenta_Click(object sender, EventArgs e)
        {
            Response.Redirect("NuevaVenta.aspx");
        }
        protected void btnNuevaCompra_Click(object sender, EventArgs e)
        {
            Response.Redirect("NuevaCompra.aspx");
        }
        protected void btnProveedores_Click(object sender, EventArgs e)
        {
            Response.Redirect("BuscarProveedor.aspx");
        }
        protected void btnFacturas_Click(object sender, EventArgs e)
        {
            Response.Redirect("BuscarFacturaVenta.aspx");
        }

        protected void btnMarcas_Click(object sender, EventArgs e)
        {
            Response.Redirect("BuscarMarca.aspx");
        }

        protected void btnTipos_Click(object sender, EventArgs e)
        {
            Response.Redirect("BuscarTipo.aspx");
        }
    }
}