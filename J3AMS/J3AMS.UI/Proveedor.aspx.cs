using J3AMS.Dominio;
using J3AMS.Negocio;
using System;
using System.Web.UI.WebControls;

namespace J3AMS.UI
{
    public partial class BuscarProveedor : System.Web.UI.Page
    {
        private ProveedorNegocio _proveedorNegocio;

        protected void Page_Load(object sender, EventArgs e)
        {
            _proveedorNegocio = new ProveedorNegocio(new UnitOfWork.SqlServer.UnitOfWork());
            if (!IsPostBack)
            {
                CargarProveedores();
            }
        }

        protected void btnNuevoProveedor_Click(object sender, EventArgs e)
        {
            Response.Redirect("AltaProveedor.aspx");
        }
        protected void btnEditarProveedor_Click(object sender, EventArgs e)
        {

        }
        protected void btnEliminarProveedor_Click(object sender, EventArgs e)
        {
            string idTemp = ((Button)sender).CommandArgument;

            if (!string.IsNullOrEmpty(idTemp))
            {
                int.TryParse(idTemp, out int id);
                _proveedorNegocio.Delete(id);
            }
            CargarProveedores();
        }

        private void CargarProveedores()
        {
            var ListaProveedor = _proveedorNegocio.Listar();
            repRepetidor.DataSource = ListaProveedor;
            repRepetidor.DataBind();
        }

        protected void modal_Click(object sender, EventArgs e)
        {
            string script = "$(document).ready(function () { $('#modalProveedor').modal('show'); });";
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", script, true);

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            var proveedor = new Proveedor
            {
                RazonSocial = txtRazonSocial.Text,
                NombreFantasia = txtNombreFantasia.Text,
                CUIT = txtCuit.Text,
                Domicilio = txtDomicilio.Text,
                Telefono = txtTelefono.Text,
                Celular = txtCelular.Text,
                Email = txtEmail.Text,

            };
            try
            {
                _proveedorNegocio.Insert(proveedor);
                lblMsg.Text = "Proveedor agregado con exito";
            }
            catch (Exception)
            {
                lblMsg.Text = "Error al insertar proveedor";
                return;
            }


            CargarProveedores();
        }
    }
}