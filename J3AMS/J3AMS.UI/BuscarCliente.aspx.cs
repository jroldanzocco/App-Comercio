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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarClientes();
            }
        }

        protected void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            Response.Redirect("AltaCliente.aspx");
        }
        protected void btnEditarCliente_Click(object sender, EventArgs e)
        {

        }
        protected void btnEliminarCliente_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["Id"];

            if (!string.IsNullOrEmpty(id))
            {
                ClienteNegocio negocio = new ClienteNegocio();
                Cliente aux = new Cliente();

                if (int.TryParse(id, out int Id))
                {
                    aux.Id = Id;
                    //negocio.Delete(aux);
                }

                CargarClientes();
            }
        }

        private void CargarClientes()
        {
            ClienteNegocio negocio = new ClienteNegocio();
            ListaCliente = negocio.Listar();
            repRepetidor.DataSource = ListaCliente;
            repRepetidor.DataBind();
        }
    }
}