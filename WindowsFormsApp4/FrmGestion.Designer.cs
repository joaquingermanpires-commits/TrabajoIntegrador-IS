namespace WindowsFormsApp4
{
    partial class FrmGestion
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
            this.dgvu = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnAlta = new System.Windows.Forms.Button();
            this.BtnBaja = new System.Windows.Forms.Button();
            this.BtnModif = new System.Windows.Forms.Button();
            this.inputNombre = new System.Windows.Forms.TextBox();
            this.InputContraseña = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvu)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvu
            // 
            this.dgvu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvu.Location = new System.Drawing.Point(12, 23);
            this.dgvu.Name = "dgvu";
            this.dgvu.Size = new System.Drawing.Size(322, 209);
            this.dgvu.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Usuarios registrados";
            // 
            // BtnAlta
            // 
            this.BtnAlta.Location = new System.Drawing.Point(12, 377);
            this.BtnAlta.Name = "BtnAlta";
            this.BtnAlta.Size = new System.Drawing.Size(75, 35);
            this.BtnAlta.TabIndex = 2;
            this.BtnAlta.Text = "Agregar";
            this.BtnAlta.UseVisualStyleBackColor = true;
            this.BtnAlta.Click += new System.EventHandler(this.BtnAlta_Click);
            // 
            // BtnBaja
            // 
            this.BtnBaja.Location = new System.Drawing.Point(137, 377);
            this.BtnBaja.Name = "BtnBaja";
            this.BtnBaja.Size = new System.Drawing.Size(75, 35);
            this.BtnBaja.TabIndex = 3;
            this.BtnBaja.Text = "Eliminar";
            this.BtnBaja.UseVisualStyleBackColor = true;
            this.BtnBaja.Click += new System.EventHandler(this.BtnBaja_Click);
            // 
            // BtnModif
            // 
            this.BtnModif.Location = new System.Drawing.Point(259, 377);
            this.BtnModif.Name = "BtnModif";
            this.BtnModif.Size = new System.Drawing.Size(75, 35);
            this.BtnModif.TabIndex = 4;
            this.BtnModif.Text = "Modificar";
            this.BtnModif.UseVisualStyleBackColor = true;
            this.BtnModif.Click += new System.EventHandler(this.BtnModif_Click);
            // 
            // inputNombre
            // 
            this.inputNombre.Location = new System.Drawing.Point(12, 279);
            this.inputNombre.Name = "inputNombre";
            this.inputNombre.Size = new System.Drawing.Size(184, 20);
            this.inputNombre.TabIndex = 5;
            // 
            // InputContraseña
            // 
            this.InputContraseña.Location = new System.Drawing.Point(12, 323);
            this.InputContraseña.Name = "InputContraseña";
            this.InputContraseña.Size = new System.Drawing.Size(184, 20);
            this.InputContraseña.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 259);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Nombre de usuario*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 307);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Contraseña*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(9, 235);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(198, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "* indica que los  campos son obligatorios";
            // 
            // FrmGestion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 420);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.InputContraseña);
            this.Controls.Add(this.inputNombre);
            this.Controls.Add(this.BtnModif);
            this.Controls.Add(this.BtnBaja);
            this.Controls.Add(this.BtnAlta);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvu);
            this.Name = "FrmGestion";
            this.Text = "Gestión_de_usuarios";
            ((System.ComponentModel.ISupportInitialize)(this.dgvu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnAlta;
        private System.Windows.Forms.Button BtnBaja;
        private System.Windows.Forms.Button BtnModif;
        private System.Windows.Forms.TextBox inputNombre;
        private System.Windows.Forms.TextBox InputContraseña;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}