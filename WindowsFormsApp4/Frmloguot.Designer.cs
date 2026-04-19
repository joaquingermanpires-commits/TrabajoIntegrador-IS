namespace WindowsFormsApp4
{
    partial class Frmloguot
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
            this.Btnout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Btnout
            // 
            this.Btnout.Location = new System.Drawing.Point(22, 12);
            this.Btnout.Name = "Btnout";
            this.Btnout.Size = new System.Drawing.Size(115, 53);
            this.Btnout.TabIndex = 0;
            this.Btnout.Text = "Cerrar Sesión";
            this.Btnout.UseVisualStyleBackColor = true;
            this.Btnout.Click += new System.EventHandler(this.Btnout_Click);
            // 
            // Frmloguot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(161, 77);
            this.Controls.Add(this.Btnout);
            this.Name = "Frmloguot";
            this.Text = "Frmloguot";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Btnout;
    }
}