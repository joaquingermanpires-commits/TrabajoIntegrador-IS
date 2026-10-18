namespace WindowsFormsApp4
{
    partial class FrmPermisos
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
            this.tvPermisos = new System.Windows.Forms.TreeView();
            this.cmbUsuarios = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGuardarPermisos = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tvPermisos
            // 
            this.tvPermisos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvPermisos.CheckBoxes = true;
            this.tvPermisos.Location = new System.Drawing.Point(164, 12);
            this.tvPermisos.Name = "tvPermisos";
            this.tvPermisos.Size = new System.Drawing.Size(617, 331);
            this.tvPermisos.TabIndex = 0;
            this.tvPermisos.Tag = "tvPermisos";
            this.tvPermisos.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvPermisos_AfterCheck);
            // 
            // cmbUsuarios
            // 
            this.cmbUsuarios.FormattingEnabled = true;
            this.cmbUsuarios.Location = new System.Drawing.Point(12, 45);
            this.cmbUsuarios.Name = "cmbUsuarios";
            this.cmbUsuarios.Size = new System.Drawing.Size(121, 21);
            this.cmbUsuarios.TabIndex = 1;
            this.cmbUsuarios.SelectedIndexChanged += new System.EventHandler(this.cmbUsuarios_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 13);
            this.label1.TabIndex = 2;
            this.label1.Tag = "lblUsuario";
            this.label1.Text = "-";
            // 
            // btnGuardarPermisos
            // 
            this.btnGuardarPermisos.Location = new System.Drawing.Point(15, 116);
            this.btnGuardarPermisos.Name = "btnGuardarPermisos";
            this.btnGuardarPermisos.Size = new System.Drawing.Size(118, 23);
            this.btnGuardarPermisos.TabIndex = 3;
            this.btnGuardarPermisos.Tag = "btnModificar";
            this.btnGuardarPermisos.Text = "-";
            this.btnGuardarPermisos.UseVisualStyleBackColor = true;
            this.btnGuardarPermisos.Click += new System.EventHandler(this.btnGuardarPermisos_Click);
            // 
            // FrmPermisos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 364);
            this.Controls.Add(this.btnGuardarPermisos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbUsuarios);
            this.Controls.Add(this.tvPermisos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmPermisos";
            this.Tag = "FrmPermisos";
            this.Text = "-";
            this.Load += new System.EventHandler(this.FrmPermisos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tvPermisos;
        private System.Windows.Forms.ComboBox cmbUsuarios;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGuardarPermisos;
    }
}