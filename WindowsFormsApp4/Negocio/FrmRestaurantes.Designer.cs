namespace WindowsFormsApp4.Negocio
{
    partial class FrmRestaurantes
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
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.dgvRestaurantes = new Krypton.Toolkit.KryptonDataGridView();
            this.txtNombre = new Krypton.Toolkit.KryptonTextBox();
            this.txtDireccion = new Krypton.Toolkit.KryptonTextBox();
            this.txtTelefono = new Krypton.Toolkit.KryptonTextBox();
            this.BtnAlta = new Krypton.Toolkit.KryptonButton();
            this.BtnBaja = new Krypton.Toolkit.KryptonButton();
            this.BtnModif = new Krypton.Toolkit.KryptonButton();
            this.cmbUsuarios = new Krypton.Toolkit.KryptonComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRestaurantes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbUsuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.cmbUsuarios);
            this.kryptonPanel1.Controls.Add(this.BtnModif);
            this.kryptonPanel1.Controls.Add(this.BtnBaja);
            this.kryptonPanel1.Controls.Add(this.BtnAlta);
            this.kryptonPanel1.Controls.Add(this.txtTelefono);
            this.kryptonPanel1.Controls.Add(this.txtDireccion);
            this.kryptonPanel1.Controls.Add(this.txtNombre);
            this.kryptonPanel1.Controls.Add(this.dgvRestaurantes);
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(801, 452);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // dgvRestaurantes
            // 
            this.dgvRestaurantes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRestaurantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRestaurantes.Location = new System.Drawing.Point(13, 13);
            this.dgvRestaurantes.Name = "dgvRestaurantes";
            this.dgvRestaurantes.Size = new System.Drawing.Size(775, 168);
            this.dgvRestaurantes.TabIndex = 0;
            this.dgvRestaurantes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRestaurantes_CellClick);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(52, 258);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(100, 23);
            this.txtNombre.TabIndex = 1;
            this.txtNombre.Text = "txtNombre";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(217, 258);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(100, 23);
            this.txtDireccion.TabIndex = 2;
            this.txtDireccion.Text = "txtDireccion";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(356, 258);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(100, 23);
            this.txtTelefono.TabIndex = 3;
            this.txtTelefono.Text = "txtTelefono";
            // 
            // BtnAlta
            // 
            this.BtnAlta.Location = new System.Drawing.Point(52, 315);
            this.BtnAlta.Name = "BtnAlta";
            this.BtnAlta.Size = new System.Drawing.Size(90, 25);
            this.BtnAlta.TabIndex = 4;
            this.BtnAlta.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.BtnAlta.Values.Text = "BtnAlta";
            this.BtnAlta.Click += new System.EventHandler(this.BtnAlta_Click);
            // 
            // BtnBaja
            // 
            this.BtnBaja.Location = new System.Drawing.Point(190, 315);
            this.BtnBaja.Name = "BtnBaja";
            this.BtnBaja.Size = new System.Drawing.Size(90, 25);
            this.BtnBaja.TabIndex = 5;
            this.BtnBaja.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.BtnBaja.Values.Text = "BtnBaja";
            this.BtnBaja.Click += new System.EventHandler(this.BtnBaja_Click);
            // 
            // BtnModif
            // 
            this.BtnModif.Location = new System.Drawing.Point(346, 315);
            this.BtnModif.Name = "BtnModif";
            this.BtnModif.Size = new System.Drawing.Size(90, 25);
            this.BtnModif.TabIndex = 6;
            this.BtnModif.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.BtnModif.Values.Text = "BtnModif";
            this.BtnModif.Click += new System.EventHandler(this.BtnModif_Click);
            // 
            // cmbUsuarios
            // 
            this.cmbUsuarios.Location = new System.Drawing.Point(492, 258);
            this.cmbUsuarios.Name = "cmbUsuarios";
            this.cmbUsuarios.Size = new System.Drawing.Size(101, 22);
            this.cmbUsuarios.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.cmbUsuarios.TabIndex = 7;
            this.cmbUsuarios.Text = "cmbUsuarios";
            // 
            // FrmRestaurantes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.kryptonPanel1);
            this.Name = "FrmRestaurantes";
            this.Text = "FrmRestaurantes";
            this.Load += new System.EventHandler(this.FrmRestaurantes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRestaurantes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbUsuarios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private Krypton.Toolkit.KryptonDataGridView dgvRestaurantes;
        private Krypton.Toolkit.KryptonButton BtnModif;
        private Krypton.Toolkit.KryptonButton BtnBaja;
        private Krypton.Toolkit.KryptonButton BtnAlta;
        private Krypton.Toolkit.KryptonTextBox txtTelefono;
        private Krypton.Toolkit.KryptonTextBox txtDireccion;
        private Krypton.Toolkit.KryptonTextBox txtNombre;
        private Krypton.Toolkit.KryptonComboBox cmbUsuarios;
    }
}