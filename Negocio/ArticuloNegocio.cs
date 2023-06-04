using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Linq.Expressions;
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
                    if (!(datos.Lector["Id"] is DBNull))
                        aux.Id = (int)datos.Lector["Id"];
                    if (!(datos.Lector["Codigo"] is DBNull))
                        aux.Codigo = (string)datos.Lector["Codigo"];
                    if (!(datos.Lector["Nombre"] is DBNull))
                        aux.Nombre = (string)datos.Lector["Nombre"];
                    if (!(datos.Lector["Descripcion"] is DBNull))
                        aux.Descripcion = (string)datos.Lector["Descripcion"];
                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                    if (!(datos.Lector["Precio"] is DBNull))
                        aux.Precio = (decimal)datos.Lector["Precio"];

                    aux.Marca = new Marca();
                    if (!(datos.Lector["IdMarca"] is DBNull))
                        aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    if (!(datos.Lector["Marca"] is DBNull))
                        aux.Marca.Descripcion = (string)datos.Lector["Marca"];

                    aux.Categoria = new Categoria();
                    if (!(datos.Lector["IdCategoria"] is DBNull))
                        aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    if (!(datos.Lector["Categoria"] is DBNull))
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

        //Agrega los nuevos articulos 
        public void agregar(Articulo nuevoArticulo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio) VALUES (@codigo, @nombre, @descripcion, @idMarca, @idCategoria, @imagenUrl, @precio)");
                datos.setearParametro("@codigo", nuevoArticulo.Codigo);
                datos.setearParametro("@nombre", nuevoArticulo.Nombre);
                datos.setearParametro("@descripcion", nuevoArticulo.Descripcion);
                datos.setearParametro("@idMarca", nuevoArticulo.Marca.Id);
                datos.setearParametro("@idCategoria", nuevoArticulo.Categoria.Id);
                datos.setearParametro("@imagenUrl", nuevoArticulo.ImagenUrl);
                datos.setearParametro("@precio", nuevoArticulo.Precio);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        //Modifica articulo seleccionado
        public void modificar(Articulo articuloSeleccion)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE ARTICULOS SET Codigo = @codigo, Nombre = @nombre, Descripcion = @descripcion, IdMarca = @idMarca, IdCategoria = @idCategoria, ImagenUrl = @imagenUrl, Precio = @precio WHERE Id = @id");
                datos.setearParametro("@codigo", articuloSeleccion.Codigo);
                datos.setearParametro("@nombre", articuloSeleccion.Nombre);
                datos.setearParametro("@descripcion", articuloSeleccion.Descripcion);
                datos.setearParametro("@idMarca", articuloSeleccion.Marca.Id);
                datos.setearParametro("@idCategoria", articuloSeleccion.Categoria.Id);
                datos.setearParametro("@imagenUrl", articuloSeleccion.ImagenUrl);
                datos.setearParametro("@precio", articuloSeleccion.Precio);
                datos.setearParametro("@id", articuloSeleccion.Id);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        //Elimina fisicamente
        public void eliminarFisico(int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("DELETE FROM ARTICULOS WHERE Id = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        //Realiza la busqueda
        public List<Articulo> buscar(string campo, string criterio, string buscar, string rango1, string rango2)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = "SELECT A.Codigo, A.Nombre, A.Descripcion, A.ImagenUrl, A.Precio, A.Id, A.IdCategoria, A.IdMarca, C.Descripcion AS Categoria, M.Descripcion AS Marca FROM ARTICULOS A, CATEGORIAS C, MARCAS M WHERE A.IdCategoria = C.Id AND A.IdMarca = M.Id AND ";

                if (campo == "Precio")
                {
                    switch (criterio)
                    {
                        case "Mayor a":
                            consulta += "Precio > " + buscar;
                            break;
                        case "Menor a":
                            consulta += "Precio < " + buscar;
                            break;
                        default:
                            consulta += "Precio >= '" + rango1 + "' AND Precio <= '" + rango2 + "'";
                            break;

                    }
                }
                else if (campo == "Código")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "Codigo LIKE '" + buscar + "%'";
                            break;
                        case "Termina con":
                            consulta += "Codigo LIKE '%" + buscar + "'";
                            break;
                        default:
                            consulta += "Codigo LIKE '%" + buscar + "%'";
                            break;
                    }
                }
                else if (campo == "Nombre")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "Nombre LIKE '" + buscar + "%'";
                            break;
                        case "Termina con":
                            consulta += "Nombre LIKE '%" + buscar + " '";
                            break;
                        default:
                            consulta += "Nombre LIKE '%" + buscar + "%'";
                            break;
                    }
                }
                else if (campo == "Marca")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "M.Descripcion LIKE '" + buscar + "%'";
                            break;
                        case "Termina con":
                            consulta += "M.Descripcion LIKE '%" + buscar + "'";
                            break;
                        default:
                            consulta += "M.Descripcion LIKE '%" + buscar + "%'";
                            break;
                    }
                }
                else
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "C.Descripcion LIKE '" + buscar + "%'";
                            break;
                        case "Termina con":
                            consulta += "C.Descripcion LIKE '%" + buscar + "'";
                            break;
                        default:
                            consulta += "C.Descripcion LIKE '%" + buscar + "%'";
                            break;
                    }
                }

                //Seteo y Ejecucion de la consulta
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();


                //Maqueto la dgvListaArticulos
                while (datos.Lector.Read())
                {
                    //Creo el objeto tipo Articulo aux y lo instancio
                    Articulo aux = new Articulo();
                    if (!(datos.Lector["Id"] is DBNull))
                        aux.Id = (int)datos.Lector["Id"];
                    if (!(datos.Lector["Codigo"] is DBNull))
                        aux.Codigo = (string)datos.Lector["Codigo"];
                    if (!(datos.Lector["Nombre"] is DBNull))
                        aux.Nombre = (string)datos.Lector["Nombre"];
                    if (!(datos.Lector["Descripcion"] is DBNull))
                        aux.Descripcion = (string)datos.Lector["Descripcion"];
                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                    if (!(datos.Lector["Precio"] is DBNull))
                        aux.Precio = (decimal)datos.Lector["Precio"];

                    aux.Marca = new Marca();
                    if (!(datos.Lector["IdMarca"] is DBNull))
                        aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    if (!(datos.Lector["Marca"] is DBNull))
                        aux.Marca.Descripcion = (string)datos.Lector["Marca"];

                    aux.Categoria = new Categoria();
                    if (!(datos.Lector["IdCategoria"] is DBNull))
                        aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    if (!(datos.Lector["Categoria"] is DBNull))
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
                datos.cerrarConexion();
            }
        }
    }
}
