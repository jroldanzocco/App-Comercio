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
    public partial class AltaMarca : System.Web.UI.Page
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

            if(!IsPostBack)
            {
            string id = Request.QueryString["id"] != null ? Request.QueryString["id"] : "";

            if(id != "")
            {
                MarcaNegocio negocio = new MarcaNegocio();
                Marca aux = negocio.Get(int.Parse(id));
                txtNombre.Text = aux.Descripcion;
            }
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                btnAgregarMarca.Text = "Editar";
            else
                btnAgregarMarca.Text = "Agregar";
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("BuscarMarca.aspx");
        }

        protected void btnAgregarMarca_Click(object sender, EventArgs e)
        {
            MarcaNegocio negocio = new MarcaNegocio();
            Marca aux = new Marca();

            aux.Descripcion = txtNombre.Text;

            string id = Request.QueryString["id"] != null ? Request.QueryString["id"] : "";

            if (id !="")
            {
                aux.Id = byte.Parse(id);
                negocio.Update(aux);
            }
            else
                negocio.Add(aux);

            Response.Redirect("BuscarMarca.aspx");
        }
    }
}