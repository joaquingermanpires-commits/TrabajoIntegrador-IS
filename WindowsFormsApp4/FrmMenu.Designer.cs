namespace WindowsFormsApp4
{
    partial class FrmMenu
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gestiónDeUsuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSesiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informacionDeLaSesionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.idiomasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bitacoraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.permisosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.compositeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestiónDeUsuariosToolStripMenuItem,
            this.cerrarSesiónToolStripMenuItem,
            this.informacionDeLaSesionToolStripMenuItem,
            this.idiomasToolStripMenuItem,
            this.bitacoraToolStripMenuItem,
            this.backUpToolStripMenuItem,
            this.permisosToolStripMenuItem,
            this.compositeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1144, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gestiónDeUsuariosToolStripMenuItem
            // 
            this.gestiónDeUsuariosToolStripMenuItem.Name = "gestiónDeUsuariosToolStripMenuItem";
            this.gestiónDeUsuariosToolStripMenuItem.Size = new System.Drawing.Size(122, 20);
            this.gestiónDeUsuariosToolStripMenuItem.Tag = "FrmGestion";
            this.gestiónDeUsuariosToolStripMenuItem.Text = "Gestión de usuarios";
            this.gestiónDeUsuariosToolStripMenuItem.Click += new System.EventHandler(this.gestiónDeUsuariosToolStripMenuItem_Click);
            // 
            // cerrarSesiónToolStripMenuItem
            // 
            this.cerrarSesiónToolStripMenuItem.Name = "cerrarSesiónToolStripMenuItem";
            this.cerrarSesiónToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.cerrarSesiónToolStripMenuItem.Tag = "Frmlogout";
            this.cerrarSesiónToolStripMenuItem.Text = "Cerrar sesión";
            this.cerrarSesiónToolStripMenuItem.Click += new System.EventHandler(this.cerrarSesiónToolStripMenuItem_Click);
            // 
            // informacionDeLaSesionToolStripMenuItem
            // 
            this.informacionDeLaSesionToolStripMenuItem.Name = "informacionDeLaSesionToolStripMenuItem";
            this.informacionDeLaSesionToolStripMenuItem.Size = new System.Drawing.Size(148, 20);
            this.informacionDeLaSesionToolStripMenuItem.Tag = "FrmSesion";
            this.informacionDeLaSesionToolStripMenuItem.Text = "Informacion de la sesion";
            this.informacionDeLaSesionToolStripMenuItem.Click += new System.EventHandler(this.informacionDeLaSesionToolStripMenuItem_Click);
            // 
            // idiomasToolStripMenuItem
            // 
            this.idiomasToolStripMenuItem.Name = "idiomasToolStripMenuItem";
            this.idiomasToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.idiomasToolStripMenuItem.Tag = "FrmIdiomas";
            this.idiomasToolStripMenuItem.Text = "Idiomas";
            this.idiomasToolStripMenuItem.Click += new System.EventHandler(this.idiomasToolStripMenuItem_Click);
            // 
            // bitacoraToolStripMenuItem
            // 
            this.bitacoraToolStripMenuItem.Name = "bitacoraToolStripMenuItem";
            this.bitacoraToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.bitacoraToolStripMenuItem.Tag = "FrmBitacora";
            this.bitacoraToolStripMenuItem.Text = "Bitacora";
            this.bitacoraToolStripMenuItem.Click += new System.EventHandler(this.bitacoraToolStripMenuItem_Click);
            // 
            // backUpToolStripMenuItem
            // 
            this.backUpToolStripMenuItem.Name = "backUpToolStripMenuItem";
            this.backUpToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.backUpToolStripMenuItem.Text = "BackUp";
            this.backUpToolStripMenuItem.Click += new System.EventHandler(this.backUpToolStripMenuItem_Click);
            // 
            // permisosToolStripMenuItem
            // 
            this.permisosToolStripMenuItem.Name = "permisosToolStripMenuItem";
            this.permisosToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.permisosToolStripMenuItem.Tag = "FrmPermisos";
            this.permisosToolStripMenuItem.Text = "Permisos";
            this.permisosToolStripMenuItem.Click += new System.EventHandler(this.permisosToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // compositeToolStripMenuItem
            // 
            this.compositeToolStripMenuItem.Name = "compositeToolStripMenuItem";
            this.compositeToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.compositeToolStripMenuItem.Tag = "FrmComposite";
            this.compositeToolStripMenuItem.Text = "Composite";
            this.compositeToolStripMenuItem.Click += new System.EventHandler(this.compositeToolStripMenuItem_Click);
            // 
            // FrmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1144, 515);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMenu";
            this.Text = "Menu ";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMenu_FormClosed);
            this.Load += new System.EventHandler(this.Menu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gestiónDeUsuariosToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesiónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informacionDeLaSesionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem idiomasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bitacoraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem permisosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compositeToolStripMenuItem;
    }
}