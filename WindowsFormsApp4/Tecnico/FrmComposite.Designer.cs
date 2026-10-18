namespace WindowsFormsApp4
{
    partial class FrmComposite
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
            this.lbFamilia = new System.Windows.Forms.ListBox();
            this.lbPatente = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.FamiliaTxt = new System.Windows.Forms.TextBox();
            this.btnCrear = new System.Windows.Forms.Button();
            this.BtnFamilia = new System.Windows.Forms.Button();
            this.BtnPatente = new System.Windows.Forms.Button();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.BtnEliminarS = new System.Windows.Forms.Button();
            this.tvPermisos = new System.Windows.Forms.TreeView();
            this.tvFamilia = new System.Windows.Forms.TreeView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnEliminarFamilia = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbFamilia
            // 
            this.lbFamilia.FormattingEnabled = true;
            this.lbFamilia.Location = new System.Drawing.Point(23, 55);
            this.lbFamilia.Name = "lbFamilia";
            this.lbFamilia.Size = new System.Drawing.Size(136, 277);
            this.lbFamilia.TabIndex = 0;
            // 
            // lbPatente
            // 
            this.lbPatente.FormattingEnabled = true;
            this.lbPatente.Location = new System.Drawing.Point(166, 55);
            this.lbPatente.Name = "lbPatente";
            this.lbPatente.Size = new System.Drawing.Size(136, 277);
            this.lbPatente.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 13);
            this.label1.TabIndex = 2;
            this.label1.Tag = "lblFamilia";
            this.label1.Text = "-";
            // 
            // FamiliaTxt
            // 
            this.FamiliaTxt.Location = new System.Drawing.Point(22, 29);
            this.FamiliaTxt.Name = "FamiliaTxt";
            this.FamiliaTxt.Size = new System.Drawing.Size(119, 20);
            this.FamiliaTxt.TabIndex = 3;
            // 
            // btnCrear
            // 
            this.btnCrear.Location = new System.Drawing.Point(148, 27);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(75, 23);
            this.btnCrear.TabIndex = 4;
            this.btnCrear.Tag = "btnAgregar";
            this.btnCrear.Text = "-";
            this.btnCrear.UseVisualStyleBackColor = true;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // BtnFamilia
            // 
            this.BtnFamilia.Location = new System.Drawing.Point(21, 333);
            this.BtnFamilia.Name = "BtnFamilia";
            this.BtnFamilia.Size = new System.Drawing.Size(138, 23);
            this.BtnFamilia.TabIndex = 5;
            this.BtnFamilia.Tag = "btnAgregarF";
            this.BtnFamilia.Text = "-";
            this.BtnFamilia.UseVisualStyleBackColor = true;
            this.BtnFamilia.Click += new System.EventHandler(this.BtnFamilia_Click);
            // 
            // BtnPatente
            // 
            this.BtnPatente.Location = new System.Drawing.Point(166, 333);
            this.BtnPatente.Name = "BtnPatente";
            this.BtnPatente.Size = new System.Drawing.Size(136, 23);
            this.BtnPatente.TabIndex = 6;
            this.BtnPatente.Tag = "btnAgregarP";
            this.BtnPatente.Text = "-";
            this.BtnPatente.UseVisualStyleBackColor = true;
            this.BtnPatente.Click += new System.EventHandler(this.BtnPatente_Click);
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Location = new System.Drawing.Point(645, 344);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(156, 23);
            this.BtnGuardar.TabIndex = 7;
            this.BtnGuardar.Tag = "BtnGuardar";
            this.BtnGuardar.Text = "-";
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // BtnEliminarS
            // 
            this.BtnEliminarS.Location = new System.Drawing.Point(645, 316);
            this.BtnEliminarS.Name = "BtnEliminarS";
            this.BtnEliminarS.Size = new System.Drawing.Size(156, 23);
            this.BtnEliminarS.TabIndex = 8;
            this.BtnEliminarS.Tag = "BtnEliminarS";
            this.BtnEliminarS.Text = "-";
            this.BtnEliminarS.UseVisualStyleBackColor = true;
            this.BtnEliminarS.Click += new System.EventHandler(this.BtnEliminarS_Click);
            // 
            // tvPermisos
            // 
            this.tvPermisos.Location = new System.Drawing.Point(12, 12);
            this.tvPermisos.Name = "tvPermisos";
            this.tvPermisos.Size = new System.Drawing.Size(303, 357);
            this.tvPermisos.TabIndex = 9;
            // 
            // tvFamilia
            // 
            this.tvFamilia.Location = new System.Drawing.Point(645, 12);
            this.tvFamilia.Name = "tvFamilia";
            this.tvFamilia.Size = new System.Drawing.Size(156, 298);
            this.tvFamilia.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnEliminarFamilia);
            this.groupBox1.Controls.Add(this.lbPatente);
            this.groupBox1.Controls.Add(this.lbFamilia);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.FamiliaTxt);
            this.groupBox1.Controls.Add(this.btnCrear);
            this.groupBox1.Controls.Add(this.BtnPatente);
            this.groupBox1.Controls.Add(this.BtnFamilia);
            this.groupBox1.Location = new System.Drawing.Point(321, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(308, 362);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // BtnEliminarFamilia
            // 
            this.BtnEliminarFamilia.Location = new System.Drawing.Point(227, 27);
            this.BtnEliminarFamilia.Name = "BtnEliminarFamilia";
            this.BtnEliminarFamilia.Size = new System.Drawing.Size(75, 23);
            this.BtnEliminarFamilia.TabIndex = 12;
            this.BtnEliminarFamilia.Tag = "btnEliminar";
            this.BtnEliminarFamilia.Text = "-";
            this.BtnEliminarFamilia.UseVisualStyleBackColor = true;
            this.BtnEliminarFamilia.Click += new System.EventHandler(this.BtnEliminarFamilia_Click);
            // 
            // FrmComposite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 381);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tvFamilia);
            this.Controls.Add(this.tvPermisos);
            this.Controls.Add(this.BtnEliminarS);
            this.Controls.Add(this.BtnGuardar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmComposite";
            this.Tag = "FrmComposite";
            this.Text = "-";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmPermisos_FormClosed);
            this.Load += new System.EventHandler(this.FrmComposite_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbFamilia;
        private System.Windows.Forms.ListBox lbPatente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox FamiliaTxt;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.Button BtnFamilia;
        private System.Windows.Forms.Button BtnPatente;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.Button BtnEliminarS;
        private System.Windows.Forms.TreeView tvPermisos;
        private System.Windows.Forms.TreeView tvFamilia;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BtnEliminarFamilia;
    }
}