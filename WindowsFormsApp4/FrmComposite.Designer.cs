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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.BtnFamilia = new System.Windows.Forms.Button();
            this.BtnPatente = new System.Windows.Forms.Button();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.BtnEliminarS = new System.Windows.Forms.Button();
            this.tvPermisos = new System.Windows.Forms.TreeView();
            this.treeView2 = new System.Windows.Forms.TreeView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbFamilia
            // 
            this.lbFamilia.FormattingEnabled = true;
            this.lbFamilia.Location = new System.Drawing.Point(22, 55);
            this.lbFamilia.Name = "lbFamilia";
            this.lbFamilia.Size = new System.Drawing.Size(120, 147);
            this.lbFamilia.TabIndex = 0;
            // 
            // lbPatente
            // 
            this.lbPatente.FormattingEnabled = true;
            this.lbPatente.Location = new System.Drawing.Point(148, 55);
            this.lbPatente.Name = "lbPatente";
            this.lbPatente.Size = new System.Drawing.Size(120, 147);
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
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(22, 29);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(119, 20);
            this.textBox1.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(148, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Tag = "btnAgregar";
            this.button1.Text = "-";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // BtnFamilia
            // 
            this.BtnFamilia.Location = new System.Drawing.Point(22, 212);
            this.BtnFamilia.Name = "BtnFamilia";
            this.BtnFamilia.Size = new System.Drawing.Size(120, 23);
            this.BtnFamilia.TabIndex = 5;
            this.BtnFamilia.Tag = "btnAgregarF";
            this.BtnFamilia.Text = "-";
            this.BtnFamilia.UseVisualStyleBackColor = true;
            // 
            // BtnPatente
            // 
            this.BtnPatente.Location = new System.Drawing.Point(148, 212);
            this.BtnPatente.Name = "BtnPatente";
            this.BtnPatente.Size = new System.Drawing.Size(120, 23);
            this.BtnPatente.TabIndex = 6;
            this.BtnPatente.Tag = "btnAgregarP";
            this.BtnPatente.Text = "-";
            this.BtnPatente.UseVisualStyleBackColor = true;
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Location = new System.Drawing.Point(629, 223);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(156, 23);
            this.BtnGuardar.TabIndex = 7;
            this.BtnGuardar.Tag = "BtnGuardar";
            this.BtnGuardar.Text = "-";
            this.BtnGuardar.UseVisualStyleBackColor = true;
            // 
            // BtnEliminarS
            // 
            this.BtnEliminarS.Location = new System.Drawing.Point(629, 195);
            this.BtnEliminarS.Name = "BtnEliminarS";
            this.BtnEliminarS.Size = new System.Drawing.Size(156, 23);
            this.BtnEliminarS.TabIndex = 8;
            this.BtnEliminarS.Tag = "BtnEliminarS";
            this.BtnEliminarS.Text = "-";
            this.BtnEliminarS.UseVisualStyleBackColor = true;
            // 
            // tvPermisos
            // 
            this.tvPermisos.Location = new System.Drawing.Point(12, 12);
            this.tvPermisos.Name = "tvPermisos";
            this.tvPermisos.Size = new System.Drawing.Size(303, 234);
            this.tvPermisos.TabIndex = 9;
            // 
            // treeView2
            // 
            this.treeView2.Location = new System.Drawing.Point(629, 13);
            this.treeView2.Name = "treeView2";
            this.treeView2.Size = new System.Drawing.Size(156, 176);
            this.treeView2.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbPatente);
            this.groupBox1.Controls.Add(this.lbFamilia);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.BtnPatente);
            this.groupBox1.Controls.Add(this.BtnFamilia);
            this.groupBox1.Location = new System.Drawing.Point(321, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(289, 241);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // FrmComposite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 258);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.treeView2);
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
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button BtnFamilia;
        private System.Windows.Forms.Button BtnPatente;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.Button BtnEliminarS;
        private System.Windows.Forms.TreeView tvPermisos;
        private System.Windows.Forms.TreeView treeView2;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}