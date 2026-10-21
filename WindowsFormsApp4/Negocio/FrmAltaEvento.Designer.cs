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
            this.dgvEventos = new Krypton.Toolkit.KryptonDataGridView();
            this.btnGuardarEvento = new Krypton.Toolkit.KryptonButton();
            this.numDescuento = new Krypton.Toolkit.KryptonNumericUpDown();
            this.dtpFechaInicio = new Krypton.Toolkit.KryptonDateTimePicker();
            this.dtpFechaFin = new Krypton.Toolkit.KryptonDateTimePicker();
            this.txtDescripcion = new Krypton.Toolkit.KryptonRichTextBox();
            this.txtNombre = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel3 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel4 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel5 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel6 = new Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEventos)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kryptonLabel6);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel5);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel4);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel3);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel2);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel1.Controls.Add(this.dgvEventos);
            this.kryptonPanel1.Controls.Add(this.btnGuardarEvento);
            this.kryptonPanel1.Controls.Add(this.numDescuento);
            this.kryptonPanel1.Controls.Add(this.dtpFechaInicio);
            this.kryptonPanel1.Controls.Add(this.dtpFechaFin);
            this.kryptonPanel1.Controls.Add(this.txtDescripcion);
            this.kryptonPanel1.Controls.Add(this.txtNombre);
            this.kryptonPanel1.Location = new System.Drawing.Point(0, -3);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(800, 311);
            this.kryptonPanel1.TabIndex = 0;
            this.kryptonPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.kryptonPanel1_Paint);
            // 
            // dgvEventos
            // 
            this.dgvEventos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvEventos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEventos.Location = new System.Drawing.Point(290, 67);
            this.dgvEventos.Name = "dgvEventos";
            this.dgvEventos.Size = new System.Drawing.Size(498, 199);
            this.dgvEventos.TabIndex = 7;
            // 
            // btnGuardarEvento
            // 
            this.btnGuardarEvento.Location = new System.Drawing.Point(145, 269);
            this.btnGuardarEvento.Name = "btnGuardarEvento";
            this.btnGuardarEvento.Size = new System.Drawing.Size(90, 25);
            this.btnGuardarEvento.TabIndex = 6;
            this.btnGuardarEvento.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btnGuardarEvento.Values.Text = "Guardar evento";
            this.btnGuardarEvento.Click += new System.EventHandler(this.btnGuardarEvento_Click);
            // 
            // numDescuento
            // 
            this.numDescuento.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDescuento.Location = new System.Drawing.Point(19, 272);
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
            this.numDescuento.Size = new System.Drawing.Size(98, 22);
            this.numDescuento.TabIndex = 5;
            this.numDescuento.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaInicio.Location = new System.Drawing.Point(19, 215);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(75, 21);
            this.dtpFechaInicio.TabIndex = 4;
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaFin.Location = new System.Drawing.Point(140, 215);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(75, 21);
            this.dtpFechaFin.TabIndex = 3;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(19, 89);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(234, 96);
            this.txtDescripcion.TabIndex = 1;
            this.txtDescripcion.Text = "";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(128, 15);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(125, 23);
            this.txtNombre.TabIndex = 0;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(19, 192);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(90, 25);
            this.kryptonLabel1.TabIndex = 8;
            this.kryptonLabel1.Values.Text = "Fecha inicio";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(140, 191);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(106, 25);
            this.kryptonLabel2.TabIndex = 9;
            this.kryptonLabel2.Values.Text = "Fecha finalizacion";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(19, 241);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(98, 25);
            this.kryptonLabel3.TabIndex = 10;
            this.kryptonLabel3.Values.Text = "% de descuento";
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(19, 13);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(90, 25);
            this.kryptonLabel4.TabIndex = 11;
            this.kryptonLabel4.Values.Text = "Nombre:";
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Location = new System.Drawing.Point(19, 58);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(90, 25);
            this.kryptonLabel5.TabIndex = 12;
            this.kryptonLabel5.Values.Text = "Descripcion:";
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.Location = new System.Drawing.Point(290, 36);
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.Size = new System.Drawing.Size(98, 25);
            this.kryptonLabel6.TabIndex = 13;
            this.kryptonLabel6.Values.Text = "Eventos Activos:";
            // 
            // FrmAltaEvento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 310);
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
        private Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private Krypton.Toolkit.KryptonLabel kryptonLabel6;
    }
}