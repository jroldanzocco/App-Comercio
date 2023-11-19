using J3AMS.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Threading;

namespace J3AMS.Negocio
{
    public class UsuarioNegocio
    {
        private readonly AccesoADatos _datos;

        public UsuarioNegocio()
        {
            _datos = new AccesoADatos();
        }

        public bool Loguear(Usuario usuario)
        {
            try
            {
                _datos.SetConsulta("SELECT id, NombreUsuario, Contraseña FROM Usuarios WHERE NombreUsuario = @user AND Contraseña = @pass");

                _datos.SetParametro("@user", usuario.NombreUsuario);
                _datos.SetParametro("@pass", usuario.Contrasenia);

                _datos.EjecutarLectura();

                while (_datos.Lector.Read())
                {
                    usuario.Id = (int)_datos.Lector["Id"];
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _datos.CerrarConexion();
            }
        }
    }

}
