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
    public partial class BuscarCompras : System.Web.UI.Page
    {
        public List<Compra> ListaCompra { get; set; }
        private CompraNegocio _negocio;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Session.Add("error", "No estás logueado");
                Response.Redirect("Default.aspx", false);
            }

            _negocio = new CompraNegocio();

            if (!IsPostBack)
            {
                CargarCompras();
            }
        }
        private void CargarCompras()
        {
            CompraNegocio negocio = new CompraNegocio();
            ListaCompra = negocio.Listar();
            repRepetidorCompras.DataSource = ListaCompra;
            repRepetidorCompras.DataBind();
        }
        protected void btnVolverAlMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("PaginaPrincipal.aspx");
        }
        protected void btnDetallesCompra_Click(object sender, EventArgs e)
        {
            //A DESARROLLAR
        }
    }
}