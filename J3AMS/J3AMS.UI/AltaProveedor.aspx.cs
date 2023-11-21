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
    public partial class AltaProveedor : System.Web.UI.Page
    {
        private ProveedorNegocio _proveedores;
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
            _proveedores = new ProveedorNegocio();

            if (!IsPostBack)
            {
                // Verifica si existe un parámetro "id" en la URL
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    // Si existe, significa que estás editando, cambia el texto del botón a "Editar"
                    btnAgregarProveedor.Text = "Editar";
                }
                else
                {
                    // Si no existe, significa que estás agregando, deja el texto del botón como "Agregar"
                    btnAgregarProveedor.Text = "Agregar";
                }
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("BuscarProveedor.aspx");
        }

        protected void btnAgregarProveedor_Click(object sender, EventArgs e)
        {
            ProveedorNegocio negocio = new ProveedorNegocio();
            Proveedor aux = new Proveedor();

            aux.RazonSocial = txtRazonSocial.Text;
            aux.NombreFantasia = txtNombre.Text;
            aux.CUIT = txtCuit.Text;
            aux.Domicilio = txtDomicilio.Text;
            aux.Telefono = txtTelefono.Text;

            negocio.Add(aux);

            Response.Redirect("BuscarProveedor.aspx");
        }
    }
}