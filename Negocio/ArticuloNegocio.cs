using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
 
namespace Negocio
{   
    //Clase que contiene la maquetacion de  los datos y llamados a Funciones/Metodos
    public class ArticuloNegocio
    {
        

        //Metodo listar()
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT A.Codigo, A.Nombre, A.Descripcion, A.ImagenUrl, A.Precio, A.Id, A.IdCategoria, A.IdMarca, C.Descripcion AS Categoria, M.Descripcion AS Marca FROM ARTICULOS A, CATEGORIAS C, MARCAS M WHERE A.IdCategoria = C.Id AND A.IdMarca = M.Id");
                datos.ejecutarLectura();


                //Maquetado de la lista
                while (datos.Lector.Read())
                {
                    //Creo el objeto tipo Articulo aux y lo instancio
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                    aux.Precio = (decimal)datos.Lector["Precio"];

                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)datos.Lector["Id"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];

                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)datos.Lector["Id"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    

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
