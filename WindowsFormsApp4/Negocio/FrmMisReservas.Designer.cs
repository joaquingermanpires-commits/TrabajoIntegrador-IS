namespace WindowsFormsApp4.Negocio
{
    partial class FrmMisReservas
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
            this.dgvMisReservas = new Krypton.Toolkit.KryptonDataGridView();
            this.btnVerPase = new Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMisReservas)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMisReservas
            // 
            this.dgvMisReservas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMisReservas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMisReservas.Location = new System.Drawing.Point(0, 12);
            this.dgvMisReservas.Name = "dgvMisReservas";
            this.dgvMisReservas.Size = new System.Drawing.Size(788, 279);
            this.dgvMisReservas.TabIndex = 0;
            // 
            // btnVerPase
            // 
            this.btnVerPase.Location = new System.Drawing.Point(541, 297);
            this.btnVerPase.Name = "btnVerPase";
            this.btnVerPase.Size = new System.Drawing.Size(90, 25);
            this.btnVerPase.TabIndex = 1;
            this.btnVerPase.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btnVerPase.Values.Text = "btnVerPase";
            // 
            // FrmMisReservas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnVerPase);
            this.Controls.Add(this.dgvMisReservas);
            this.Name = "FrmMisReservas";
            this.Text = "FrmMisReservas";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMisReservas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.KryptonDataGridView dgvMisReservas;
        private Krypton.Toolkit.KryptonButton btnVerPase;
    }
}