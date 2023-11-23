using J3AMS.Negocio;
using J3AMS.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace J3AMS.UI
{
    public partial class BuscarTipo : System.Web.UI.Page
    {
        private List<Tipo> ListaTipos {  get; set; }
        private TipoNegocio _negocio;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Session.Add("error", "No estás logueado");
                Response.Redirect("Default.aspx", false);
            }

            _negocio = new TipoNegocio();

            if(!IsPostBack)
            {
                CargarTipos();
            }
        }

        private void CargarTipos()
        {
            ListaTipos = _negocio.Listar();
            repTipos.DataSource = ListaTipos;
            repTipos.DataBind();
        }

        protected void btnEditarTipo_Click(object sender, EventArgs e)
        {
            string id = ((Button)sender).CommandArgument;

            Response.Redirect("AltaTipo.aspx?id=" + id);
        }

        protected void btnEliminarTipo_Click(object sender, EventArgs e)
        {
            string id = ((Button)sender).CommandArgument;
            if (!string.IsNullOrEmpty(id))
            {
                Tipo aux = new Tipo();
                if (byte.TryParse(id, out byte Id))
                {
                    aux.Id = Id;
                    _negocio.LogicDelete(aux);
                }

                CargarTipos();
            }
        }

        protected void btnNuevoTipo_Click(object sender, EventArgs e)
        {
            Response.Redirect("AltaTipo.aspx");
        }

        protected void btnVolverAlMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("PaginaPrincipal.aspx");
        }
    }
}