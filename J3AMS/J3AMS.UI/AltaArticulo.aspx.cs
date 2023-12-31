﻿using J3.AMS.Common;
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
            if (Session["usuario"] == null)
            {
                Session.Add("error", "No estás logueado");
                Response.Redirect("Default.aspx", false);
            }
            if (((J3AMS.Dominio.Usuario)Session["usuario"]).UserRole != UserRole.ADMIN)
            {
                Session.Add("error", "Necesitas permisos. Contactar al administrador");
                Response.Redirect("PaginaPrincipal.aspx", false);
            }
            try
            {
                if (!IsPostBack)
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
                    ddlTipo.Items.Insert(0, new ListItem("-- Seleccione Tipo --", string.Empty));

                    ddlMarca.DataSource = marcas;
                    ddlMarca.DataValueField = "Id";
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataBind();
                    ddlMarca.Items.Insert(0, new ListItem("-- Seleccione Marca --", string.Empty));

                    ddlProveedor.DataSource = proveedores;
                    ddlProveedor.DataValueField = "Id";
                    ddlProveedor.DataTextField = "NombreFantasia";
                    ddlProveedor.DataBind();
                    ddlProveedor.Items.Insert(0, new ListItem("-- Seleccione Proveedor --", string.Empty));

                    string id = Request.QueryString["id"] != null ? Request.QueryString["id"] : "";
                    int.TryParse(id, out int idNum);
                    if (id != "" && idNum.ToString() == id)
                    {
                        
                        ProductoNegocio negocio = new ProductoNegocio();
                        Producto aux = (negocio.Get(idNum));

                        txtDescripcion.Text = aux.Descripcion;
                        txtStock.Text = aux.Stock.ToString();
                        txtPrecioVenta.Text = aux.PrecioVenta.ToString();
                        txtPrecioCosto.Text = aux.PrecioCompra.ToString();

                        ddlTipo.SelectedValue = aux.Tipo.Id.ToString();
                        ddlMarca.SelectedValue = aux.Marca.Id.ToString();
                        ddlProveedor.SelectedValue = aux.Proveedor.Id.ToString();
                    }
                    
                    if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                        btnAgregarArticulo.Text = "Editar";
                    else
                        btnAgregarArticulo.Text = "Agregar";
                }




            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        protected void btnAgregarArticulo_Click(object sender, EventArgs e)
        {
            var tipoSelectedValue = ddlTipo.SelectedValue;
            var marcaSelectedValue = ddlMarca.SelectedValue;
            var proveedorSelectedValue = ddlProveedor.SelectedValue;
            ProductoNegocio negocio = new ProductoNegocio();
            Producto aux = new Producto();

            aux.Descripcion = txtDescripcion.Text;

            lblErrorTipo.Text = ddlTipo.SelectedIndex == 0 ? "Debes elegir un tipo" : "";
            lblErrorMarca.Text = ddlMarca.SelectedIndex == 0 ? "Debes elegir una marca" : "";
            lblErrorProveedor.Text = ddlProveedor.SelectedIndex == 0 ? "Debes elegir un proveedor" : "";

            if(ddlTipo.SelectedValue != "" && ddlMarca.SelectedValue != "" && ddlProveedor.SelectedValue != "" )
            {
                Tipo tipo = new Tipo();
                tipo.Id = byte.Parse(ddlTipo.SelectedValue);
                aux.Tipo = tipo;

                Marca marca = new Marca();
                marca.Id = byte.Parse(ddlMarca.SelectedValue);
                aux.Marca = marca;

                Proveedor proveedor = new Proveedor();
                proveedor.Id = int.Parse(ddlProveedor.SelectedValue);
                aux.Proveedor = proveedor;
            }

            decimal.TryParse(txtPrecioCosto.Text, out decimal PCValidator);
            aux.PrecioCompra = PCValidator;

            decimal.TryParse(txtPrecioVenta.Text, out decimal PVValidator);
            aux.PrecioVenta = PVValidator;

            int.TryParse(txtStock.Text, out int StockValidator);
            aux.Stock = StockValidator;

            string id = Request.QueryString["id"];

            lblErrorVenta.Text = PVValidator < PCValidator ? "El precio de venta no puede ser menor al precio de costo" : "";

            //if()


            if (ValidatorsDA.TryValidateModel(aux) && PVValidator >= PCValidator)
            {
            
                if (id != null)
                {
                    aux.Id = int.Parse(id);
                    negocio.Update(aux);
                }
                else
                {
                    negocio.Add(aux);
                }
                Response.Redirect("BuscarArticulo.aspx");

            }
        }
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("BuscarArticulo.aspx");
        }
    }
}