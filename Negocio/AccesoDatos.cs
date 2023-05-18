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
        //Declaro los atributos para realizar la conexion de manera centralizada
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
            conexion = new SqlConnection("server=.\\SQLEXPRESS; database=CATALOGO_DB; integrated segurity=true");
            comando = new SqlCommand();
        }

        //Seteo la Consulta
        public void setearConsulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }

        //Ejecuto la Lectura
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

        //

        //Crear la lectura para los datos de las tablas Marca y Categoria


        //Cerrar la Conexion
        public void cerrarConexion()
        {
            if (lector != null)
                conexion.Close();
            conexion.Close();
        }
    }
}
