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
    public partial class BuscarVentas : System.Web.UI.Page
    {
        public List<Venta> ListaVenta { get; set; }
        private VentaNegocio _negocio;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Session.Add("error", "No estás logueado");
                Response.Redirect("Default.aspx", false);
            }

            _negocio = new VentaNegocio();

            if (!IsPostBack)
            {
                CargarVentas();
            }
        }
        private void CargarVentas()
        {
            VentaNegocio negocio = new VentaNegocio();
            ListaVenta = negocio.Listar();
            repRepetidorVentas.DataSource = ListaVenta;
            repRepetidorVentas.DataBind();
        }
        protected void btnVolverAlMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("PaginaPrincipal.aspx");
        }
        protected void btnDetallesVenta_Click(object sender, EventArgs e)
        {
            //A DESARROLLAR
        }
    }
}