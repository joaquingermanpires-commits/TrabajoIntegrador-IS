namespace WindowsFormsApp4.Negocio
{
    partial class FrmGestionMesas
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
            this.panelSalon = new Krypton.Toolkit.KryptonPanel();
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kryptonGroupBox1 = new Krypton.Toolkit.KryptonGroupBox();
            this.chkHabilitada = new Krypton.Toolkit.KryptonCheckBox();
            this.numCapacidad = new Krypton.Toolkit.KryptonNumericUpDown();
            this.txtCodigoMesa = new Krypton.Toolkit.KryptonTextBox();
            this.btnGuardar = new Krypton.Toolkit.KryptonButton();
            this.btnAgregarMesa = new Krypton.Toolkit.KryptonButton();
            this.btnRotarMesa = new Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelSalon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).BeginInit();
            this.kryptonGroupBox1.Panel.SuspendLayout();
            this.kryptonGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSalon
            // 
            this.panelSalon.Location = new System.Drawing.Point(0, 0);
            this.panelSalon.Name = "panelSalon";
            this.panelSalon.Size = new System.Drawing.Size(802, 450);
            this.panelSalon.TabIndex = 0;
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kryptonGroupBox1);
            this.kryptonPanel1.Controls.Add(this.btnGuardar);
            this.kryptonPanel1.Controls.Add(this.btnAgregarMesa);
            this.kryptonPanel1.Location = new System.Drawing.Point(824, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(205, 450);
            this.kryptonPanel1.TabIndex = 1;
            // 
            // kryptonGroupBox1
            // 
            this.kryptonGroupBox1.Location = new System.Drawing.Point(16, 149);
            // 
            // kryptonGroupBox1.Panel
            // 
            this.kryptonGroupBox1.Panel.Controls.Add(this.btnRotarMesa);
            this.kryptonGroupBox1.Panel.Controls.Add(this.chkHabilitada);
            this.kryptonGroupBox1.Panel.Controls.Add(this.numCapacidad);
            this.kryptonGroupBox1.Panel.Controls.Add(this.txtCodigoMesa);
            this.kryptonGroupBox1.Size = new System.Drawing.Size(176, 276);
            this.kryptonGroupBox1.TabIndex = 2;
            // 
            // chkHabilitada
            // 
            this.chkHabilitada.Enabled = false;
            this.chkHabilitada.Location = new System.Drawing.Point(25, 117);
            this.chkHabilitada.Name = "chkHabilitada";
            this.chkHabilitada.Size = new System.Drawing.Size(125, 25);
            this.chkHabilitada.TabIndex = 2;
            this.chkHabilitada.Values.Text = "kryptonCheckBox1";
            this.chkHabilitada.CheckedChanged += new System.EventHandler(this.chkHabilitada_CheckedChanged);
            // 
            // numCapacidad
            // 
            this.numCapacidad.Enabled = false;
            this.numCapacidad.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numCapacidad.Location = new System.Drawing.Point(25, 73);
            this.numCapacidad.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numCapacidad.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numCapacidad.Name = "numCapacidad";
            this.numCapacidad.Size = new System.Drawing.Size(120, 22);
            this.numCapacidad.TabIndex = 1;
            this.numCapacidad.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numCapacidad.ValueChanged += new System.EventHandler(this.numCapacidad_ValueChanged);
            // 
            // txtCodigoMesa
            // 
            this.txtCodigoMesa.Enabled = false;
            this.txtCodigoMesa.Location = new System.Drawing.Point(25, 30);
            this.txtCodigoMesa.Name = "txtCodigoMesa";
            this.txtCodigoMesa.Size = new System.Drawing.Size(100, 23);
            this.txtCodigoMesa.TabIndex = 0;
            this.txtCodigoMesa.Text = "kryptonTextBox1";
            this.txtCodigoMesa.TextChanged += new System.EventHandler(this.txtCodigoMesa_TextChanged);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(43, 100);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(90, 25);
            this.btnGuardar.TabIndex = 1;
            this.btnGuardar.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btnGuardar.Values.Text = "kryptonButton1";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnAgregarMesa
            // 
            this.btnAgregarMesa.Location = new System.Drawing.Point(43, 41);
            this.btnAgregarMesa.Name = "btnAgregarMesa";
            this.btnAgregarMesa.Size = new System.Drawing.Size(90, 25);
            this.btnAgregarMesa.TabIndex = 0;
            this.btnAgregarMesa.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btnAgregarMesa.Values.Text = "kryptonButton1";
            this.btnAgregarMesa.Click += new System.EventHandler(this.btnAgregarMesa_Click);
            // 
            // btnRotarMesa
            // 
            this.btnRotarMesa.Location = new System.Drawing.Point(25, 166);
            this.btnRotarMesa.Name = "btnRotarMesa";
            this.btnRotarMesa.Size = new System.Drawing.Size(90, 25);
            this.btnRotarMesa.TabIndex = 3;
            this.btnRotarMesa.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btnRotarMesa.Values.Text = "btnRotarMesa";
            this.btnRotarMesa.Click += new System.EventHandler(this.btnRotarMesa_Click);
            // 
            // FrmGestionMesas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 449);
            this.Controls.Add(this.kryptonPanel1);
            this.Controls.Add(this.panelSalon);
            this.Name = "FrmGestionMesas";
            this.Text = "FrmGestionMesas";
            this.Load += new System.EventHandler(this.FrmGestionMesas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelSalon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).EndInit();
            this.kryptonGroupBox1.Panel.ResumeLayout(false);
            this.kryptonGroupBox1.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).EndInit();
            this.kryptonGroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.KryptonPanel panelSalon;
        private Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private Krypton.Toolkit.KryptonButton btnGuardar;
        private Krypton.Toolkit.KryptonButton btnAgregarMesa;
        private Krypton.Toolkit.KryptonGroupBox kryptonGroupBox1;
        private Krypton.Toolkit.KryptonCheckBox chkHabilitada;
        private Krypton.Toolkit.KryptonNumericUpDown numCapacidad;
        private Krypton.Toolkit.KryptonTextBox txtCodigoMesa;
        private Krypton.Toolkit.KryptonButton btnRotarMesa;
    }
}