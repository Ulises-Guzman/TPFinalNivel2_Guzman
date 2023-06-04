namespace Presentacion
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvListaArticulos = new System.Windows.Forms.DataGridView();
            this.pcbImagenArticulo = new System.Windows.Forms.PictureBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.lblListaArticulos = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.txtDetalles = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.cmbCampo = new System.Windows.Forms.ComboBox();
            this.cmbCriterio = new System.Windows.Forms.ComboBox();
            this.lblCampo = new System.Windows.Forms.Label();
            this.lblCriterio = new System.Windows.Forms.Label();
            this.txtRango1 = new System.Windows.Forms.TextBox();
            this.txtRango2 = new System.Windows.Forms.TextBox();
            this.ckbRango = new System.Windows.Forms.CheckBox();
            this.lblBusqueda = new System.Windows.Forms.Label();
            this.lblDetalles = new System.Windows.Forms.Label();
            this.btnActualizar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaArticulos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbImagenArticulo)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvListaArticulos
            // 
            this.dgvListaArticulos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvListaArticulos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvListaArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaArticulos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvListaArticulos.Location = new System.Drawing.Point(15, 54);
            this.dgvListaArticulos.MultiSelect = false;
            this.dgvListaArticulos.Name = "dgvListaArticulos";
            this.dgvListaArticulos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaArticulos.Size = new System.Drawing.Size(459, 216);
            this.dgvListaArticulos.TabIndex = 1;
            this.dgvListaArticulos.SelectionChanged += new System.EventHandler(this.dgvListaArticulos_SelectionChanged);
            // 
            // pcbImagenArticulo
            // 
            this.pcbImagenArticulo.Location = new System.Drawing.Point(538, 54);
            this.pcbImagenArticulo.Name = "pcbImagenArticulo";
            this.pcbImagenArticulo.Size = new System.Drawing.Size(239, 216);
            this.pcbImagenArticulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbImagenArticulo.TabIndex = 1;
            this.pcbImagenArticulo.TabStop = false;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(14, 276);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 2;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(112, 276);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 23);
            this.btnModificar.TabIndex = 3;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(399, 276);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 5;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // lblListaArticulos
            // 
            this.lblListaArticulos.AutoSize = true;
            this.lblListaArticulos.Location = new System.Drawing.Point(12, 36);
            this.lblListaArticulos.Name = "lblListaArticulos";
            this.lblListaArticulos.Size = new System.Drawing.Size(90, 13);
            this.lblListaArticulos.TabIndex = 0;
            this.lblListaArticulos.Text = "Lista de Articulos:";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(337, 339);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(137, 20);
            this.txtBuscar.TabIndex = 11;
            // 
            // txtDetalles
            // 
            this.txtDetalles.Location = new System.Drawing.Point(538, 339);
            this.txtDetalles.Multiline = true;
            this.txtDetalles.Name = "txtDetalles";
            this.txtDetalles.Size = new System.Drawing.Size(239, 108);
            this.txtDetalles.TabIndex = 17;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(399, 398);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 15;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // cmbCampo
            // 
            this.cmbCampo.FormattingEnabled = true;
            this.cmbCampo.Location = new System.Drawing.Point(15, 339);
            this.cmbCampo.Name = "cmbCampo";
            this.cmbCampo.Size = new System.Drawing.Size(121, 21);
            this.cmbCampo.TabIndex = 7;
            this.cmbCampo.SelectedIndexChanged += new System.EventHandler(this.cmbCampo_SelectedIndexChanged);
            // 
            // cmbCriterio
            // 
            this.cmbCriterio.FormattingEnabled = true;
            this.cmbCriterio.Location = new System.Drawing.Point(152, 339);
            this.cmbCriterio.Name = "cmbCriterio";
            this.cmbCriterio.Size = new System.Drawing.Size(172, 21);
            this.cmbCriterio.TabIndex = 9;
            // 
            // lblCampo
            // 
            this.lblCampo.AutoSize = true;
            this.lblCampo.Location = new System.Drawing.Point(14, 320);
            this.lblCampo.Name = "lblCampo";
            this.lblCampo.Size = new System.Drawing.Size(43, 13);
            this.lblCampo.TabIndex = 6;
            this.lblCampo.Text = "Campo:";
            // 
            // lblCriterio
            // 
            this.lblCriterio.AutoSize = true;
            this.lblCriterio.Location = new System.Drawing.Point(151, 321);
            this.lblCriterio.Name = "lblCriterio";
            this.lblCriterio.Size = new System.Drawing.Size(42, 13);
            this.lblCriterio.TabIndex = 8;
            this.lblCriterio.Text = "Criterio:";
            // 
            // txtRango1
            // 
            this.txtRango1.Enabled = false;
            this.txtRango1.Location = new System.Drawing.Point(152, 398);
            this.txtRango1.Name = "txtRango1";
            this.txtRango1.Size = new System.Drawing.Size(80, 20);
            this.txtRango1.TabIndex = 13;
            // 
            // txtRango2
            // 
            this.txtRango2.Enabled = false;
            this.txtRango2.Location = new System.Drawing.Point(245, 398);
            this.txtRango2.Name = "txtRango2";
            this.txtRango2.Size = new System.Drawing.Size(80, 20);
            this.txtRango2.TabIndex = 14;
            // 
            // ckbRango
            // 
            this.ckbRango.AutoSize = true;
            this.ckbRango.Enabled = false;
            this.ckbRango.Location = new System.Drawing.Point(152, 377);
            this.ckbRango.Name = "ckbRango";
            this.ckbRango.Size = new System.Drawing.Size(54, 17);
            this.ckbRango.TabIndex = 12;
            this.ckbRango.Text = "Entre:";
            this.ckbRango.UseVisualStyleBackColor = true;
            this.ckbRango.CheckedChanged += new System.EventHandler(this.ckbRango_CheckedChanged);
            // 
            // lblBusqueda
            // 
            this.lblBusqueda.AutoSize = true;
            this.lblBusqueda.Location = new System.Drawing.Point(334, 322);
            this.lblBusqueda.Name = "lblBusqueda";
            this.lblBusqueda.Size = new System.Drawing.Size(58, 13);
            this.lblBusqueda.TabIndex = 10;
            this.lblBusqueda.Text = "Búsqueda:";
            // 
            // lblDetalles
            // 
            this.lblDetalles.AutoSize = true;
            this.lblDetalles.Location = new System.Drawing.Point(535, 321);
            this.lblDetalles.Name = "lblDetalles";
            this.lblDetalles.Size = new System.Drawing.Size(48, 13);
            this.lblDetalles.TabIndex = 16;
            this.lblDetalles.Text = "Detalles:";
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(232, 276);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(93, 23);
            this.btnActualizar.TabIndex = 4;
            this.btnActualizar.Text = "Actualizar Lista";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 481);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.lblDetalles);
            this.Controls.Add(this.lblBusqueda);
            this.Controls.Add(this.ckbRango);
            this.Controls.Add(this.txtRango2);
            this.Controls.Add(this.txtRango1);
            this.Controls.Add(this.lblCriterio);
            this.Controls.Add(this.lblCampo);
            this.Controls.Add(this.cmbCriterio);
            this.Controls.Add(this.cmbCampo);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtDetalles);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.lblListaArticulos);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.pcbImagenArticulo);
            this.Controls.Add(this.dgvListaArticulos);
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestión de Artículos";
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaArticulos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbImagenArticulo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvListaArticulos;
        private System.Windows.Forms.PictureBox pcbImagenArticulo;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Label lblListaArticulos;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.TextBox txtDetalles;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ComboBox cmbCampo;
        private System.Windows.Forms.ComboBox cmbCriterio;
        private System.Windows.Forms.Label lblCampo;
        private System.Windows.Forms.Label lblCriterio;
        private System.Windows.Forms.TextBox txtRango1;
        private System.Windows.Forms.TextBox txtRango2;
        private System.Windows.Forms.CheckBox ckbRango;
        private System.Windows.Forms.Label lblBusqueda;
        private System.Windows.Forms.Label lblDetalles;
        private System.Windows.Forms.Button btnActualizar;
    }
}

