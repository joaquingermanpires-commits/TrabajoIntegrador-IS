namespace WindowsFormsApp4
{
    partial class FrmIdiomas
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
            this.cmbIdiomas = new System.Windows.Forms.ComboBox();
            this.dgvTraducciones = new System.Windows.Forms.DataGridView();
            this.txtNuevoIdioma = new System.Windows.Forms.TextBox();
            this.txtEtiqueta = new System.Windows.Forms.TextBox();
            this.btnCambiarTraducciones = new System.Windows.Forms.Button();
            this.btnAgregarIdioma = new System.Windows.Forms.Button();
            this.btnAgregarEtiqueta = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTraduccion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnModificarEtiqueta = new System.Windows.Forms.Button();
            this.btnEliminarEtiqueta = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTraducciones)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbIdiomas
            // 
            this.cmbIdiomas.FormattingEnabled = true;
            this.cmbIdiomas.Location = new System.Drawing.Point(17, 50);
            this.cmbIdiomas.Name = "cmbIdiomas";
            this.cmbIdiomas.Size = new System.Drawing.Size(157, 21);
            this.cmbIdiomas.TabIndex = 0;
            this.cmbIdiomas.SelectedIndexChanged += new System.EventHandler(this.cmbIdiomas_SelectedIndexChanged);
            // 
            // dgvTraducciones
            // 
            this.dgvTraducciones.AllowUserToAddRows = false;
            this.dgvTraducciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTraducciones.Location = new System.Drawing.Point(17, 77);
            this.dgvTraducciones.Name = "dgvTraducciones";
            this.dgvTraducciones.Size = new System.Drawing.Size(261, 150);
            this.dgvTraducciones.TabIndex = 1;
            this.dgvTraducciones.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTraducciones_CellClick);
            // 
            // txtNuevoIdioma
            // 
            this.txtNuevoIdioma.Location = new System.Drawing.Point(61, 12);
            this.txtNuevoIdioma.Name = "txtNuevoIdioma";
            this.txtNuevoIdioma.Size = new System.Drawing.Size(100, 20);
            this.txtNuevoIdioma.TabIndex = 2;
            // 
            // txtEtiqueta
            // 
            this.txtEtiqueta.Location = new System.Drawing.Point(61, 256);
            this.txtEtiqueta.Name = "txtEtiqueta";
            this.txtEtiqueta.Size = new System.Drawing.Size(151, 20);
            this.txtEtiqueta.TabIndex = 3;
            // 
            // btnCambiarTraducciones
            // 
            this.btnCambiarTraducciones.Location = new System.Drawing.Point(180, 337);
            this.btnCambiarTraducciones.Name = "btnCambiarTraducciones";
            this.btnCambiarTraducciones.Size = new System.Drawing.Size(75, 23);
            this.btnCambiarTraducciones.TabIndex = 4;
            this.btnCambiarTraducciones.Text = "Cambiar";
            this.btnCambiarTraducciones.UseVisualStyleBackColor = true;
            this.btnCambiarTraducciones.Click += new System.EventHandler(this.btnAgregarTraducciones_Click);
            // 
            // btnAgregarIdioma
            // 
            this.btnAgregarIdioma.Location = new System.Drawing.Point(167, 10);
            this.btnAgregarIdioma.Name = "btnAgregarIdioma";
            this.btnAgregarIdioma.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarIdioma.TabIndex = 5;
            this.btnAgregarIdioma.Tag = "btnAgregar";
            this.btnAgregarIdioma.Text = "Agregar";
            this.btnAgregarIdioma.UseVisualStyleBackColor = true;
            this.btnAgregarIdioma.Click += new System.EventHandler(this.btnAgregarIdioma_Click);
            // 
            // btnAgregarEtiqueta
            // 
            this.btnAgregarEtiqueta.Location = new System.Drawing.Point(17, 282);
            this.btnAgregarEtiqueta.Name = "btnAgregarEtiqueta";
            this.btnAgregarEtiqueta.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarEtiqueta.TabIndex = 6;
            this.btnAgregarEtiqueta.Tag = "btnAgregar";
            this.btnAgregarEtiqueta.Text = "Agregar";
            this.btnAgregarEtiqueta.UseVisualStyleBackColor = true;
            this.btnAgregarEtiqueta.Click += new System.EventHandler(this.btnAgregarEtiqueta_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Idioma:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 259);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Etiqueta";
            // 
            // txtTraduccion
            // 
            this.txtTraduccion.Location = new System.Drawing.Point(74, 337);
            this.txtTraduccion.Name = "txtTraduccion";
            this.txtTraduccion.Size = new System.Drawing.Size(100, 20);
            this.txtTraduccion.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 340);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Traduccion";
            // 
            // btnModificarEtiqueta
            // 
            this.btnModificarEtiqueta.Location = new System.Drawing.Point(198, 282);
            this.btnModificarEtiqueta.Name = "btnModificarEtiqueta";
            this.btnModificarEtiqueta.Size = new System.Drawing.Size(75, 23);
            this.btnModificarEtiqueta.TabIndex = 11;
            this.btnModificarEtiqueta.Text = "Modificar";
            this.btnModificarEtiqueta.UseVisualStyleBackColor = true;
            this.btnModificarEtiqueta.Click += new System.EventHandler(this.btnModificarEtiqueta_Click);
            // 
            // btnEliminarEtiqueta
            // 
            this.btnEliminarEtiqueta.Location = new System.Drawing.Point(108, 282);
            this.btnEliminarEtiqueta.Name = "btnEliminarEtiqueta";
            this.btnEliminarEtiqueta.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarEtiqueta.TabIndex = 12;
            this.btnEliminarEtiqueta.Text = "Eliminar";
            this.btnEliminarEtiqueta.UseVisualStyleBackColor = true;
            this.btnEliminarEtiqueta.Click += new System.EventHandler(this.btnEliminarEtiqueta_Click);
            // 
            // FrmIdiomas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 379);
            this.Controls.Add(this.btnEliminarEtiqueta);
            this.Controls.Add(this.btnModificarEtiqueta);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTraduccion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAgregarEtiqueta);
            this.Controls.Add(this.btnAgregarIdioma);
            this.Controls.Add(this.btnCambiarTraducciones);
            this.Controls.Add(this.txtEtiqueta);
            this.Controls.Add(this.txtNuevoIdioma);
            this.Controls.Add(this.dgvTraducciones);
            this.Controls.Add(this.cmbIdiomas);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmIdiomas";
            this.Tag = "FrmIdiomas";
            this.Text = "Idiomas";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmIdiomas_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTraducciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbIdiomas;
        private System.Windows.Forms.DataGridView dgvTraducciones;
        private System.Windows.Forms.TextBox txtNuevoIdioma;
        private System.Windows.Forms.TextBox txtEtiqueta;
        private System.Windows.Forms.Button btnCambiarTraducciones;
        private System.Windows.Forms.Button btnAgregarIdioma;
        private System.Windows.Forms.Button btnAgregarEtiqueta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTraduccion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnModificarEtiqueta;
        private System.Windows.Forms.Button btnEliminarEtiqueta;
    }
}