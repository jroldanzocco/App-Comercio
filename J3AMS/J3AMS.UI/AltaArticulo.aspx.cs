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
    public partial class Alta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            ProductoNegocio negocio = new ProductoNegocio();
            Producto aux = new Producto();

            aux.Codigo = int.Parse(txtCodigo.Text);

            aux.Descripcion = txtDescripcion.Text;

            Tipo tipo = new Tipo();
            tipo.Descripcion = txtTipo.Text;
            aux.Tipo = tipo;

            Marca marca = new Marca();
            marca.Descripcion = txtDescripcion.Text;
            aux.Marca = marca;

            Proveedor proveedor = new Proveedor();
            proveedor.RazonSocial = txtDescripcion.Text;
            aux.Proveedor = proveedor;

            aux.Stock = int.Parse(txtStock.Text);

            negocio.Add(aux);

            Response.Redirect("MenuArticulos.aspx");
        }
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("MenuArticulos.aspx");
        }
    }
}