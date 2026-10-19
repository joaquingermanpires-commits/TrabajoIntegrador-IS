namespace WindowsFormsApp4.Negocio
{
    partial class FrmNuevaReserva
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
            this.kryptonNumericUpDown1 = new Krypton.Toolkit.KryptonNumericUpDown();
            this.kryptonTextBox1 = new Krypton.Toolkit.KryptonTextBox();
            this.panelReserva = new Krypton.Toolkit.KryptonPanel();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.btnBuscarMesas = new Krypton.Toolkit.KryptonButton();
            this.numTiempoEstadia = new Krypton.Toolkit.KryptonNumericUpDown();
            this.numComensales = new Krypton.Toolkit.KryptonNumericUpDown();
            this.btnConfirmarReserva = new Krypton.Toolkit.KryptonButton();
            this.txtTokenTarjeta = new Krypton.Toolkit.KryptonTextBox();
            this.dtpHoraReserva = new Krypton.Toolkit.KryptonDateTimePicker();
            this.dtpFechaReserva = new Krypton.Toolkit.KryptonDateTimePicker();
            this.lblMesaElegida = new Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.panelSalon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelReserva)).BeginInit();
            this.panelReserva.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSalon
            // 
            this.panelSalon.Location = new System.Drawing.Point(12, 136);
            this.panelSalon.Name = "panelSalon";
            this.panelSalon.Size = new System.Drawing.Size(920, 453);
            this.panelSalon.TabIndex = 0;
            // 
            // kryptonNumericUpDown1
            // 
            this.kryptonNumericUpDown1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.kryptonNumericUpDown1.Location = new System.Drawing.Point(23, 129);
            this.kryptonNumericUpDown1.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.kryptonNumericUpDown1.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kryptonNumericUpDown1.Name = "kryptonNumericUpDown1";
            this.kryptonNumericUpDown1.Size = new System.Drawing.Size(120, 22);
            this.kryptonNumericUpDown1.TabIndex = 0;
            this.kryptonNumericUpDown1.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // kryptonTextBox1
            // 
            this.kryptonTextBox1.Location = new System.Drawing.Point(23, 170);
            this.kryptonTextBox1.Name = "kryptonTextBox1";
            this.kryptonTextBox1.Size = new System.Drawing.Size(100, 23);
            this.kryptonTextBox1.TabIndex = 6;
            this.kryptonTextBox1.Text = "kryptonTextBox1";
            // 
            // panelReserva
            // 
            this.panelReserva.Controls.Add(this.kryptonLabel1);
            this.panelReserva.Controls.Add(this.btnBuscarMesas);
            this.panelReserva.Controls.Add(this.numTiempoEstadia);
            this.panelReserva.Controls.Add(this.numComensales);
            this.panelReserva.Controls.Add(this.btnConfirmarReserva);
            this.panelReserva.Controls.Add(this.txtTokenTarjeta);
            this.panelReserva.Controls.Add(this.dtpHoraReserva);
            this.panelReserva.Controls.Add(this.dtpFechaReserva);
            this.panelReserva.Controls.Add(this.lblMesaElegida);
            this.panelReserva.Location = new System.Drawing.Point(12, 22);
            this.panelReserva.Name = "panelReserva";
            this.panelReserva.Size = new System.Drawing.Size(920, 93);
            this.panelReserva.TabIndex = 2;
            this.panelReserva.Visible = false;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(477, 18);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(90, 25);
            this.kryptonLabel1.TabIndex = 7;
            this.kryptonLabel1.Values.Text = "Tiempo";
            // 
            // btnBuscarMesas
            // 
            this.btnBuscarMesas.Location = new System.Drawing.Point(793, 13);
            this.btnBuscarMesas.Name = "btnBuscarMesas";
            this.btnBuscarMesas.Size = new System.Drawing.Size(90, 25);
            this.btnBuscarMesas.TabIndex = 0;
            this.btnBuscarMesas.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btnBuscarMesas.Values.Text = "btnBuscarMesas";
            this.btnBuscarMesas.Click += new System.EventHandler(this.btnBuscarMesas_Click);
            // 
            // numTiempoEstadia
            // 
            this.numTiempoEstadia.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numTiempoEstadia.Location = new System.Drawing.Point(477, 47);
            this.numTiempoEstadia.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numTiempoEstadia.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numTiempoEstadia.Name = "numTiempoEstadia";
            this.numTiempoEstadia.Size = new System.Drawing.Size(120, 22);
            this.numTiempoEstadia.TabIndex = 6;
            this.numTiempoEstadia.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // numComensales
            // 
            this.numComensales.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numComensales.Location = new System.Drawing.Point(339, 48);
            this.numComensales.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numComensales.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numComensales.Name = "numComensales";
            this.numComensales.Size = new System.Drawing.Size(120, 22);
            this.numComensales.TabIndex = 5;
            this.numComensales.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // btnConfirmarReserva
            // 
            this.btnConfirmarReserva.Location = new System.Drawing.Point(793, 44);
            this.btnConfirmarReserva.Name = "btnConfirmarReserva";
            this.btnConfirmarReserva.Size = new System.Drawing.Size(90, 25);
            this.btnConfirmarReserva.TabIndex = 4;
            this.btnConfirmarReserva.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btnConfirmarReserva.Values.Text = "btnConfirmarReserva";
            this.btnConfirmarReserva.Click += new System.EventHandler(this.btnConfirmarReserva_Click);
            // 
            // txtTokenTarjeta
            // 
            this.txtTokenTarjeta.Location = new System.Drawing.Point(646, 48);
            this.txtTokenTarjeta.Name = "txtTokenTarjeta";
            this.txtTokenTarjeta.Size = new System.Drawing.Size(100, 23);
            this.txtTokenTarjeta.TabIndex = 3;
            this.txtTokenTarjeta.Text = "txtTokenTarjeta";
            // 
            // dtpHoraReserva
            // 
            this.dtpHoraReserva.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHoraReserva.Location = new System.Drawing.Point(169, 49);
            this.dtpHoraReserva.Name = "dtpHoraReserva";
            this.dtpHoraReserva.ShowUpDown = true;
            this.dtpHoraReserva.Size = new System.Drawing.Size(134, 21);
            this.dtpHoraReserva.TabIndex = 2;
            // 
            // dtpFechaReserva
            // 
            this.dtpFechaReserva.Location = new System.Drawing.Point(4, 50);
            this.dtpFechaReserva.Name = "dtpFechaReserva";
            this.dtpFechaReserva.Size = new System.Drawing.Size(134, 21);
            this.dtpFechaReserva.TabIndex = 1;
            // 
            // lblMesaElegida
            // 
            this.lblMesaElegida.Location = new System.Drawing.Point(4, 18);
            this.lblMesaElegida.Name = "lblMesaElegida";
            this.lblMesaElegida.Size = new System.Drawing.Size(92, 25);
            this.lblMesaElegida.TabIndex = 0;
            this.lblMesaElegida.Values.Text = "lblMesaElegida";
            // 
            // FrmNuevaReserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 631);
            this.Controls.Add(this.panelReserva);
            this.Controls.Add(this.panelSalon);
            this.Name = "FrmNuevaReserva";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FrmNuevaReserva_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelSalon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelReserva)).EndInit();
            this.panelReserva.ResumeLayout(false);
            this.panelReserva.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.KryptonPanel panelSalon;
        private Krypton.Toolkit.KryptonNumericUpDown kryptonNumericUpDown1;
        private Krypton.Toolkit.KryptonTextBox kryptonTextBox1;
        private Krypton.Toolkit.KryptonPanel panelReserva;
        private Krypton.Toolkit.KryptonDateTimePicker dtpHoraReserva;
        private Krypton.Toolkit.KryptonDateTimePicker dtpFechaReserva;
        private Krypton.Toolkit.KryptonLabel lblMesaElegida;
        private Krypton.Toolkit.KryptonButton btnConfirmarReserva;
        private Krypton.Toolkit.KryptonTextBox txtTokenTarjeta;
        private Krypton.Toolkit.KryptonNumericUpDown numComensales;
        private Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private Krypton.Toolkit.KryptonNumericUpDown numTiempoEstadia;
        private Krypton.Toolkit.KryptonButton btnBuscarMesas;
    }
}