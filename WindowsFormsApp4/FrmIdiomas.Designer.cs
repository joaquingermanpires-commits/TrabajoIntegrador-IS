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
            this.txtNuevaEtiqueta = new System.Windows.Forms.TextBox();
            this.btnAgregarTraducciones = new System.Windows.Forms.Button();
            this.btnAgregarIdioma = new System.Windows.Forms.Button();
            this.btnAgregarEtiqueta = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNuevaTraduccion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTraducciones)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbIdiomas
            // 
            this.cmbIdiomas.FormattingEnabled = true;
            this.cmbIdiomas.Location = new System.Drawing.Point(11, 182);
            this.cmbIdiomas.Name = "cmbIdiomas";
            this.cmbIdiomas.Size = new System.Drawing.Size(157, 21);
            this.cmbIdiomas.TabIndex = 0;
            this.cmbIdiomas.SelectedIndexChanged += new System.EventHandler(this.cmbIdiomas_SelectedIndexChanged);
            // 
            // dgvTraducciones
            // 
            this.dgvTraducciones.AllowUserToAddRows = false;
            this.dgvTraducciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTraducciones.Location = new System.Drawing.Point(12, 12);
            this.dgvTraducciones.Name = "dgvTraducciones";
            this.dgvTraducciones.Size = new System.Drawing.Size(261, 150);
            this.dgvTraducciones.TabIndex = 1;
            this.dgvTraducciones.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTraducciones_CellClick);
            // 
            // txtNuevoIdioma
            // 
            this.txtNuevoIdioma.Location = new System.Drawing.Point(279, 36);
            this.txtNuevoIdioma.Name = "txtNuevoIdioma";
            this.txtNuevoIdioma.Size = new System.Drawing.Size(100, 20);
            this.txtNuevoIdioma.TabIndex = 2;
            // 
            // txtNuevaEtiqueta
            // 
            this.txtNuevaEtiqueta.Location = new System.Drawing.Point(279, 88);
            this.txtNuevaEtiqueta.Name = "txtNuevaEtiqueta";
            this.txtNuevaEtiqueta.Size = new System.Drawing.Size(100, 20);
            this.txtNuevaEtiqueta.TabIndex = 3;
            // 
            // btnAgregarTraducciones
            // 
            this.btnAgregarTraducciones.Location = new System.Drawing.Point(385, 141);
            this.btnAgregarTraducciones.Name = "btnAgregarTraducciones";
            this.btnAgregarTraducciones.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarTraducciones.TabIndex = 4;
            this.btnAgregarTraducciones.Text = "Agregar";
            this.btnAgregarTraducciones.UseVisualStyleBackColor = true;
            this.btnAgregarTraducciones.Click += new System.EventHandler(this.btnAgregarTraducciones_Click);
            // 
            // btnAgregarIdioma
            // 
            this.btnAgregarIdioma.Location = new System.Drawing.Point(385, 34);
            this.btnAgregarIdioma.Name = "btnAgregarIdioma";
            this.btnAgregarIdioma.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarIdioma.TabIndex = 5;
            this.btnAgregarIdioma.Text = "Agregar";
            this.btnAgregarIdioma.UseVisualStyleBackColor = true;
            this.btnAgregarIdioma.Click += new System.EventHandler(this.btnAgregarIdioma_Click);
            // 
            // btnAgregarEtiqueta
            // 
            this.btnAgregarEtiqueta.Location = new System.Drawing.Point(385, 88);
            this.btnAgregarEtiqueta.Name = "btnAgregarEtiqueta";
            this.btnAgregarEtiqueta.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarEtiqueta.TabIndex = 6;
            this.btnAgregarEtiqueta.Text = "Agregar";
            this.btnAgregarEtiqueta.UseVisualStyleBackColor = true;
            this.btnAgregarEtiqueta.Click += new System.EventHandler(this.btnAgregarEtiqueta_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(279, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Idioma";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(279, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Etiqueta";
            // 
            // txtNuevaTraduccion
            // 
            this.txtNuevaTraduccion.Location = new System.Drawing.Point(279, 143);
            this.txtNuevaTraduccion.Name = "txtNuevaTraduccion";
            this.txtNuevaTraduccion.Size = new System.Drawing.Size(100, 20);
            this.txtNuevaTraduccion.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(279, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Traduccion";
            // 
            // FrmIdiomas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 277);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNuevaTraduccion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAgregarEtiqueta);
            this.Controls.Add(this.btnAgregarIdioma);
            this.Controls.Add(this.btnAgregarTraducciones);
            this.Controls.Add(this.txtNuevaEtiqueta);
            this.Controls.Add(this.txtNuevoIdioma);
            this.Controls.Add(this.dgvTraducciones);
            this.Controls.Add(this.cmbIdiomas);
            this.Name = "FrmIdiomas";
            this.Text = "FrmIdiomas";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmIdiomas_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTraducciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbIdiomas;
        private System.Windows.Forms.DataGridView dgvTraducciones;
        private System.Windows.Forms.TextBox txtNuevoIdioma;
        private System.Windows.Forms.TextBox txtNuevaEtiqueta;
        private System.Windows.Forms.Button btnAgregarTraducciones;
        private System.Windows.Forms.Button btnAgregarIdioma;
        private System.Windows.Forms.Button btnAgregarEtiqueta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNuevaTraduccion;
        private System.Windows.Forms.Label label3;
    }
}