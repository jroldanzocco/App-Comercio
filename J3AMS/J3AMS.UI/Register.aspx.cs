using J3AMS.Dominio.DTOs.Usuario;
using J3AMS.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace J3AMS.UI
{
    public partial class Register : System.Web.UI.Page
    {
        UsuarioNegocio _usuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            _usuario = new UsuarioNegocio();
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            // Aquí puedes acceder a los campos del formulario usando las propiedades .Text de los controles de servidor.
            string nombreUsuario = txtNombreUsuario.Text;
            string password = txtPassword.Text;
            string repetirPassword = txtRepetirPassword.Text;
            string email = txtEmail.Text;

            var registro = new RegisterUsuarioDto()
            {
                UserName = nombreUsuario,
                Password = password,
                Email = email
            };

            if(password == repetirPassword)
            {
                _usuario.Registrar(registro);
                
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ContraseñasNoCoinciden", "swal('Error', 'Las contraseñas no coinciden.', 'error');", true);
            }
            // Aquí puedes agregar la lógica para el registro.
            // Puedes validar los campos y realizar el proceso de registro según tus necesidades.
        }
    }
}