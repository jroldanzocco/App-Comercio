using J3AMS.Dominio;
using J3AMS.Negocio;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using UnitOfWork.SqlServer;

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
                        var unitOfWork = new UnitOfWork.SqlServer.UnitOfWork();
                        TipoNegocio tipoNegocio = new TipoNegocio();
                        //List<Tipo> tipos = tipoNegocio.Listar();
                        ProveedorNegocio proveedorNegocio = new ProveedorNegocio(unitOfWork);
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

                string id = Request.QueryString["id"] != null ? Request.QueryString["id"] : "";

                if (id != "")
                {
                    ProductoNegocio negocio = new ProductoNegocio();
                    Producto aux = (negocio.Listar(id))[0];

                    txtNombre.Text = aux.Descripcion;
                    txtDescripcion.Text = "Campo a resolver";
                    txtStockMinimo.Text = "Revisar Query";
                    txtPrecioVenta.Text = aux.PrecioVenta.ToString();
                    txtPrecioCosto.Text = aux.PrecioCosto.ToString();

                    ddlTipo.SelectedValue = aux.Tipo.Id.ToString();
                    ddlMarca.SelectedValue = aux.Marca.Id.ToString();
                    ddlProveedor.SelectedValue = aux.Proveedor.Id.ToString();
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

            aux.Id = int.Parse(Request.QueryString["id"]);
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

            //aux.StockMinimo = int.Parse(txtStockMinimo.Text);

            if (Request.QueryString["id"] != null)
                negocio.Update(aux);
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