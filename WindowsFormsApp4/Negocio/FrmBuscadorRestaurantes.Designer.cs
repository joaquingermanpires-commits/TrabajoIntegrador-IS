namespace WindowsFormsApp4.Negocio
{
    partial class FrmBuscadorRestaurantes
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
            this.kryptonHeaderGroup1 = new Krypton.Toolkit.KryptonHeaderGroup();
            this.btnBuscarRestaurantes = new Krypton.Toolkit.KryptonButton();
            this.numComensalesBusqueda = new Krypton.Toolkit.KryptonNumericUpDown();
            this.dtpHoraBusqueda = new Krypton.Toolkit.KryptonDateTimePicker();
            this.dtpFechaBusqueda = new Krypton.Toolkit.KryptonDateTimePicker();
            this.kryptonGroupBox1 = new Krypton.Toolkit.KryptonGroupBox();
            this.btnSeleccionarRestaurante = new Krypton.Toolkit.KryptonButton();
            this.dgvRestaurantes = new Krypton.Toolkit.KryptonDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).BeginInit();
            this.kryptonHeaderGroup1.Panel.SuspendLayout();
            this.kryptonHeaderGroup1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).BeginInit();
            this.kryptonGroupBox1.Panel.SuspendLayout();
            this.kryptonGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRestaurantes)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonHeaderGroup1
            // 
            this.kryptonHeaderGroup1.Location = new System.Drawing.Point(-1, -2);
            // 
            // kryptonHeaderGroup1.Panel
            // 
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.btnBuscarRestaurantes);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.numComensalesBusqueda);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.dtpHoraBusqueda);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.dtpFechaBusqueda);
            this.kryptonHeaderGroup1.Size = new System.Drawing.Size(925, 153);
            this.kryptonHeaderGroup1.TabIndex = 0;
            // 
            // btnBuscarRestaurantes
            // 
            this.btnBuscarRestaurantes.Location = new System.Drawing.Point(473, 67);
            this.btnBuscarRestaurantes.Name = "btnBuscarRestaurantes";
            this.btnBuscarRestaurantes.Size = new System.Drawing.Size(137, 25);
            this.btnBuscarRestaurantes.TabIndex = 3;
            this.btnBuscarRestaurantes.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btnBuscarRestaurantes.Values.Text = "btnBuscarRestaurantes";
            this.btnBuscarRestaurantes.Click += new System.EventHandler(this.btnBuscarRestaurantes_Click);
            // 
            // numComensalesBusqueda
            // 
            this.numComensalesBusqueda.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numComensalesBusqueda.Location = new System.Drawing.Point(347, 70);
            this.numComensalesBusqueda.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numComensalesBusqueda.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numComensalesBusqueda.Name = "numComensalesBusqueda";
            this.numComensalesBusqueda.Size = new System.Drawing.Size(120, 22);
            this.numComensalesBusqueda.TabIndex = 2;
            this.numComensalesBusqueda.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // dtpHoraBusqueda
            // 
            this.dtpHoraBusqueda.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHoraBusqueda.Location = new System.Drawing.Point(183, 71);
            this.dtpHoraBusqueda.Name = "dtpHoraBusqueda";
            this.dtpHoraBusqueda.ShowUpDown = true;
            this.dtpHoraBusqueda.Size = new System.Drawing.Size(158, 21);
            this.dtpHoraBusqueda.TabIndex = 1;
            // 
            // dtpFechaBusqueda
            // 
            this.dtpFechaBusqueda.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaBusqueda.Location = new System.Drawing.Point(12, 71);
            this.dtpFechaBusqueda.Name = "dtpFechaBusqueda";
            this.dtpFechaBusqueda.Size = new System.Drawing.Size(165, 21);
            this.dtpFechaBusqueda.TabIndex = 0;
            // 
            // kryptonGroupBox1
            // 
            this.kryptonGroupBox1.Location = new System.Drawing.Point(-1, 132);
            // 
            // kryptonGroupBox1.Panel
            // 
            this.kryptonGroupBox1.Panel.Controls.Add(this.btnSeleccionarRestaurante);
            this.kryptonGroupBox1.Panel.Controls.Add(this.dgvRestaurantes);
            this.kryptonGroupBox1.Size = new System.Drawing.Size(925, 319);
            this.kryptonGroupBox1.TabIndex = 1;
            // 
            // btnSeleccionarRestaurante
            // 
            this.btnSeleccionarRestaurante.Location = new System.Drawing.Point(11, 231);
            this.btnSeleccionarRestaurante.Name = "btnSeleccionarRestaurante";
            this.btnSeleccionarRestaurante.Size = new System.Drawing.Size(207, 25);
            this.btnSeleccionarRestaurante.TabIndex = 1;
            this.btnSeleccionarRestaurante.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btnSeleccionarRestaurante.Values.Text = "Ver Mesas y Reservar";
            this.btnSeleccionarRestaurante.Click += new System.EventHandler(this.btnSeleccionarRestaurante_Click);
            // 
            // dgvRestaurantes
            // 
            this.dgvRestaurantes.AllowUserToAddRows = false;
            this.dgvRestaurantes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRestaurantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRestaurantes.Location = new System.Drawing.Point(11, 25);
            this.dgvRestaurantes.Name = "dgvRestaurantes";
            this.dgvRestaurantes.ReadOnly = true;
            this.dgvRestaurantes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRestaurantes.Size = new System.Drawing.Size(784, 150);
            this.dgvRestaurantes.TabIndex = 0;
            // 
            // FrmBuscadorRestaurantes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 450);
            this.Controls.Add(this.kryptonGroupBox1);
            this.Controls.Add(this.kryptonHeaderGroup1);
            this.Name = "FrmBuscadorRestaurantes";
            this.Text = "FrmBuscadorRestaurantes";
            this.Load += new System.EventHandler(this.FrmBuscadorRestaurantes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).EndInit();
            this.kryptonHeaderGroup1.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).EndInit();
            this.kryptonHeaderGroup1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).EndInit();
            this.kryptonGroupBox1.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).EndInit();
            this.kryptonGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRestaurantes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.KryptonHeaderGroup kryptonHeaderGroup1;
        private Krypton.Toolkit.KryptonButton btnBuscarRestaurantes;
        private Krypton.Toolkit.KryptonNumericUpDown numComensalesBusqueda;
        private Krypton.Toolkit.KryptonDateTimePicker dtpHoraBusqueda;
        private Krypton.Toolkit.KryptonDateTimePicker dtpFechaBusqueda;
        private Krypton.Toolkit.KryptonGroupBox kryptonGroupBox1;
        private Krypton.Toolkit.KryptonButton btnSeleccionarRestaurante;
        private Krypton.Toolkit.KryptonDataGridView dgvRestaurantes;
    }
}