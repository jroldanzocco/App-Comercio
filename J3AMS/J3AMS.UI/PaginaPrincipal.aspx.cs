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

        }

        protected void btnProductos_Click(object sender, EventArgs e)
        {
            Response.Redirect("BuscarArticulo.aspx");
        }

        protected void btnClientes_Click(object sender, EventArgs e)
        {
            Response.Redirect("BuscarCliente.aspx");
        }

        protected void btnProveedores_Click(object sender, EventArgs e)
        {
            Response.Redirect("BuscarProveedor.aspx");
        }
    }
}