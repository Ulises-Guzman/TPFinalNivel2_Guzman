using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmAltaArticulo : Form
    {
        //Atributo en null para utilizarlo como bandera
        private Articulo articulo = null;

        public frmAltaArticulo()
        {
            InitializeComponent();
        }

        //Duplico constructor para recibir articulo selecionado
        public frmAltaArticulo(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;

        }

        private void frmAltaArticulo_Load(object sender, EventArgs e)
        {   
            //Seteo tooltips
            ToolTip toolTip1 = new ToolTip();

            toolTip1.AutoPopDelay = 3000;
            toolTip1.InitialDelay = 50;
            toolTip1.ReshowDelay = 500;

            toolTip1.SetToolTip(this.txtPrecio, "Número decimal con 'coma' ");

            MarcaNegocio marcaNegocio = new MarcaNegocio();
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();

            try
            {   //Precarga los ComboBox
                cmbMarca.DataSource = marcaNegocio.listar();
                cmbMarca.ValueMember = "Id";
                cmbMarca.DisplayMember = "Descripcion";

                cmbCategoria.DataSource = categoriaNegocio.listar();
                cmbCategoria.ValueMember = "Id";
                cmbCategoria.DisplayMember = "Descripcion";
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

            try
            {   //Carga los TextBox y ComboBox cuando se acciona el boton "Modificar"
                if (articulo != null)
                {
                    txtCodigo.Text = articulo.Codigo;
                    txtNombre.Text = articulo.Nombre;
                    cmbMarca.SelectedValue = articulo.Marca.Id;
                    cmbCategoria.SelectedValue = articulo.Categoria.Id;
                    txtImagenUrl.Text = articulo.ImagenUrl;
                    txtDescripcion.Text = articulo.Descripcion;
                    txtPrecio.Text = articulo.Precio.ToString();
                    cargarImagen(articulo.ImagenUrl);
                }
            }
            catch (Exception ex) 
            {

                MessageBox.Show(ex.ToString());
            }
        }

        //Metodo para cargar la imagen en el PictureBox del frmAltaArticulo
        private void cargarImagen(string imagen)
        {
            try
            {
                pcbImagenArticulo.Load(imagen);
            }
            catch (Exception)
            {

                pcbImagenArticulo.Load("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT1wwaPU6CL-aQEa3w7xm3lQMgyI6ld2pnyeLeprDmWffeIvmUQ2rprHT4PuU0hQ9LzEUg&usqp=CAU"); ;
            }
        }

        //Llamo al Metodo cargarImagen cuando ocurre el evento Leave
        private void txtImagenUrl_Leave(object sender, EventArgs e)
        {
            cargarImagen(txtImagenUrl.Text);
        }

        //Cierra el frmAltaArticulo
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();

            try
            {
                if (validarAceptar())
                    return;

                //Capturo los valores de las TextBox y ComboBox, utilizado el objeto tipo Articulo
                if (articulo == null)
                    articulo = new Articulo();

                //Asigno los valores a Articulo articulo
                articulo.Codigo = txtCodigo.Text;
                articulo.Nombre = txtNombre.Text;
                articulo.Marca = (Marca)cmbMarca.SelectedItem;
                articulo.Categoria = (Categoria)cmbCategoria.SelectedItem;
                articulo.ImagenUrl = txtImagenUrl.Text;
                articulo.Descripcion = txtDescripcion.Text;
                articulo.Precio = decimal.Parse(txtPrecio.Text);

                //Llamo a los Metodos agragar() y modificar()
                if (articulo.Id != 0)
                {
                    negocio.modificar(articulo);
                    MessageBox.Show("Artículo modificado correctamente");
                }
                else
                {
                    negocio.agregar(articulo);
                    MessageBox.Show("Artículo nuevo agregado correctamente");
                }

                Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            
        }

        //Validar Aceptar
        private bool validarAceptar()
        {
            bool ban1 = false;
            bool ban2 = false;

            List<TextBox> lista1 = new List<TextBox>();
            lista1.Add(txtCodigo);
            lista1.Add(txtNombre);
            lista1.Add(txtImagenUrl);
            lista1.Add(txtDescripcion);
            lista1.Add(txtPrecio);
            //Cambio de Color
            foreach (var item in lista1)
            {
                if (item.Text == "")
                {
                    item.BackColor = Color.Tomato;
                }
                else
                    item.BackColor = Color.White;
            }

            //Llamo Validacion
            

            if (!(soloNumeros(txtPrecio.Text)))
            {
                MessageBox.Show("Ingresar sólo números");
                return true;
            }

            List<ComboBox> lista2 = new List<ComboBox>();
            lista2.Add(cmbMarca);
            lista2.Add(cmbCategoria);
            //Cambio de Color
            foreach (var item in lista2)
            {
                if (item.SelectedIndex < 0)
                {
                    item.BackColor = Color.Tomato;
                }
                else
                    item.BackColor = Color.White;
            }

            //banderas
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

        //Valida solonumeros
        public bool soloNumeros(string cadena)
        {
            foreach (char caracter in cadena)
            {
                if (!(char.IsDigit(caracter) || char.IsPunctuation(caracter)))
                    return false;
            }
            return true;
        }
    } 
}
