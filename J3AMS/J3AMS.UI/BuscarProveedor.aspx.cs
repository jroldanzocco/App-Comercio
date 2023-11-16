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
    public partial class BuscarProveedor : System.Web.UI.Page
    {
        public List<Proveedor> ListaProveedor { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
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
            string id = ((Button)sender).CommandArgument;

            if (!string.IsNullOrEmpty(id))
            {
                var unitOfWork = new UnitOfWorkSqlServer();
                ProveedorNegocio negocio = new ProveedorNegocio(unitOfWork);
                Proveedor aux = new Proveedor();

                if (int.TryParse(id, out int Id))
                {
                    aux.Id = Id;
                    negocio.SoftDelete(aux);
                }

                CargarProveedores();
            }
        }

        private void CargarProveedores()
        {
            var unitOfWork = new UnitOfWorkSqlServer();
            ProveedorNegocio negocio = new ProveedorNegocio(unitOfWork);
            ListaProveedor = negocio.Listar();
            repRepetidor.DataSource = ListaProveedor;
            repRepetidor.DataBind();
        }
    }
}