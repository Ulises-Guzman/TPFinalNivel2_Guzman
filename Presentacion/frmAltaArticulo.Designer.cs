namespace Presentacion
{
    partial class frmAltaArticulo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.txtImagenUrl = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.lblImagenUrl = new System.Windows.Forms.Label();
            this.pcbImagenArticulo = new System.Windows.Forms.PictureBox();
            this.cmbMarca = new System.Windows.Forms.ComboBox();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblMarca = new System.Windows.Forms.Label();
            this.lblCategoria = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pcbImagenArticulo)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(23, 43);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(176, 20);
            this.txtCodigo.TabIndex = 1;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(23, 98);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(176, 20);
            this.txtNombre.TabIndex = 3;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(23, 275);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(435, 80);
            this.txtDescripcion.TabIndex = 11;
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(23, 398);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(176, 20);
            this.txtPrecio.TabIndex = 13;
            // 
            // txtImagenUrl
            // 
            this.txtImagenUrl.Location = new System.Drawing.Point(247, 210);
            this.txtImagenUrl.Name = "txtImagenUrl";
            this.txtImagenUrl.Size = new System.Drawing.Size(166, 20);
            this.txtImagenUrl.TabIndex = 9;
            this.txtImagenUrl.Leave += new System.EventHandler(this.txtImagenUrl_Leave);
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(20, 19);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(43, 13);
            this.lblCodigo.TabIndex = 0;
            this.lblCodigo.Text = "Código:";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(20, 74);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(47, 13);
            this.lblNombre.TabIndex = 2;
            this.lblNombre.Text = "Nombre:";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(20, 251);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(66, 13);
            this.lblDescripcion.TabIndex = 10;
            this.lblDescripcion.Text = "Descripción:";
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Location = new System.Drawing.Point(20, 374);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(40, 13);
            this.lblPrecio.TabIndex = 12;
            this.lblPrecio.Text = "Precio:";
            // 
            // lblImagenUrl
            // 
            this.lblImagenUrl.AutoSize = true;
            this.lblImagenUrl.Location = new System.Drawing.Point(244, 194);
            this.lblImagenUrl.Name = "lblImagenUrl";
            this.lblImagenUrl.Size = new System.Drawing.Size(70, 13);
            this.lblImagenUrl.TabIndex = 8;
            this.lblImagenUrl.Text = "URL Imagen:";
            // 
            // pcbImagenArticulo
            // 
            this.pcbImagenArticulo.Location = new System.Drawing.Point(247, 43);
            this.pcbImagenArticulo.Name = "pcbImagenArticulo";
            this.pcbImagenArticulo.Size = new System.Drawing.Size(211, 131);
            this.pcbImagenArticulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbImagenArticulo.TabIndex = 10;
            this.pcbImagenArticulo.TabStop = false;
            // 
            // cmbMarca
            // 
            this.cmbMarca.FormattingEnabled = true;
            this.cmbMarca.Location = new System.Drawing.Point(23, 153);
            this.cmbMarca.Name = "cmbMarca";
            this.cmbMarca.Size = new System.Drawing.Size(176, 21);
            this.cmbMarca.TabIndex = 5;
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location = new System.Drawing.Point(23, 209);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(176, 21);
            this.cmbCategoria.TabIndex = 7;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(141, 439);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 14;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(248, 442);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 15;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.Location = new System.Drawing.Point(23, 129);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(40, 13);
            this.lblMarca.TabIndex = 4;
            this.lblMarca.Text = "Marca:";
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Location = new System.Drawing.Point(23, 185);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(57, 13);
            this.lblCategoria.TabIndex = 6;
            this.lblCategoria.Text = "Categoría:";
            // 
            // frmAltaArticulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 487);
            this.Controls.Add(this.lblCategoria);
            this.Controls.Add(this.lblMarca);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.cmbCategoria);
            this.Controls.Add(this.cmbMarca);
            this.Controls.Add(this.pcbImagenArticulo);
            this.Controls.Add(this.lblImagenUrl);
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.txtImagenUrl);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtCodigo);
            this.Name = "frmAltaArticulo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.frmAltaArticulo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pcbImagenArticulo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.TextBox txtImagenUrl;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Label lblImagenUrl;
        private System.Windows.Forms.PictureBox pcbImagenArticulo;
        private System.Windows.Forms.ComboBox cmbMarca;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.Label lblCategoria;
    }
}