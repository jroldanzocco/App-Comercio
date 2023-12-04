using J3.AMS.Common;
using J3AMS.Dominio;
using J3AMS.Negocio;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace J3AMS.UI
{
    public partial class AltaProveedor : System.Web.UI.Page
    {
        private ProveedorNegocio _proveedores;
        private CategoriaIvaNegocio _categoriaIva;
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
            _proveedores = new ProveedorNegocio();
            _categoriaIva = new CategoriaIvaNegocio();

            if (!IsPostBack)
            {
                List<CategoriaIva> categorias = _categoriaIva.Listar();

                ddlCategoriaIva.DataSource = categorias;
                ddlCategoriaIva.DataValueField = "Id";
                ddlCategoriaIva.DataTextField = "Descripcion";
                ddlCategoriaIva.DataBind();
                ddlCategoriaIva.Items.Insert(0, new ListItem("-- Seleccione IVA --", string.Empty));

                string id = Request.QueryString["id"] != null ? Request.QueryString["id"] : "";
                
                if (id != "")
                {
                    int.TryParse(id, out int idVal);
                    Proveedor aux = _proveedores.Get(idVal);

                    txtRazonSocial.Text = aux.RazonSocial;
                    txtNombre.Text = aux.NombreFantasia;
                    txtCuit.Text = aux.CUIT;
                    txtDomicilio.Text = aux.Domicilio;
                    txtTelefono.Text = aux.Telefono;
                    txtCelular.Text = aux.Celular;
                    txtEmail.Text = aux.Email;
                    txtPlazo.Text = aux.PlazoPago.ToString();
                    ddlCategoriaIva.SelectedValue = aux.CategoriaIva.Id.ToString();
                }

               
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    btnAgregarProveedor.Text = "Editar";
                }
                else
                {
                    btnAgregarProveedor.Text = "Agregar";
                }
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("BuscarProveedor.aspx");
        }

        protected void btnAgregarProveedor_Click(object sender, EventArgs e)
        {
            Proveedor aux = new Proveedor();

            if(ddlCategoriaIva.SelectedValue != "")
            {
                CategoriaIva iva = new CategoriaIva();
                iva.Id = byte.Parse(ddlCategoriaIva.SelectedValue);
                aux.IdCategoriaIva = iva.Id;
                aux.CategoriaIva = iva;
            }

            aux.RazonSocial = txtRazonSocial.Text;
            aux.NombreFantasia = txtNombre.Text;
            aux.CUIT = txtCuit.Text;
            aux.Domicilio = txtDomicilio.Text;
            aux.Telefono = txtTelefono.Text;
            aux.Celular = txtCelular.Text;
            aux.Email = txtEmail.Text;
            byte.TryParse(txtPlazo.Text, out byte PlazoValidator);
            aux.PlazoPago = PlazoValidator;

            string id = Request.QueryString["id"];

            if(ValidatorsDA.TryValidateModel(aux))
            {

            }

            if (id != null)
            {
                aux.Id = int.Parse(id);
                _proveedores.Update(aux);
            }
            else
                _proveedores.Add(aux);

            Response.Redirect("BuscarProveedor.aspx");
        }
    }
}