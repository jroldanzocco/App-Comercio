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
               
                    if(_usuario.Registrar(registro))
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "UsuarioRegistrado", "swal({ title: 'Muy bien!', text: 'Usuario registrado con éxito.', type: 'success', closeOnClickOutside: false, closeOnEsc: false, }).then(function() { window.location.href = 'tu_pagina_de_redireccion'; });", true);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "UsuarioExistente", "swal('Error!', 'El usuario ya se encuentra registrado.', 'error');", true);

            }
            else
            {
                lblPassword.Style["color"] = "red";
                lblPassword.Text = "Las contraseñas deben coincidir"; 
            }
            // Aquí puedes agregar la lógica para el registro.
            // Puedes validar los campos y realizar el proceso de registro según tus necesidades.
        }
    }
}