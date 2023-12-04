using J3AMS.Dominio;
using J3AMS.Negocio;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace J3AMS.UI
{

    public partial class BuscarProveedor : System.Web.UI.Page
    {
        private ProveedorNegocio _proveedores;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Session.Add("error", "No estás logueado");
                Response.Redirect("Default.aspx", false);
            }

            _proveedores = new ProveedorNegocio();
            if (!IsPostBack)
            {
                CargarProveedores();
                DeshabilitarTxtInforme();
            }
        }
        protected void btnVolverAlMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("PaginaPrincipal.aspx");
        }
        protected void btnNuevoProveedor_Click(object sender, EventArgs e)
        {
            Response.Redirect("AltaProveedor.aspx");
        }
        protected void btnEditarProveedor_Click(object sender, EventArgs e)
        {
            string id = ((Button)sender).CommandArgument;

            Response.Redirect("AltaProveedor.aspx?id=" + id);
        }
        protected void btnEliminarProveedor_Click(object sender, EventArgs e)
        {
            string id = ((Button)sender).CommandArgument;

            if (!string.IsNullOrEmpty(id))
            {

                if (int.TryParse(id, out int Id))
                {
                    _proveedores.LogicDelete(Id);
                }

                CargarProveedores();
            }
        }

        private void CargarProveedores()
        {
            Session.Add("ListaProveedores", _proveedores.Listar());
            repRepetidor.DataSource = Session["ListaProveedores"];
            repRepetidor.DataBind();
        }

        protected void btnInformeProveedor_Click(object sender, EventArgs e)
        {
            string id = ((Button)sender).CommandArgument;

            CargarInformeProveedor(int.Parse(id));

            string script = "$(document).ready(function () { $('#modalProveedor').modal('show'); });";
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", script, true);
        }


        private void CargarInformeProveedor(int idProveedor)
        {
            var proveedor = _proveedores.Get(idProveedor);


            if (proveedor != null)
            {
                lblInforme.Text = proveedor.RazonSocial;
                txtRazonSocial.Text = proveedor.RazonSocial;
                txtCuit.Text = proveedor.CUIT;
                txtDomicilio.Text = proveedor.Domicilio;
                txtTelefono.Text = proveedor.Telefono;
                txtCelular.Text = proveedor.Celular;
                txtEmail.Text = proveedor.Email;
                txtPlazoPago.Text = proveedor.PlazoPago.ToString();
            }
        }

        private void DeshabilitarTxtInforme()
        {
            txtRazonSocial.ReadOnly = true;
            txtCuit.ReadOnly = true;
            txtDomicilio.ReadOnly = true;
            txtTelefono.ReadOnly = true;
            txtCelular.ReadOnly = true;
            txtEmail.ReadOnly = true;
            txtPlazoPago.ReadOnly = true;
        }

        protected void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            List<Proveedor> lista = (List<Proveedor>)Session["ListaProveedores"];
            List<Proveedor> listaFiltrada = lista.FindAll(x => x.RazonSocial.ToUpper().Contains(txtBusqueda.Text.ToUpper()));
            repRepetidor.DataSource = listaFiltrada;
            repRepetidor.DataBind();
        }
    }
}