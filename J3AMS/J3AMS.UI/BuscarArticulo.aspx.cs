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
    public partial class BuscarArticulo : System.Web.UI.Page
    {
        public List<Producto> ListaProducto { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ProductoNegocio negocio = new ProductoNegocio();
            ListaProducto = negocio.Listar();

            if (!IsPostBack)
            {
                repRepetidor.DataSource = ListaProducto;
                repRepetidor.DataBind();
            }
        }
        protected void btnNuevoArticulo_Click(object sender, EventArgs e)
        {
            Response.Redirect("AltaArticulo.aspx");
        }
    }
}