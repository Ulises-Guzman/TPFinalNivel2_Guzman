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

                pcbImagenArticulo.Load("https://avatars.mds.yandex.net/i?id=20d89bb5ee49b86f56972575dc36fb58691babcb-9182408-images-thumbs&n=13"); ;
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
                //Investigar Actualizar el dgv desde aca
                //...
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            
        }
    } 
}
