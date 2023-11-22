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
    public partial class AltaTipo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Session.Add("error", "No estás logueado");
                Response.Redirect("Default.aspx", false);
            }
            if (((J3AMS.Dominio.Usuario)Session["usuario"]).UserRole != UserRole.ADMIN)
            {
                Session.Add("error", "Necesitas permisos. Contactar al administrador");
                Response.Redirect("PaginaPrincipal.aspx", false);
            }

            if (!IsPostBack)
            {
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"] : "";

                if (id != "")
                {
                    TipoNegocio negocio = new TipoNegocio();
                    Tipo aux = negocio.Get(int.Parse(id));
                    txtNombre.Text = aux.Descripcion;
                }
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                    btnAgregarTipo.Text = "Editar";
                else
                    btnAgregarTipo.Text = "Agregar";
            }
        }

        protected void btnAgregarTipo_Click(object sender, EventArgs e)
        {
            TipoNegocio negocio = new TipoNegocio();
            Tipo aux = new Tipo();

            aux.Descripcion = txtNombre.Text;
            string id = Request.QueryString["id"] != null ? Request.QueryString["id"] : "";

            if(id != "")
            {
                aux.Id = byte.Parse(id);
                negocio.Update(aux);
            }
            else
                negocio.Add(aux);

            Response.Redirect("BuscarTipo.aspx");
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("BuscarTipo.aspx");
        }
    }
}