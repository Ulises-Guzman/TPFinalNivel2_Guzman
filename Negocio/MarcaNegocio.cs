using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class MarcaNegocio
    {
        //Crear Metodo listar() para utilizarlos en los comboBox que necesite
        public List<Marca> listar()
        {
            List<Marca> listaMarca = new List<Marca>();
            AccesoDatos datosMarca = new AccesoDatos();

            try
            {
                datosMarca.setearConsulta("SELECT Id, Descripcion FROM MARCAS");
                datosMarca.ejecutarLectura();

                //Maqueto la listaMarca
                while (datosMarca.Lector.Read())
                {
                    Marca aux = new Marca();
                    aux.Id = (int)datosMarca.Lector["Id"];
                    aux.Descripcion = (string)datosMarca.Lector["Descripcion"];

                    listaMarca.Add(aux);
                }

                return listaMarca;
            }
            catch (Exception ex)
            {

                throw ex;
            }

            finally
            {
                datosMarca.cerrarConexion();
            }
        }
    }
}
