namespace WindowsFormsApp4
{
    partial class FrmHistorial
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
            this.dgvHistorial = new System.Windows.Forms.DataGridView();
            this.txtValorViejo = new System.Windows.Forms.TextBox();
            this.txtValorActual = new System.Windows.Forms.TextBox();
            this.btnRestablecer = new System.Windows.Forms.Button();
            this.lblVant = new System.Windows.Forms.Label();
            this.lblVact = new System.Windows.Forms.Label();
            this.lblHistorial = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvHistorial
            // 
            this.dgvHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorial.Location = new System.Drawing.Point(12, 21);
            this.dgvHistorial.Name = "dgvHistorial";
            this.dgvHistorial.Size = new System.Drawing.Size(642, 150);
            this.dgvHistorial.TabIndex = 0;
            this.dgvHistorial.SelectionChanged += new System.EventHandler(this.dgvHistorial_SelectionChanged);
            // 
            // txtValorViejo
            // 
            this.txtValorViejo.Location = new System.Drawing.Point(12, 218);
            this.txtValorViejo.Name = "txtValorViejo";
            this.txtValorViejo.Size = new System.Drawing.Size(192, 20);
            this.txtValorViejo.TabIndex = 1;
            // 
            // txtValorActual
            // 
            this.txtValorActual.Location = new System.Drawing.Point(279, 218);
            this.txtValorActual.Name = "txtValorActual";
            this.txtValorActual.Size = new System.Drawing.Size(192, 20);
            this.txtValorActual.TabIndex = 2;
            // 
            // btnRestablecer
            // 
            this.btnRestablecer.Location = new System.Drawing.Point(531, 214);
            this.btnRestablecer.Name = "btnRestablecer";
            this.btnRestablecer.Size = new System.Drawing.Size(123, 23);
            this.btnRestablecer.TabIndex = 3;
            this.btnRestablecer.Tag = "btnRestablecer";
            this.btnRestablecer.Text = "-";
            this.btnRestablecer.UseVisualStyleBackColor = true;
            this.btnRestablecer.Click += new System.EventHandler(this.btnRestablecer_Click);
            // 
            // lblVant
            // 
            this.lblVant.AutoSize = true;
            this.lblVant.Location = new System.Drawing.Point(12, 199);
            this.lblVant.Name = "lblVant";
            this.lblVant.Size = new System.Drawing.Size(10, 13);
            this.lblVant.TabIndex = 4;
            this.lblVant.Tag = "lblVant";
            this.lblVant.Text = "-";
            // 
            // lblVact
            // 
            this.lblVact.AutoSize = true;
            this.lblVact.Location = new System.Drawing.Point(279, 199);
            this.lblVact.Name = "lblVact";
            this.lblVact.Size = new System.Drawing.Size(10, 13);
            this.lblVact.TabIndex = 5;
            this.lblVact.Tag = "lblVact";
            this.lblVact.Text = "-";
            // 
            // lblHistorial
            // 
            this.lblHistorial.AutoSize = true;
            this.lblHistorial.Location = new System.Drawing.Point(12, 5);
            this.lblHistorial.Name = "lblHistorial";
            this.lblHistorial.Size = new System.Drawing.Size(10, 13);
            this.lblHistorial.TabIndex = 6;
            this.lblHistorial.Tag = "lblHistorial";
            this.lblHistorial.Text = "-";
            // 
            // FrmHistorial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 252);
            this.Controls.Add(this.lblHistorial);
            this.Controls.Add(this.lblVact);
            this.Controls.Add(this.lblVant);
            this.Controls.Add(this.btnRestablecer);
            this.Controls.Add(this.txtValorActual);
            this.Controls.Add(this.txtValorViejo);
            this.Controls.Add(this.dgvHistorial);
            this.Name = "FrmHistorial";
            this.Tag = "historialTraducciones";
            this.Text = "-";
            this.Load += new System.EventHandler(this.FrmHistorial_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvHistorial;
        private System.Windows.Forms.TextBox txtValorViejo;
        private System.Windows.Forms.TextBox txtValorActual;
        private System.Windows.Forms.Button btnRestablecer;
        private System.Windows.Forms.Label lblVant;
        private System.Windows.Forms.Label lblVact;
        private System.Windows.Forms.Label lblHistorial;
    }
}