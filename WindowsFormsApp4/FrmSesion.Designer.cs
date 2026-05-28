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
            this.lblSesionA = new System.Windows.Forms.Label();
            this.lblSesionB = new System.Windows.Forms.Label();
            this.lblidioma = new System.Windows.Forms.Label();
            this.cmbIdiomas = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblSesionA
            // 
            this.lblSesionA.AutoSize = true;
            this.lblSesionA.Location = new System.Drawing.Point(40, 32);
            this.lblSesionA.Name = "lblSesionA";
            this.lblSesionA.Size = new System.Drawing.Size(110, 13);
            this.lblSesionA.TabIndex = 1;
            this.lblSesionA.Tag = "lblSesionA";
            this.lblSesionA.Text = "Sesion iniciada como:";
            // 
            // lblSesionB
            // 
            this.lblSesionB.AutoSize = true;
            this.lblSesionB.Location = new System.Drawing.Point(172, 32);
            this.lblSesionB.Name = "lblSesionB";
            this.lblSesionB.Size = new System.Drawing.Size(10, 13);
            this.lblSesionB.TabIndex = 2;
            this.lblSesionB.Tag = "lblSesionB";
            this.lblSesionB.Text = "-";
            // 
            // lblidioma
            // 
            this.lblidioma.AutoSize = true;
            this.lblidioma.Location = new System.Drawing.Point(40, 82);
            this.lblidioma.Name = "lblidioma";
            this.lblidioma.Size = new System.Drawing.Size(112, 13);
            this.lblidioma.TabIndex = 3;
            this.lblidioma.Tag = "lblidioma";
            this.lblidioma.Text = "Idiona actual: Español";
            // 
            // cmbIdiomas
            // 
            this.cmbIdiomas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIdiomas.FormattingEnabled = true;
            this.cmbIdiomas.Location = new System.Drawing.Point(175, 79);
            this.cmbIdiomas.Name = "cmbIdiomas";
            this.cmbIdiomas.Size = new System.Drawing.Size(121, 21);
            this.cmbIdiomas.TabIndex = 4;
            this.cmbIdiomas.SelectedIndexChanged += new System.EventHandler(this.cmbIdiomas_SelectedIndexChanged);
            // 
            // FrmSesion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 154);
            this.Controls.Add(this.cmbIdiomas);
            this.Controls.Add(this.lblidioma);
            this.Controls.Add(this.lblSesionB);
            this.Controls.Add(this.lblSesionA);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmSesion";
            this.Tag = "Sesion";
            this.Text = "Sesion";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmSesion_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblSesionA;
        private System.Windows.Forms.Label lblSesionB;
        private System.Windows.Forms.Label lblidioma;
        private System.Windows.Forms.ComboBox cmbIdiomas;
    }
}