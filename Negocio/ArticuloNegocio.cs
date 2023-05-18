using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
 
namespace Negocio
{   
    //Clase que contiene la maquetacion de  los datos y llamados a Funciones/Metodos
    public class ArticuloNegocio
    {
        //Creo Metodo listar()
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT A.Codigo, A.Nombre, A.Descripcion, A.ImagenUrl, A.Precio, C.Descripcion AS Categoria, M.Descripcion AS Marca FROM ARTICULOS A, CATEGORIAS C, MARCAS M WHERE A.IdCategoria = C.Id AND A.IdMarca = M.Id");
                datos.ejecutarLectura();

                //Maqueto la lista
                while (datos.Lector.Read())
                {
                    //Creo el objeto tipo Articulo aux y lo instancio
                    Articulo aux = new Articulo();
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                    aux.Precio = (float)datos.Lector["Precio"];

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }

            finally
            {
                //Cierro la conexion
                datos.cerrarConexion();
            }
        }
    }
}
