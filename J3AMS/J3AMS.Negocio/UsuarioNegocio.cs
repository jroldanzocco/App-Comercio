using J3.AMS.Common;
using J3AMS.Dominio;
using J3AMS.Dominio.DTOs.Usuario;
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

        public void Registrar(RegisterUsuarioDto registerUserDto)
        {
            if (!CheckExistingUser(registerUserDto))
            {
                if (ValidatorsDA.TryValidateModel(registerUserDto))
                {
                    try
                    {
                        _datos.SetConsulta("INSERT INTO Usuarios(UserName, Password, Email) VALUES(@userName, @password, @email)");
                        _datos.SetParametro("@userName", registerUserDto.UserName);
                        _datos.SetParametro("@password", Helper.HashPassword(registerUserDto.Password));
                        _datos.SetParametro("@email", Helper.HashPassword(registerUserDto.Email));

                        _datos.EjecutarLectura();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        _datos.CerrarConexion();
                    }

                }
            }
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

        public bool CheckExistingUser(RegisterUsuarioDto usuario)
        {
            try
            {
                bool result = false;
                _datos.SetConsulta("Select count('UserName') from Usuarios where UserName = @user");
                _datos.SetParametro("@user", usuario.UserName);

                var count = (int)_datos.EjecutarLecturaEscalar();

                if (count > 0)
                    result = true;

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _datos.CerrarConexion();
            }
        }
    }

}
