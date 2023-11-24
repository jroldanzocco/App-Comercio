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
    public partial class BuscarCliente : System.Web.UI.Page
    {
        public List<Cliente> ListaCliente { get; set; }
        private ClienteNegocio _negocio;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Session.Add("error", "No estás logueado");
                Response.Redirect("Default.aspx", false);
            }

            _negocio = new ClienteNegocio();

            if (!IsPostBack)
            {
                CargarClientes();
                DeshabilitarTxtClientes();
            }
        }


        protected void btnVolverAlMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("PaginaPrincipal.aspx");
        }


        protected void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            Response.Redirect("AltaCliente.aspx");
        }


        protected void btnEditarCliente_Click(object sender, EventArgs e)
        {
            string id = ((Button)sender).CommandArgument;

            Response.Redirect("AltaCliente.aspx?id=" + id);
        }


        protected void btnEliminarCliente_Click(object sender, EventArgs e)
        {
            string id = ((Button)sender).CommandArgument;

            if (!string.IsNullOrEmpty(id))
            {
                ClienteNegocio negocio = new ClienteNegocio();
                Cliente aux = new Cliente();

                if (int.TryParse(id, out int Id))
                {
                    aux.Id = Id;
                    negocio.LogicDelete(aux);
                }

                CargarClientes();
            }
        }


        private void CargarClientes()
        {
            ClienteNegocio negocio = new ClienteNegocio();
            Session.Add("ListaClientes", negocio.Listar());
            repRepetidor.DataSource = Session["ListaClientes"];
            repRepetidor.DataBind();
        }


        protected void btnInformeCliente_Click(object sender, EventArgs e)
        {
            string id = ((Button)sender).CommandArgument;
            CargarInformeCLientes(id);

            string script = "$(document).ready(function () { $('#modalCliente').modal('show'); });";
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", script, true);
        }


        private void CargarInformeCLientes(string id)
        {
            List<Cliente> clientes = _negocio.Listar(id);
            Cliente aux = clientes[0];

            if(aux != null)
            {
                lblInformeCliente.Text = aux.Apellidos + " " + aux.Nombres;
                txtApellido.Text = aux.Apellidos;
                txtNombre.Text = aux.Nombres;
                txtDni.Text = aux.DNI;
                txtTelefonoCliente.Text = aux.Telefono;
                txtCelularCliente.Text = aux.Celular;
                txtEmailCliente.Text = aux.Email;
                txtCategoria.Text = aux.categoriaIva.Descripcion;
                txtPlazoPagoClientes.Text = aux.Plazo.ToString();
            }
        }


        private void DeshabilitarTxtClientes()
        {
            txtApellido.ReadOnly = true;
            txtNombre.ReadOnly = true;
            txtDni.ReadOnly = true;
            txtTelefonoCliente.ReadOnly = true;
            txtCelularCliente.ReadOnly = true;
            txtEmailCliente.ReadOnly = true;
            txtCategoria.ReadOnly = true;
            txtPlazoPagoClientes.ReadOnly = true;
        }


        protected void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            List<Cliente> lista = (List<Cliente>)Session["ListaClientes"];
            List<Cliente> listaFiltrada = lista.FindAll(x => x.Apellidos.ToUpper().Contains(txtBusqueda.Text.ToUpper()));
            repRepetidor.DataSource = listaFiltrada;
            repRepetidor.DataBind();
        }
    }
}