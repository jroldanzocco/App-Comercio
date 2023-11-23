using J3.AMS.Common;
using J3AMS.Dominio;
using System;

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
                _datos.SetConsulta("SELECT Id, IdRol FROM Usuarios WHERE UserName = @user AND Password = @pass");

                _datos.SetParametro("@user", usuario.UserName);
                _datos.SetParametro("@pass", Helper.HashPassword(usuario.Password));
                _datos.EjecutarLectura();
                while (_datos.Lector.Read())
                {
                    usuario.Id = (int)_datos.Lector["Id"];
                    usuario.UserRole = (byte)_datos.Lector["IdRol"] == 1 ? UserRole.ADMIN : UserRole.NORMAL;
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
