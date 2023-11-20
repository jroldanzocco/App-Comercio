using J3AMS.Dominio;
using J3AMS.Negocio;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

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
                        List<Tipo> tipos = tipoNegocio.Listar();
                        ProveedorNegocio proveedorNegocio = new ProveedorNegocio();
                        List<Proveedor> proveedores = proveedorNegocio.Listar();
                        MarcaNegocio marcaNegocio = new MarcaNegocio();
                        List<Marca> marcas = marcaNegocio.Listar();

                        ddlTipo.DataSource = tipos;
                        ddlTipo.DataValueField = "Id";
                        ddlTipo.DataTextField = "Descripcion";
                        ddlTipo.DataBind();

                        ddlMarca.DataSource = marcas;
                        ddlMarca.DataValueField = "Id";
                        ddlMarca.DataTextField = "Descripcion";
                        ddlMarca.DataBind();

                        ddlProveedor.DataSource = proveedores;
                        ddlProveedor.DataValueField = "Id";
                        ddlProveedor.DataTextField = "NombreFantasia";
                        ddlProveedor.DataBind();

                        string id = Request.QueryString["id"] != null ? Request.QueryString["id"] : "";

                        if (id != "")
                        {
                            ProductoNegocio negocio = new ProductoNegocio();
                            Producto aux = (negocio.Listar(id))[0];

                            txtNombre.Text = "Campo a resolver";
                            txtDescripcion.Text = aux.Descripcion;
                            txtStockMinimo.Text = aux.StockMinimo.ToString();
                            txtPrecioVenta.Text = aux.PrecioVenta.ToString();
                            txtPrecioCosto.Text = aux.PrecioCosto.ToString();

                            ddlTipo.SelectedValue = aux.Tipo.Id.ToString();
                            ddlMarca.SelectedValue = aux.Marca.Id.ToString();
                            ddlProveedor.SelectedValue = aux.Proveedor.Id.ToString();
                        }
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
            tipo.Id = byte.Parse(ddlTipo.SelectedValue);
            aux.Tipo = tipo;

            Marca marca = new Marca();
            marca.Id = byte.Parse(ddlMarca.SelectedValue);
            aux.Marca = marca;

            Proveedor proveedor = new Proveedor();
            proveedor.Id = int.Parse(ddlProveedor.SelectedValue);
            aux.Proveedor = proveedor;

            aux.PrecioCosto = Convert.ToDecimal(txtPrecioCosto.Text);

            aux.PrecioVenta = Convert.ToDecimal(txtPrecioVenta.Text);

            aux.StockMinimo = int.Parse(txtStockMinimo.Text);

            string id = Request.QueryString["id"];
            if (id != null)
            {
                aux.Id = int.Parse(id);
                negocio.Update(aux);
            }
            else
                negocio.Add(aux);

            Response.Redirect("BuscarArticulo.aspx");
        }
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("BuscarArticulo.aspx");
        }
    }
}