namespace WindowsFormsApp4.Negocio
{
    partial class FrmConfiguracionLocal
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
            this.kryptonGroupBox1 = new Krypton.Toolkit.KryptonGroupBox();
            this.btnGuardarReglas = new Krypton.Toolkit.KryptonButton();
            this.numOcupacion = new Krypton.Toolkit.KryptonNumericUpDown();
            this.numTiempoMaximo = new Krypton.Toolkit.KryptonNumericUpDown();
            this.numTiempoMinimo = new Krypton.Toolkit.KryptonNumericUpDown();
            this.kryptonLabel3 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonGroupBox2 = new Krypton.Toolkit.KryptonGroupBox();
            this.dgvHorarios = new System.Windows.Forms.DataGridView();
            this.btnGuardarHorario = new Krypton.Toolkit.KryptonButton();
            this.dtpCierre = new Krypton.Toolkit.KryptonDateTimePicker();
            this.dtpApertura = new Krypton.Toolkit.KryptonDateTimePicker();
            this.chkHabilitado = new Krypton.Toolkit.KryptonCheckBox();
            this.cmbDiaSemana = new Krypton.Toolkit.KryptonComboBox();
            this.kryptonGroupBox3 = new Krypton.Toolkit.KryptonGroupBox();
            this.clbPreferencias = new Krypton.Toolkit.KryptonCheckedListBox();
            this.btnAgregar = new Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).BeginInit();
            this.kryptonGroupBox1.Panel.SuspendLayout();
            this.kryptonGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2.Panel)).BeginInit();
            this.kryptonGroupBox2.Panel.SuspendLayout();
            this.kryptonGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHorarios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDiaSemana)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox3.Panel)).BeginInit();
            this.kryptonGroupBox3.Panel.SuspendLayout();
            this.kryptonGroupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonGroupBox1
            // 
            this.kryptonGroupBox1.Location = new System.Drawing.Point(1, 0);
            // 
            // kryptonGroupBox1.Panel
            // 
            this.kryptonGroupBox1.Panel.Controls.Add(this.btnGuardarReglas);
            this.kryptonGroupBox1.Panel.Controls.Add(this.numOcupacion);
            this.kryptonGroupBox1.Panel.Controls.Add(this.numTiempoMaximo);
            this.kryptonGroupBox1.Panel.Controls.Add(this.numTiempoMinimo);
            this.kryptonGroupBox1.Panel.Controls.Add(this.kryptonLabel3);
            this.kryptonGroupBox1.Panel.Controls.Add(this.kryptonLabel2);
            this.kryptonGroupBox1.Panel.Controls.Add(this.kryptonLabel1);
            this.kryptonGroupBox1.Size = new System.Drawing.Size(171, 431);
            this.kryptonGroupBox1.TabIndex = 0;
            this.kryptonGroupBox1.Values.Heading = "Reservas";
            // 
            // btnGuardarReglas
            // 
            this.btnGuardarReglas.Location = new System.Drawing.Point(29, 336);
            this.btnGuardarReglas.Name = "btnGuardarReglas";
            this.btnGuardarReglas.Size = new System.Drawing.Size(90, 25);
            this.btnGuardarReglas.TabIndex = 6;
            this.btnGuardarReglas.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btnGuardarReglas.Values.Text = "Guardar";
            this.btnGuardarReglas.Click += new System.EventHandler(this.btnGuardarReglas_Click);
            // 
            // numOcupacion
            // 
            this.numOcupacion.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numOcupacion.Location = new System.Drawing.Point(29, 281);
            this.numOcupacion.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numOcupacion.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numOcupacion.Name = "numOcupacion";
            this.numOcupacion.Size = new System.Drawing.Size(120, 22);
            this.numOcupacion.TabIndex = 5;
            this.numOcupacion.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // numTiempoMaximo
            // 
            this.numTiempoMaximo.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numTiempoMaximo.Location = new System.Drawing.Point(29, 155);
            this.numTiempoMaximo.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numTiempoMaximo.Minimum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numTiempoMaximo.Name = "numTiempoMaximo";
            this.numTiempoMaximo.Size = new System.Drawing.Size(120, 22);
            this.numTiempoMaximo.TabIndex = 4;
            this.numTiempoMaximo.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // numTiempoMinimo
            // 
            this.numTiempoMinimo.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numTiempoMinimo.Location = new System.Drawing.Point(29, 51);
            this.numTiempoMinimo.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numTiempoMinimo.Minimum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numTiempoMinimo.Name = "numTiempoMinimo";
            this.numTiempoMinimo.Size = new System.Drawing.Size(120, 22);
            this.numTiempoMinimo.TabIndex = 3;
            this.numTiempoMinimo.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(29, 250);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(136, 25);
            this.kryptonLabel3.TabIndex = 2;
            this.kryptonLabel3.Values.Text = "Ocupación Máxima (%)";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(27, 117);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(130, 25);
            this.kryptonLabel2.TabIndex = 1;
            this.kryptonLabel2.Values.Text = "Tiempo Máximo (min)";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(29, 20);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(128, 25);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "Tiempo Mínimo (min)";
            // 
            // kryptonGroupBox2
            // 
            this.kryptonGroupBox2.Location = new System.Drawing.Point(178, 0);
            // 
            // kryptonGroupBox2.Panel
            // 
            this.kryptonGroupBox2.Panel.Controls.Add(this.dgvHorarios);
            this.kryptonGroupBox2.Panel.Controls.Add(this.btnGuardarHorario);
            this.kryptonGroupBox2.Panel.Controls.Add(this.dtpCierre);
            this.kryptonGroupBox2.Panel.Controls.Add(this.dtpApertura);
            this.kryptonGroupBox2.Panel.Controls.Add(this.chkHabilitado);
            this.kryptonGroupBox2.Panel.Controls.Add(this.cmbDiaSemana);
            this.kryptonGroupBox2.Size = new System.Drawing.Size(359, 431);
            this.kryptonGroupBox2.TabIndex = 1;
            this.kryptonGroupBox2.Values.Heading = "Apertura";
            // 
            // dgvHorarios
            // 
            this.dgvHorarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHorarios.Location = new System.Drawing.Point(16, 183);
            this.dgvHorarios.Name = "dgvHorarios";
            this.dgvHorarios.Size = new System.Drawing.Size(321, 217);
            this.dgvHorarios.TabIndex = 6;
            // 
            // btnGuardarHorario
            // 
            this.btnGuardarHorario.Location = new System.Drawing.Point(48, 152);
            this.btnGuardarHorario.Name = "btnGuardarHorario";
            this.btnGuardarHorario.Size = new System.Drawing.Size(114, 25);
            this.btnGuardarHorario.TabIndex = 4;
            this.btnGuardarHorario.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btnGuardarHorario.Values.Text = "Aplicar Horario";
            this.btnGuardarHorario.Click += new System.EventHandler(this.btnGuardarHorario_Click);
            // 
            // dtpCierre
            // 
            this.dtpCierre.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpCierre.Location = new System.Drawing.Point(177, 97);
            this.dtpCierre.Name = "dtpCierre";
            this.dtpCierre.ShowUpDown = true;
            this.dtpCierre.Size = new System.Drawing.Size(115, 21);
            this.dtpCierre.TabIndex = 3;
            // 
            // dtpApertura
            // 
            this.dtpApertura.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpApertura.Location = new System.Drawing.Point(48, 97);
            this.dtpApertura.Name = "dtpApertura";
            this.dtpApertura.ShowUpDown = true;
            this.dtpApertura.Size = new System.Drawing.Size(114, 21);
            this.dtpApertura.TabIndex = 2;
            // 
            // chkHabilitado
            // 
            this.chkHabilitado.Location = new System.Drawing.Point(177, 38);
            this.chkHabilitado.Name = "chkHabilitado";
            this.chkHabilitado.Size = new System.Drawing.Size(96, 25);
            this.chkHabilitado.TabIndex = 1;
            this.chkHabilitado.Values.Text = "Abrir este día";
            // 
            // cmbDiaSemana
            // 
            this.cmbDiaSemana.Items.AddRange(new object[] {
            "Domingo",
            "Lunes",
            "Martes",
            "Miércoles",
            "Jueves",
            "Viernes",
            "Sábado"});
            this.cmbDiaSemana.Location = new System.Drawing.Point(48, 38);
            this.cmbDiaSemana.Name = "cmbDiaSemana";
            this.cmbDiaSemana.Size = new System.Drawing.Size(114, 22);
            this.cmbDiaSemana.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.cmbDiaSemana.TabIndex = 0;
            this.cmbDiaSemana.Text = "kryptonComboBox1";
            // 
            // kryptonGroupBox3
            // 
            this.kryptonGroupBox3.Location = new System.Drawing.Point(543, 0);
            // 
            // kryptonGroupBox3.Panel
            // 
            this.kryptonGroupBox3.Panel.Controls.Add(this.clbPreferencias);
            this.kryptonGroupBox3.Panel.Controls.Add(this.btnAgregar);
            this.kryptonGroupBox3.Size = new System.Drawing.Size(206, 431);
            this.kryptonGroupBox3.TabIndex = 2;
            this.kryptonGroupBox3.Values.Heading = "Opciones Dieteticas";
            // 
            // clbPreferencias
            // 
            this.clbPreferencias.Location = new System.Drawing.Point(11, 3);
            this.clbPreferencias.Name = "clbPreferencias";
            this.clbPreferencias.Size = new System.Drawing.Size(175, 213);
            this.clbPreferencias.TabIndex = 3;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(13, 222);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(173, 25);
            this.btnAgregar.TabIndex = 2;
            this.btnAgregar.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btnAgregar.Values.Text = "Guardar Preferencias";
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // FrmConfiguracionLocal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 443);
            this.Controls.Add(this.kryptonGroupBox3);
            this.Controls.Add(this.kryptonGroupBox2);
            this.Controls.Add(this.kryptonGroupBox1);
            this.Name = "FrmConfiguracionLocal";
            this.Text = "FrmConfiguracionLocal";
            this.Load += new System.EventHandler(this.FrmConfiguracionLocal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).EndInit();
            this.kryptonGroupBox1.Panel.ResumeLayout(false);
            this.kryptonGroupBox1.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).EndInit();
            this.kryptonGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2.Panel)).EndInit();
            this.kryptonGroupBox2.Panel.ResumeLayout(false);
            this.kryptonGroupBox2.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2)).EndInit();
            this.kryptonGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHorarios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDiaSemana)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox3.Panel)).EndInit();
            this.kryptonGroupBox3.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox3)).EndInit();
            this.kryptonGroupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.KryptonGroupBox kryptonGroupBox1;
        private Krypton.Toolkit.KryptonGroupBox kryptonGroupBox2;
        private Krypton.Toolkit.KryptonGroupBox kryptonGroupBox3;
        private Krypton.Toolkit.KryptonButton btnGuardarReglas;
        private Krypton.Toolkit.KryptonNumericUpDown numOcupacion;
        private Krypton.Toolkit.KryptonNumericUpDown numTiempoMaximo;
        private Krypton.Toolkit.KryptonNumericUpDown numTiempoMinimo;
        private Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private Krypton.Toolkit.KryptonComboBox cmbDiaSemana;
        private System.Windows.Forms.DataGridView dgvHorarios;
        private Krypton.Toolkit.KryptonButton btnGuardarHorario;
        private Krypton.Toolkit.KryptonDateTimePicker dtpCierre;
        private Krypton.Toolkit.KryptonDateTimePicker dtpApertura;
        private Krypton.Toolkit.KryptonCheckBox chkHabilitado;
        private Krypton.Toolkit.KryptonButton btnAgregar;
        private Krypton.Toolkit.KryptonCheckedListBox clbPreferencias;
    }
}