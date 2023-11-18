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
    }
}