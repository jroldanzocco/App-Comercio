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
        protected void btnAgregarArticulo_Click(object sender, EventArgs e)
        {
            ProductoNegocio negocio = new ProductoNegocio();
            Producto aux = new Producto();

            aux.Codigo = int.Parse(txtCodigo.Text);

            aux.Descripcion = txtDescripcion.Text;

            Tipo tipo = new Tipo();
            tipo.Id = int.Parse(txtTipo.Text);
            aux.Tipo = tipo;

            Marca marca = new Marca();
            marca.Id = int.Parse(txtMarca.Text);
            aux.Marca = marca;

            Proveedor proveedor = new Proveedor();
            proveedor.Id = int.Parse(txtProveedor.Text);
            aux.Proveedor = proveedor;

            decimal.TryParse(txtPrecioCosto.Text, out decimal PrecioCosto);

            decimal.TryParse(txtPrecioVenta.Text, out decimal PrecioVenta);

            proveedor.Id = int.Parse(txtStockMinimo.Text);

            negocio.Add(aux);

            Response.Redirect("MenuArticulos.aspx");
        }
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("BuscarArticulo.aspx");
        }
    }
}