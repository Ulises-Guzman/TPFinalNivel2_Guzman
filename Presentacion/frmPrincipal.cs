using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Configuration;
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
            //Carga los datos del cmbCampo
            cmbCampo.Items.Add("Código");
            cmbCampo.Items.Add("Nombre");
            cmbCampo.Items.Add("Marca");
            cmbCampo.Items.Add("Categoría");
            cmbCampo.Items.Add("Precio");

            //Seteo tooltips
            ToolTip toolTip1 = new ToolTip();
            ToolTip toolTip2 = new ToolTip();

            toolTip1.AutoPopDelay = 3000;
            toolTip1.InitialDelay = 50;
            toolTip1.ReshowDelay = 500;

            toolTip2.AutoPopDelay = 3000;
            toolTip2.InitialDelay = 50;
            toolTip2.ReshowDelay = 500;

            toolTip1.SetToolTip(this.txtRango1, "Número decimal con 'coma' ");
            toolTip2.SetToolTip(this.txtRango2, "Número decimal con 'coma' ");

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

                pcbImagenArticulo.Load("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT1wwaPU6CL-aQEa3w7xm3lQMgyI6ld2pnyeLeprDmWffeIvmUQ2rprHT4PuU0hQ9LzEUg&usqp=CAU");
            }
        }

        //Carga la imagen del articulo cuando la selecion cambia
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

        //Pasa los datos a la caja de Detalles
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

        //Metodo para abrir el frmAltaArticulo "Agregar"
        private void btnAgregar_Click(object sender, EventArgs e)
        {   

            frmAltaArticulo alta = new frmAltaArticulo();
            alta.Text = "Agregar Artículo";
            alta.ShowDialog();

            //llamo al Metodo cargar(), para actualizar la grilla cuando agrego un nuevo articulo...
            cargar();
        }

        //Metodo para abrir el frmAltaArticulo "Modificar"
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

        //Metodo para cargar los criterios segun la seleccion del cmbCampo
        private void cmbCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcion = cmbCampo.SelectedItem.ToString();


            if (opcion == "Precio")
            {
                cmbCriterio.Items.Clear();
                cmbCriterio.ResetText();
                cmbCriterio.Items.Add("Mayor a");
                cmbCriterio.Items.Add("Menor a");
                ckbRango.Enabled = true;
                txtBuscar.Text = "";
            }
            else
            {
                cmbCriterio.Items.Clear();
                cmbCriterio.ResetText();
                cmbCriterio.Items.Add("Comienza con");
                cmbCriterio.Items.Add("Termina con");
                cmbCriterio.Items.Add("Contiene");

            }
        }

        //Metodo Busqueda
        private void btnBuscar_Click(object sender, EventArgs e)
        {   
            

            ArticuloNegocio negocio = new ArticuloNegocio();

            try
            {
                //Llamo a la funcion que valida
                if (validarBusqueda())
                    return;
               
                string campo = cmbCampo.SelectedItem.ToString();
                string criterio = cmbCriterio.SelectedItem.ToString();
                string buscar = txtBuscar.Text;
                string rango1 = txtRango1.Text;
                string rango2 = txtRango2.Text;

                dgvListaArticulos.DataSource = negocio.buscar(campo, criterio, buscar, rango1, rango2);

                if (ckbRango.Checked)
                    ckbRango.Checked = false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Valida las Busquedas
        private bool validarBusqueda()
        {
            bool ban1 = false;
            bool ban2 = false;

            List<ComboBox> lista1 = new List<ComboBox>();
            lista1.Add(cmbCampo);
            lista1.Add(cmbCriterio);
            //Cambio de color
            foreach (var item in lista1)
            {
                if (item.SelectedIndex < 0)
                {
                    item.BackColor = Color.Tomato;
                }
                else
                    item.BackColor = Color.White;
            }

            List<TextBox> lista2 = new List<TextBox>();
            lista2.Add(txtBuscar);
            lista2.Add(txtRango1);
            lista2.Add(txtRango2);
            //Cambio de Color
            foreach (var item in lista2)
            {
                if (item.Text == "" && item.Enabled)
                {
                    item.BackColor = Color.Tomato;
                }
                else if (item.Enabled)
                    item.BackColor = Color.White;

            }

            //Llamo Validacion
            if (cmbCampo.Text == "Precio")
            {
                if (!(soloNumeros(txtBuscar.Text)))
                {
                    MessageBox.Show("Ingresar sólo números");
                    return true;
                }

                if (!(soloNumeros(txtRango1.Text)))
                {
                    MessageBox.Show("Ingresar sólo números");
                    return true;
                }

                if (!(soloNumeros(txtRango2.Text)))
                {
                    MessageBox.Show("Ingresar sólo números");
                    return true;
                }
            }

            foreach (var item in lista1)
            {
                if (item.BackColor == Color.Tomato)
                    ban1 = true;
            }

            foreach (var item in lista2)
            {
                if (item.BackColor == Color.Tomato)
                    ban2 = true;
            }

            if (ban1 || ban2)
            {
                MessageBox.Show("Por favor Complete todas las Casillas");
                return true;
            }
            else
                return false; 
        }

        //Metodo cuando se selecciona el CheckBox
        private void ckbRango_CheckedChanged(object sender, EventArgs e)
        {
            {
                if (cmbCampo.Text == "Precio")
                {
                    if (ckbRango.Checked)
                    {
                        
                        
                        txtRango1.Enabled = true;
                        txtRango2.Enabled = true;
                        cmbCriterio.Items.Add("Entre");
                        cmbCriterio.SelectedIndex = 2;
                        cmbCriterio.Enabled = false;
                        cmbCampo.Enabled = false;
                        txtBuscar.Text = "";
                        txtBuscar.BackColor = Color.White;
                        txtBuscar.Enabled = false;
                    }
                    else
                    {
                        txtBuscar.Enabled = true;
                        txtRango1.Enabled = false;
                        txtRango2.Enabled = false;
                        cmbCriterio.Items.RemoveAt(2);
                        cmbCriterio.Enabled = true;
                        cmbCampo.Enabled = true;
                    }
                }
            }
        }


        //Valida, en el txtBuscar, que sean solo numeros cunado esta el cmbCampo = 0 y cmbCriterio en algunas de sus opciones
        public bool soloNumeros(string cadena)
        {
            foreach (char caracter in cadena)
            {
                if (!(char.IsDigit(caracter) || char.IsPunctuation(caracter)))
                    return false;
            }
            return true;
        }

        //Actualiza la Grilla
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            cargar();
        }
    }
}
