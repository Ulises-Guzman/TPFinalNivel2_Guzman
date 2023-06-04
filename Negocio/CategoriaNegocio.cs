using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class CategoriaNegocio
    {
        //Crear Metodo listar() para utilizarlos en los comboBox que necesite
        public List<Categoria> listar()
        {
            List<Categoria> listaCategoria = new List<Categoria>();
            AccesoDatos datosCategoria = new AccesoDatos();

            try
            {
                datosCategoria.setearConsulta("SELECT Id, Descripcion FROM CATEGORIAS");
                datosCategoria.ejecutarLectura();

                while (datosCategoria.Lector.Read())
                {
                    Categoria aux = new Categoria();
                    if (!(datosCategoria.Lector["Id"] is DBNull))
                        aux.Id = (int)datosCategoria.Lector["Id"];
                    if (!(datosCategoria.Lector["Descripcion"] is DBNull))
                        aux.Descripcion = (string)datosCategoria.Lector["Descripcion"];

                    listaCategoria.Add(aux);
                }

                return listaCategoria;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datosCategoria.cerrarConexion();
            }
        }
    }
}
