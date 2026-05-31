namespace WindowsFormsApp4
{
    partial class FrmBackup
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
            this.gbBackup = new System.Windows.Forms.GroupBox();
            this.btnBackup = new System.Windows.Forms.Button();
            this.gbRestore = new System.Windows.Forms.GroupBox();
            this.btnRestore = new System.Windows.Forms.Button();
            this.gbBackup.SuspendLayout();
            this.gbRestore.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbBackup
            // 
            this.gbBackup.Controls.Add(this.btnBackup);
            this.gbBackup.Location = new System.Drawing.Point(25, 23);
            this.gbBackup.Name = "gbBackup";
            this.gbBackup.Size = new System.Drawing.Size(209, 104);
            this.gbBackup.TabIndex = 0;
            this.gbBackup.TabStop = false;
            this.gbBackup.Tag = "gbBackup";
            this.gbBackup.Text = "gbBackup";
            // 
            // btnBackup
            // 
            this.btnBackup.Location = new System.Drawing.Point(6, 71);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(130, 23);
            this.btnBackup.TabIndex = 2;
            this.btnBackup.Tag = "btnBackup";
            this.btnBackup.Text = "btnBackup";
            this.btnBackup.UseVisualStyleBackColor = true;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // gbRestore
            // 
            this.gbRestore.Controls.Add(this.btnRestore);
            this.gbRestore.Location = new System.Drawing.Point(296, 23);
            this.gbRestore.Name = "gbRestore";
            this.gbRestore.Size = new System.Drawing.Size(200, 104);
            this.gbRestore.TabIndex = 1;
            this.gbRestore.TabStop = false;
            this.gbRestore.Tag = "gbRestore";
            this.gbRestore.Text = "gbRestore";
            // 
            // btnRestore
            // 
            this.btnRestore.Location = new System.Drawing.Point(6, 71);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(144, 23);
            this.btnRestore.TabIndex = 3;
            this.btnRestore.Tag = "btnRestore";
            this.btnRestore.Text = "btnRestore";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // FrmBackup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 154);
            this.Controls.Add(this.gbRestore);
            this.Controls.Add(this.gbBackup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmBackup";
            this.Text = "FrmBackup";
            this.gbBackup.ResumeLayout(false);
            this.gbRestore.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbBackup;
        private System.Windows.Forms.GroupBox gbRestore;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.Button btnRestore;
    }
}