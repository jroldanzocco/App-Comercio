using J3AMS.Dominio;
using J3AMS.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnitOfWork.SqlServer;

namespace J3AMS.UI
{
    public partial class AltaProveedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("BuscarProveedor.aspx");
        }

        protected void btnAgregarProveedor_Click(object sender, EventArgs e)
        {
            var unitOfWork = new UnitOfWork.SqlServer.UnitOfWork();
            ProveedorNegocio negocio = new ProveedorNegocio(unitOfWork);
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