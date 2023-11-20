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
    public partial class NuevaCompra : System.Web.UI.Page
    {
        public List<Producto> ListaVenta
        {
            get
            {
                if (Session["ListaVenta"] == null)
                {
                    Session["ListaVenta"] = new List<Producto>();
                }
                return (List<Producto>)Session["ListaVenta"];
            }
            set
            {
                Session["ListaVenta"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Session.Add("error", "No estás logueado");
                Response.Redirect("Default.aspx");
            }

            if (!IsPostBack)
            {
                CargarProductos();
            }
        }
        protected void btnAgregarArticulo_Click(object sender, EventArgs e)
        {
            int idProducto = ObtenerIdProductoSeleccionado(sender);

            if (idProducto > 0)
            {
                ProductoNegocio negocio = new ProductoNegocio();
                //DESARROLLAR
                //Producto producto = negocio.FiltrarPorId(idProducto);

                //if (producto != null)
                //{
                // Agregar el producto a la lista de venta
                //DESARROLLAR

                // Almacenar la lista actualizada en la sesión
                //Session["ListaVenta"] = ListaVenta;

                // Actualizar la interfaz de usuario
                //}
                //else
                //{

                //}
            }
        }

        protected void btnEliminarArticulo_Click(object sender, EventArgs e)
        {
            int idProductoEliminar = ObtenerIdProductoSeleccionado(sender);

            if (idProductoEliminar > 0)
            {
                ListaVenta.RemoveAll(p => p.Id == idProductoEliminar);
            }
        }
        protected void btnVolverAlMenu_Click(object sender, EventArgs e)
        {
            //Restaurarar Stock
            Response.Redirect("PaginaPrincipal.aspx");
        }
        private void CargarProductos()
        {
            try
            {
                ProductoNegocio negocio = new ProductoNegocio();
                List<Producto> listaProductos = negocio.Listar();

                repRepetidor.DataSource = listaProductos;
                repRepetidor.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write($"Error al cargar los productos: {ex.Message}");
            }
        }
        private void ActualizarInterfazUsuario()
        {
            try
            {

            }
            catch (Exception ex)
            {
                Response.Write($"Error al actualizar la interfaz de usuario: {ex.Message}");
            }
        }
        private int ObtenerIdProductoSeleccionado(object sender)
        {
            Button btn = (Button)sender;
            string idProductoStr = btn.CommandArgument;

            if (int.TryParse(idProductoStr, out int idProducto))
            {
                return idProducto;
            }

            return -1;
        }


        private int ObtenerIdProductoAEliminar()
        {
            return 1;
        }
    }
}