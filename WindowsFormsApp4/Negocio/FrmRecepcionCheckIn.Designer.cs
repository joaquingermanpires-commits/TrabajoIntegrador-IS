namespace WindowsFormsApp4.Negocio
{
    partial class FrmRecepcionCheckIn
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
            this.components = new System.ComponentModel.Container();
            this.txtCodigoIngreso = new Krypton.Toolkit.KryptonTextBox();
            this.btnValidar = new Krypton.Toolkit.KryptonButton();
            this.btnInterruptorAuto = new Krypton.Toolkit.KryptonButton();
            this.btnAuditarManual = new Krypton.Toolkit.KryptonButton();
            this.timerAuditoria = new System.Windows.Forms.Timer(this.components);
            this.lstLog = new Krypton.Toolkit.KryptonRichTextBox();
            this.lblMesa = new Krypton.Toolkit.KryptonLabel();
            this.SuspendLayout();
            // 
            // txtCodigoIngreso
            // 
            this.txtCodigoIngreso.Location = new System.Drawing.Point(35, 294);
            this.txtCodigoIngreso.Name = "txtCodigoIngreso";
            this.txtCodigoIngreso.Size = new System.Drawing.Size(146, 23);
            this.txtCodigoIngreso.TabIndex = 0;
            this.txtCodigoIngreso.Text = "kryptonTextBox1";
            // 
            // btnValidar
            // 
            this.btnValidar.Location = new System.Drawing.Point(210, 294);
            this.btnValidar.Name = "btnValidar";
            this.btnValidar.Size = new System.Drawing.Size(90, 25);
            this.btnValidar.TabIndex = 1;
            this.btnValidar.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btnValidar.Values.Text = "kryptonButton1";
            this.btnValidar.Click += new System.EventHandler(this.btnValidar_Click);
            // 
            // btnInterruptorAuto
            // 
            this.btnInterruptorAuto.Location = new System.Drawing.Point(454, 32);
            this.btnInterruptorAuto.Name = "btnInterruptorAuto";
            this.btnInterruptorAuto.Size = new System.Drawing.Size(90, 25);
            this.btnInterruptorAuto.TabIndex = 2;
            this.btnInterruptorAuto.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btnInterruptorAuto.Values.Text = "kryptonButton1";
            this.btnInterruptorAuto.Click += new System.EventHandler(this.btnInterruptorAuto_Click);
            // 
            // btnAuditarManual
            // 
            this.btnAuditarManual.Location = new System.Drawing.Point(454, 139);
            this.btnAuditarManual.Name = "btnAuditarManual";
            this.btnAuditarManual.Size = new System.Drawing.Size(90, 25);
            this.btnAuditarManual.TabIndex = 3;
            this.btnAuditarManual.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btnAuditarManual.Values.Text = "kryptonButton1";
            this.btnAuditarManual.Click += new System.EventHandler(this.btnAuditarManual_Click);
            // 
            // timerAuditoria
            // 
            this.timerAuditoria.Interval = 60000;
            // 
            // lstLog
            // 
            this.lstLog.Location = new System.Drawing.Point(12, 32);
            this.lstLog.Name = "lstLog";
            this.lstLog.Size = new System.Drawing.Size(436, 132);
            this.lstLog.TabIndex = 4;
            this.lstLog.Text = "kryptonRichTextBox1";
            // 
            // lblMesa
            // 
            this.lblMesa.Location = new System.Drawing.Point(61, 372);
            this.lblMesa.Name = "lblMesa";
            this.lblMesa.Size = new System.Drawing.Size(90, 25);
            this.lblMesa.TabIndex = 6;
            this.lblMesa.Values.Text = "kryptonLabel1";
            // 
            // FrmRecepcionCheckIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblMesa);
            this.Controls.Add(this.lstLog);
            this.Controls.Add(this.btnAuditarManual);
            this.Controls.Add(this.btnInterruptorAuto);
            this.Controls.Add(this.btnValidar);
            this.Controls.Add(this.txtCodigoIngreso);
            this.Name = "FrmRecepcionCheckIn";
            this.Text = "FrmRecepcionCheckIn";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Krypton.Toolkit.KryptonTextBox txtCodigoIngreso;
        private Krypton.Toolkit.KryptonButton btnValidar;
        private Krypton.Toolkit.KryptonButton btnInterruptorAuto;
        private Krypton.Toolkit.KryptonButton btnAuditarManual;
        private System.Windows.Forms.Timer timerAuditoria;
        private Krypton.Toolkit.KryptonRichTextBox lstLog;
        private Krypton.Toolkit.KryptonLabel lblMesa;
    }
}