using J3AMS.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace J3AMS.Negocio
{
    public class ArticuloNegocio : IABML<Articulo>
    {
        public List<Articulo> Listar()
        {
            List<Articulo> articulos = new List<Articulo>();
            AccesoADatos datos = new AccesoADatos();

            try
            {
                datos.SetConsulta("SELECT \r\n\tA.Codigo, \r\n\tA.Descripcion,\r\n\tA.Tipo,\r\n\tA.Descripcion,\r\n\tA.Tipo,\r\n\tA.Proveedor,\r\n\tA.Stock,\r\n\tM.Id\r\nFrom Articulo A\r\nInner Join Marca M On A.MarcaId = M.Id");
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    int articuloCodigo = (int)datos.Lector["Codigo"];

                    Articulo aux = articulos.FirstOrDefault(a => a.Codigo == articuloCodigo);

                    if (aux == null)
                    {
                        aux = new Articulo
                        {
                            Codigo = (int)datos.Lector["Codigo"],
                            Descripcion = datos.Lector["Descripcion"] as string ?? string.Empty,
                            Tipo = datos.Lector["Tipo"] as string ?? string.Empty,
                            
                            Proveedor = datos.Lector["Proveedor"] as string ?? string.Empty,
                            Stock = (int)datos.Lector["Stock"]
                        };

                        articulos.Add(aux);
                    }
                }

                return articulos.OrderByDescending(a => a.Codigo).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
    }
}
