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
using System.Security.Cryptography;
using System.CodeDom;

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
                _datos.SetParametro("@pass", HashPassword(usuario.Password));
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

        private string HashPassword(string password)
        {

            // Choose the hash algorithm (SHA-256 or SHA-512)
            using (var sha256 = SHA256.Create())
            {
                // Convert the combined password string to a byte array
                byte[] bytes = Encoding.UTF8.GetBytes(password);

                // Compute the hash value of the byte array
                byte[] hash = sha256.ComputeHash(bytes);

                // Convert the byte array to a hexadecimal string
                StringBuilder result = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    result.Append(hash[i].ToString("x2"));
                }

                return result.ToString();
            }
        }
    }

}
