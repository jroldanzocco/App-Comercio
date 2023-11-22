﻿using J3AMS.Dominio;
using J3AMS.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace J3AMS.UI
{
    public partial class BuscarArticulo : System.Web.UI.Page
    {
        public List<Producto> ListaProducto { get; set; }
        private ProductoNegocio _negocios;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Session.Add("error", "No estás logueado");
                Response.Redirect("Default.aspx", false);
            }

            _negocios = new ProductoNegocio();

            if (!IsPostBack)
            {
                CargarProductos();
                DeshabilitarTxtProductos();
            }
        }
        protected void btnVolverAlMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("PaginaPrincipal.aspx");
        }
        protected void btnNuevoArticulo_Click(object sender, EventArgs e)
        {
            Response.Redirect("AltaArticulo.aspx");
        }
        protected void btnEditarArticulo_Click(object sender, EventArgs e)
        {
            string id = ((Button)sender).CommandArgument;

            Response.Redirect("AltaArticulo.aspx?id=" + id);
        }
        protected void btnEliminarArticulo_Click(object sender, EventArgs e)
        {
          
            string id = ((Button)sender).CommandArgument;

            if (!string.IsNullOrEmpty(id))
            {
                ProductoNegocio negocio = new ProductoNegocio();
                Producto aux = new Producto();

                if (int.TryParse(id, out int Id))
                {
                    aux.Id = Id;
                    negocio.Delete(aux);
                }

                CargarProductos();
            }
        }

        private void CargarProductos()
        {
            ProductoNegocio negocio = new ProductoNegocio();
            ListaProducto = negocio.Listar();
            repRepetidor.DataSource = ListaProducto;
            repRepetidor.DataBind();
        }

        protected void btnInformeArticulo_Click(object sender, EventArgs e)
        {
            string id = ((Button)sender).CommandArgument;

            CargarInformeProductos(id);
            string script = "$(document).ready(function () { $('#modalArticulo').modal('show'); });";
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", script, true);
        }

        private void CargarInformeProductos(string id)
        {
            List<Producto> productos = _negocios.Listar(id);
            Producto aux = productos[0];

            if(aux != null)
            {
                lblInformeArticulo.Text = aux.Descripcion;
                txtDescripcion.Text = aux.Descripcion;
                txtTipo.Text = aux.Tipo.Descripcion;
                txtMarca.Text = aux.Marca.Descripcion;
                txtProveedor.Text = aux.Proveedor.NombreFantasia;
                txtPrecioCosto.Text = aux.PrecioCosto.ToString();
                txtPrecioVenta.Text = aux.PrecioVenta.ToString();
                txtStock.Text = aux.Stock.ToString();
                txtStockMinimo.Text = aux.StockMinimo.ToString();
            }
        }

        private void DeshabilitarTxtProductos()
        {
            txtDescripcion.ReadOnly = true;
            txtTipo.ReadOnly = true;
            txtMarca.ReadOnly = true;
            txtProveedor.ReadOnly = true;
            txtPrecioCosto.ReadOnly = true;
            txtPrecioVenta.ReadOnly = true;
            txtStock.ReadOnly = true;
            txtStockMinimo.ReadOnly = true;
        }
    }
}
