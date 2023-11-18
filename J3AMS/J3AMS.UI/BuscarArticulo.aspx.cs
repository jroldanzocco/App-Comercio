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
            if (!IsPostBack)
            {
                CargarProductos();
            }
        }
        protected void btnVolverAlMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("PaginaPrincipal.aspx");
        }
        protected void btnNuevoArticulo_Click(object sender, EventArgs e)
        {
            Response.Redirect("AltaArticulo.aspx");
        }
        protected void btnEditarArticulo_Click(object sender, EventArgs e)
        {
            string id = ((Button)sender).CommandArgument;

            Response.Redirect("AltaArticulo.aspx?id=" + id);
        }
        protected void btnEliminarArticulo_Click(object sender, EventArgs e)
        {
          
            string id = ((Button)sender).CommandArgument;

            if (!string.IsNullOrEmpty(id))
            {
                ProductoNegocio negocio = new ProductoNegocio();
                Producto aux = new Producto();

                if (int.TryParse(id, out int Id))
                {
                    aux.Id = Id;
                    negocio.Delete(aux);
                }

                CargarProductos();
            }
        }

        private void CargarProductos()
        {
            ProductoNegocio negocio = new ProductoNegocio();
            ListaProducto = negocio.Listar();
            repRepetidor.DataSource = ListaProducto;
            repRepetidor.DataBind();
        }
    }
}
