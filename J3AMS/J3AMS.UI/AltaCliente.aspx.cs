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
    public partial class AltaCliente : System.Web.UI.Page
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
            try
            {
                if(!IsPostBack)
                {
                    //CategoriaIvaNegocio categoriaIvaNegocio = new CategoriaIvaNegocio();
                    //List<CategoriaIva> categoriaIvas = categoriaIvaNegocio.Listar();
                    ProveedorNegocio proveedorNegocio = new ProveedorNegocio();
                    List<Proveedor> proveedores = proveedorNegocio.Listar();

                    ddlIva.DataSource = proveedores;
                    ddlIva.DataValueField = "Id";
                    ddlIva.DataTextField = "NombreFantasia";
                    ddlIva.DataBind();

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("BuscarCliente.aspx");
        }

        protected void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            ClienteNegocio clienteNegocio = new ClienteNegocio();
            Cliente aux = new Cliente();

            aux.Apellidos = txtApellido.Text;
            aux.Nombres = txtNombreCliente.Text;
            aux.DNI = txtDni.Text;
            CategoriaIva categoriaIva = new CategoriaIva();
            categoriaIva.Id = int.Parse(ddlIva.SelectedValue);
            aux.categoriaIva = categoriaIva;
            aux.Plazo = byte.Parse(txtPlazo.Text);

            clienteNegocio.Add(aux);

            Response.Redirect("BuscarCliente.aspx");
        }
    }
}