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
    public partial class BuscarMarca : System.Web.UI.Page
    {
        public List<Marca> ListaMarcas { get; set; }
        private MarcaNegocio _negocio;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Session.Add("error", "No estás logueado");
                Response.Redirect("Default.aspx", false);
            }

            _negocio = new MarcaNegocio();

            if(!IsPostBack)
            {
                CargarMarcas();
            }
        }

        private void CargarMarcas()
        {
            ListaMarcas = _negocio.Listar();
            repMarcas.DataSource = ListaMarcas;
            repMarcas.DataBind();
        }

        protected void btnEditarMarca_Click(object sender, EventArgs e)
        {
            string id = ((Button)sender).CommandArgument;

            Response.Redirect("AltaMarca.aspx?id=" + id);
        }

        protected void btnEliminarMarca_Click(object sender, EventArgs e)
        {
            string id = ((Button)sender).CommandArgument;
            if (!string.IsNullOrEmpty(id))
            {
                Marca aux = new Marca();
                if(byte.TryParse(id, out byte Id))
                {
                    aux.Id = Id;
                    _negocio.LogicDelete(aux);
                }

                CargarMarcas();
            }
        }

        protected void btnNuevaMarca_Click(object sender, EventArgs e)
        {
            Response.Redirect("AltaMarca.aspx");
        }

        protected void btnVolverAlMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("PaginaPrincipal.aspx");
        }
    }
}