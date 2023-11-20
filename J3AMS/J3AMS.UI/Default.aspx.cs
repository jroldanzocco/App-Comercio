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
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnLoggin_Click(object sender, EventArgs e)
        {
            Usuario usuario;
            UsuarioNegocio negocio = new UsuarioNegocio();

            try
            {
                usuario = new Usuario(txtNombreUsuario.Text, txtPassword.Value, false);


                if(negocio.Loguear(usuario))
                {
                    Session.Add("usuario", usuario);
                    Response.Redirect("PaginaPrincipal.aspx");
                }
                else
                {
                    Session.Add("error", "usuario o clave incorecto/a");
                    Response.Redirect("Default.aspx");
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
            }
            
        }
    }
}