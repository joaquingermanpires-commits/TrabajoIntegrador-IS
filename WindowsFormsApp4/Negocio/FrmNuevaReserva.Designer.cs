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
            ((System.ComponentModel.ISupportInitialize)(this.panelSalon)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSalon
            // 
            this.panelSalon.Location = new System.Drawing.Point(-1, -1);
            this.panelSalon.Name = "panelSalon";
            this.panelSalon.Size = new System.Drawing.Size(803, 453);
            this.panelSalon.TabIndex = 0;
            // 
            // FrmNuevaReserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelSalon);
            this.Name = "FrmNuevaReserva";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FrmNuevaReserva_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelSalon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.KryptonPanel panelSalon;
    }
}