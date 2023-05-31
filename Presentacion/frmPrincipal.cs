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
using static System.Net.Mime.MediaTypeNames;

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
                cargarImagen(listaArticulo[0].ImagenUrl);
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
            dgvListaArticulos.Columns["Descripcion"].Visible = false;
            dgvListaArticulos.Columns["Precio"].Visible = false;
        }

        //Metodo para cargar las imagenes
        private void cargarImagen(string imagen)
        {
            try
            {
                pcbImagenArticulo.Load(imagen);
            }
            catch (Exception)
            {

                pcbImagenArticulo.Load("https://avatars.mds.yandex.net/i?id=20d89bb5ee49b86f56972575dc36fb58691babcb-9182408-images-thumbs&n=13");
            }
        }

        private void dgvListaArticulos_SelectionChanged(object sender, EventArgs e)
        {
            //Carga imagen de la fila y en el cambio de fila con la validacion de null
            //Carga los detalles de articulo
            if (dgvListaArticulos.CurrentRow != null)
            {
                Articulo seleccion = (Articulo)dgvListaArticulos.CurrentRow.DataBoundItem;
                cargarImagen(seleccion.ImagenUrl);
                cargarDetalles();
            }
        }

        private void cargarDetalles()
        {
            Articulo detalles = (Articulo)dgvListaArticulos.CurrentRow.DataBoundItem;
            string descripcion = detalles.Descripcion;
            double precio = (double)detalles.Precio;

            txtDetalles.Text = "Descripción:" + Environment.NewLine;
            txtDetalles.Text += descripcion + Environment.NewLine;
            txtDetalles.Text += Environment.NewLine;
            txtDetalles.Text += "Precio:";
            txtDetalles.Text += " $" + precio;
        }

        //Metodo para abrir el frmAltaArticulo
        private void btnAgregar_Click(object sender, EventArgs e)
        {   

            frmAltaArticulo alta = new frmAltaArticulo();
            alta.Text = "Agregar Artículo";
            alta.ShowDialog();

            //llamo al Metodo cargar(), para actualizar la grilla cuando agrego un nuevo articulo...
            cargar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {   
            //Asigno la fila del articulo seleccionado
            Articulo seleccionado;
            seleccionado = (Articulo)dgvListaArticulos.CurrentRow.DataBoundItem;

            //Instancio el frmAltaArticulo con parametro objeto Articulo seleccionado
            frmAltaArticulo modificar = new frmAltaArticulo(seleccionado);
            modificar.Text = "Modificar Artículo";
            modificar.ShowDialog();

            cargar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
          
            ArticuloNegocio negocio = new ArticuloNegocio();
            Articulo seleccionado;

            try
            {
                DialogResult respuesta = MessageBox.Show("¿Está seguro de Eliminar el Registro?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes)
                {
                    seleccionado = (Articulo)dgvListaArticulos.CurrentRow.DataBoundItem;
                    negocio.eliminarFisico(seleccionado.Id);
                    cargar();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
    }
}
