using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;

namespace Presentacion
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        //Creo atributo para contener la lista
        private List<Articulo> listaArticulo;


        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            //Cargo los datos en el dvgListaArticulo, en el frmPrincial, a travez del Metodo cargar()
            cargar();
        }

        //Metodo para realizar la carga del dgvListaArticulos
        private void cargar()
        {
            ArticuloNegocio negocio = new ArticuloNegocio();

            try
            {   
                listaArticulo = negocio.listar();
                dgvListaArticulos.DataSource = listaArticulo;
                ocultarColumnas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //Metodo para ocultar columnas
        private void ocultarColumnas()
        {
            dgvListaArticulos.Columns["Id"].Visible = false;
            dgvListaArticulos.Columns["ImagenUrl"].Visible = false;
        }
    }
}
