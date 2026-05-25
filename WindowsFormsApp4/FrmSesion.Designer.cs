namespace WindowsFormsApp4
{
    partial class FrmSesion
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
            this.btnidioma = new System.Windows.Forms.Button();
            this.lblSesionA = new System.Windows.Forms.Label();
            this.lblSesionB = new System.Windows.Forms.Label();
            this.lblidioma = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnidioma
            // 
            this.btnidioma.Location = new System.Drawing.Point(200, 120);
            this.btnidioma.Name = "btnidioma";
            this.btnidioma.Size = new System.Drawing.Size(123, 23);
            this.btnidioma.TabIndex = 0;
            this.btnidioma.Tag = "btnidioma";
            this.btnidioma.Text = "Cambiar idioma";
            this.btnidioma.UseVisualStyleBackColor = true;
            this.btnidioma.Click += new System.EventHandler(this.btnidioma_Click);
            // 
            // lblSesionA
            // 
            this.lblSesionA.AutoSize = true;
            this.lblSesionA.Location = new System.Drawing.Point(65, 59);
            this.lblSesionA.Name = "lblSesionA";
            this.lblSesionA.Size = new System.Drawing.Size(110, 13);
            this.lblSesionA.TabIndex = 1;
            this.lblSesionA.Tag = "lblSesionA";
            this.lblSesionA.Text = "Sesion iniciada como:";
            // 
            // lblSesionB
            // 
            this.lblSesionB.AutoSize = true;
            this.lblSesionB.Location = new System.Drawing.Point(197, 59);
            this.lblSesionB.Name = "lblSesionB";
            this.lblSesionB.Size = new System.Drawing.Size(10, 13);
            this.lblSesionB.TabIndex = 2;
            this.lblSesionB.Tag = "lblSesionB";
            this.lblSesionB.Text = "-";
            // 
            // lblidioma
            // 
            this.lblidioma.AutoSize = true;
            this.lblidioma.Location = new System.Drawing.Point(65, 125);
            this.lblidioma.Name = "lblidioma";
            this.lblidioma.Size = new System.Drawing.Size(112, 13);
            this.lblidioma.TabIndex = 3;
            this.lblidioma.Tag = "lblidioma";
            this.lblidioma.Text = "Idiona actual: Español";
            // 
            // FrmSesion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 184);
            this.Controls.Add(this.lblidioma);
            this.Controls.Add(this.lblSesionB);
            this.Controls.Add(this.lblSesionA);
            this.Controls.Add(this.btnidioma);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmSesion";
            this.Tag = "Sesion";
            this.Text = "Sesion";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmSesion_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnidioma;
        private System.Windows.Forms.Label lblSesionA;
        private System.Windows.Forms.Label lblSesionB;
        private System.Windows.Forms.Label lblidioma;
    }
}