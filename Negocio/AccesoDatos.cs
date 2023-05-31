using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Agrego el SqlClient
using System.Data.SqlClient;

namespace Negocio
{
    public class AccesoDatos
    {
        //Atributos para realizar la conexion de manera centralizada
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        //Propiedad del SqlDataReader para acceder desde afuera
        public SqlDataReader Lector
        {
            get { return lector; }
        }

        //Constructor SqlConnection y SqlCommand
        public AccesoDatos()
        {
            conexion = new SqlConnection("server=.\\SQLEXPRESS; database=CATALOGO_DB; integrated security=true");
            comando = new SqlCommand();
        }

        //Seteo de la Consulta
        public void setearConsulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }

        //Ejecucion de la Lectura
        public void ejecutarLectura()
        {
            comando.Connection = conexion;

            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //Cierre de  la Conexion
        public void cerrarConexion()
        {
            if (lector != null)
                conexion.Close();
            conexion.Close();
        }

        //Setea los Parametros para realizar la consulta SQL de los nuevos articulos
        public void setearParametro(string nombre, object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor);
        }

        //Ejecuta la consulta SQL para agregar nuevos articulos
        public void ejecutarAccion()
        {
            comando.Connection = conexion;

            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
