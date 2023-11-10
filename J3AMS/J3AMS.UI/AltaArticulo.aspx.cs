using J3AMS.Dominio;
using J3AMS.Negocio;
using System;
using System.Collections.Generic;

namespace J3AMS.UI
{
    public partial class Alta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if(!IsPostBack)
                {
                        TipoNegocio tipoNegocio = new TipoNegocio();
                        //List<Tipo> tipos = tipoNegocio.Listar();
                        ProveedorNegocio proveedorNegocio = new ProveedorNegocio();
                        List<Proveedor> proveedores = proveedorNegocio.Listar();
                        MarcaNegocio marcaNegocio = new MarcaNegocio();
                        //List<Marca> marcas = marcaNegocio.Listar();

                        ddlTipo.DataSource = proveedores;
                        ddlTipo.DataValueField = "Id";
                        ddlTipo.DataTextField = "NombreFantasia";
                        ddlTipo.DataBind();

                        ddlMarca.DataSource = proveedores;
                        ddlMarca.DataValueField = "Id";
                        ddlMarca.DataTextField = "NombreFantasia";
                        ddlMarca.DataBind();

                        ddlProveedor.DataSource = proveedores;
                        ddlProveedor.DataValueField = "Id";
                        ddlProveedor.DataTextField = "Domicilio";
                        ddlProveedor.DataBind();

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        protected void btnAgregarArticulo_Click(object sender, EventArgs e)
        {
            ProductoNegocio negocio = new ProductoNegocio();
            Producto aux = new Producto();


            aux.Descripcion = txtDescripcion.Text;

            Tipo tipo = new Tipo();
            tipo.Id = int.Parse(ddlTipo.SelectedValue);
            aux.Tipo = tipo;

            Marca marca = new Marca();
            marca.Id = int.Parse(ddlMarca.SelectedValue);
            aux.Marca = marca;

            Proveedor proveedor = new Proveedor();
            proveedor.Id = int.Parse(ddlProveedor.SelectedValue);
            aux.Proveedor = proveedor;

            decimal.TryParse(txtPrecioCosto.Text,out decimal PrecioCosto);

            decimal.TryParse(txtPrecioVenta.Text, out decimal PrecioVenta);

            aux.StockMinimo = int.Parse(txtStockMinimo.Text);

            negocio.Add(aux);

            Response.Redirect("BuscarArticulo.aspx");
        }
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("BuscarArticulo.aspx");
        }
    }
}