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
                    CategoriaIvaNegocio categoriaIvaNegocio = new CategoriaIvaNegocio();
                    List<CategoriaIva> categoriaIvas = categoriaIvaNegocio.Listar();
                   
                    ddlIva.DataSource = categoriaIvas;
                    ddlIva.DataValueField = "Id";
                    ddlIva.DataTextField = "Descripcion";
                    ddlIva.DataBind();

                    string id = Request.QueryString["id"] != null ? Request.QueryString["id"] : "";

                    if(id != "")
                    {
                        ClienteNegocio clienteNegocio = new ClienteNegocio();
                        Cliente aux = (clienteNegocio.Listar(id))[0];

                        txtApellido.Text = aux.Apellidos;
                        txtNombreCliente.Text = aux.Nombres;
                        txtDni.Text = aux.DNI;
                        txtDomicilio.Text = aux.Domicilio;
                        txtEmail.Text = aux.Email;
                        txtCelular.Text = aux.Celular;
                        txtTelefono.Text = aux.Telefono;


                        ddlIva.SelectedValue = aux.categoriaIva.Id.ToString();
                    }

                    if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                        btnAgregarCliente.Text = "Editar";
                    else
                        btnAgregarCliente.Text = "Agregar";
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
            categoriaIva.Id = byte.Parse(ddlIva.SelectedValue);
            aux.categoriaIva = categoriaIva;
            aux.Domicilio = txtDomicilio.Text;
            aux.Email = txtEmail.Text;
            aux.Celular = txtCelular.Text;
            aux.Telefono = txtTelefono.Text;

            string id = Request.QueryString["id"] != null ? Request.QueryString["id"] : "";

            if (id != "")
            {
                aux.Id = int.Parse(id);
                clienteNegocio.Update(aux);
            }
            else
                clienteNegocio.Add(aux);

            Response.Redirect("BuscarCliente.aspx");
        }
    }
}