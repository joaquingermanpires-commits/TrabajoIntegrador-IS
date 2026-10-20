namespace WindowsFormsApp4.Negocio
{
    partial class FrmAltaEvento
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
            this.txtNombre = new Krypton.Toolkit.KryptonTextBox();
            this.txtDescripcion = new Krypton.Toolkit.KryptonRichTextBox();
            this.dtpFechaFin = new Krypton.Toolkit.KryptonDateTimePicker();
            this.dtpFechaInicio = new Krypton.Toolkit.KryptonDateTimePicker();
            this.numDescuento = new Krypton.Toolkit.KryptonNumericUpDown();
            this.btnGuardarEvento = new Krypton.Toolkit.KryptonButton();
            this.dgvEventos = new Krypton.Toolkit.KryptonDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEventos)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.dgvEventos);
            this.kryptonPanel1.Controls.Add(this.btnGuardarEvento);
            this.kryptonPanel1.Controls.Add(this.numDescuento);
            this.kryptonPanel1.Controls.Add(this.dtpFechaInicio);
            this.kryptonPanel1.Controls.Add(this.dtpFechaFin);
            this.kryptonPanel1.Controls.Add(this.txtDescripcion);
            this.kryptonPanel1.Controls.Add(this.txtNombre);
            this.kryptonPanel1.Location = new System.Drawing.Point(0, -3);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(800, 454);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(44, 83);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(100, 23);
            this.txtNombre.TabIndex = 0;
            this.txtNombre.Text = "txtNombre";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(44, 118);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(100, 96);
            this.txtDescripcion.TabIndex = 1;
            this.txtDescripcion.Text = "txtDescripcion";
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaFin.Location = new System.Drawing.Point(44, 314);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(75, 21);
            this.dtpFechaFin.TabIndex = 3;
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaInicio.Location = new System.Drawing.Point(44, 255);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(75, 21);
            this.dtpFechaInicio.TabIndex = 4;
            // 
            // numDescuento
            // 
            this.numDescuento.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDescuento.Location = new System.Drawing.Point(44, 365);
            this.numDescuento.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numDescuento.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numDescuento.Name = "numDescuento";
            this.numDescuento.Size = new System.Drawing.Size(120, 22);
            this.numDescuento.TabIndex = 5;
            this.numDescuento.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // btnGuardarEvento
            // 
            this.btnGuardarEvento.Location = new System.Drawing.Point(44, 416);
            this.btnGuardarEvento.Name = "btnGuardarEvento";
            this.btnGuardarEvento.Size = new System.Drawing.Size(90, 25);
            this.btnGuardarEvento.TabIndex = 6;
            this.btnGuardarEvento.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btnGuardarEvento.Values.Text = "btnGuardarEvento";
            this.btnGuardarEvento.Click += new System.EventHandler(this.btnGuardarEvento_Click);
            // 
            // dgvEventos
            // 
            this.dgvEventos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvEventos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEventos.Location = new System.Drawing.Point(215, 83);
            this.dgvEventos.Name = "dgvEventos";
            this.dgvEventos.Size = new System.Drawing.Size(534, 193);
            this.dgvEventos.TabIndex = 7;
            // 
            // FrmAltaEvento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.kryptonPanel1);
            this.Name = "FrmAltaEvento";
            this.Text = "FrmAltaEvento";
            this.Load += new System.EventHandler(this.FrmAltaEvento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEventos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private Krypton.Toolkit.KryptonDateTimePicker dtpFechaFin;
        private Krypton.Toolkit.KryptonRichTextBox txtDescripcion;
        private Krypton.Toolkit.KryptonTextBox txtNombre;
        private Krypton.Toolkit.KryptonButton btnGuardarEvento;
        private Krypton.Toolkit.KryptonNumericUpDown numDescuento;
        private Krypton.Toolkit.KryptonDateTimePicker dtpFechaInicio;
        private Krypton.Toolkit.KryptonDataGridView dgvEventos;
    }
}