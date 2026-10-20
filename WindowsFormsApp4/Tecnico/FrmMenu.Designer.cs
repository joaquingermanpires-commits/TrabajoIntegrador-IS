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
            this.gestiónDeUsuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSesiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informacionDeLaSesionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.idiomasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bitacoraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.permisosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compositeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historialTraduccionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestiónDeRestaurantes = new System.Windows.Forms.MenuStrip();
            this.gestiónDeRestaurantesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buscadorRestaurantesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionMesasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuracionLocalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.altaEventosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestiónDeRestaurantes.SuspendLayout();
            this.SuspendLayout();
            // 
            // gestiónDeUsuariosToolStripMenuItem
            // 
            this.gestiónDeUsuariosToolStripMenuItem.Name = "gestiónDeUsuariosToolStripMenuItem";
            this.gestiónDeUsuariosToolStripMenuItem.Size = new System.Drawing.Size(24, 20);
            this.gestiónDeUsuariosToolStripMenuItem.Tag = "FrmGestion";
            this.gestiónDeUsuariosToolStripMenuItem.Text = "-";
            this.gestiónDeUsuariosToolStripMenuItem.Click += new System.EventHandler(this.gestiónDeUsuariosToolStripMenuItem_Click);
            // 
            // cerrarSesiónToolStripMenuItem
            // 
            this.cerrarSesiónToolStripMenuItem.Name = "cerrarSesiónToolStripMenuItem";
            this.cerrarSesiónToolStripMenuItem.Size = new System.Drawing.Size(24, 20);
            this.cerrarSesiónToolStripMenuItem.Tag = "Frmlogout";
            this.cerrarSesiónToolStripMenuItem.Text = "-";
            this.cerrarSesiónToolStripMenuItem.Click += new System.EventHandler(this.cerrarSesiónToolStripMenuItem_Click);
            // 
            // informacionDeLaSesionToolStripMenuItem
            // 
            this.informacionDeLaSesionToolStripMenuItem.Name = "informacionDeLaSesionToolStripMenuItem";
            this.informacionDeLaSesionToolStripMenuItem.Size = new System.Drawing.Size(24, 20);
            this.informacionDeLaSesionToolStripMenuItem.Tag = "FrmSesion";
            this.informacionDeLaSesionToolStripMenuItem.Text = "-";
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
            this.backUpToolStripMenuItem.Tag = "FrmBackup";
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
            // compositeToolStripMenuItem
            // 
            this.compositeToolStripMenuItem.Name = "compositeToolStripMenuItem";
            this.compositeToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.compositeToolStripMenuItem.Tag = "FrmComposite";
            this.compositeToolStripMenuItem.Text = "Composite";
            this.compositeToolStripMenuItem.Click += new System.EventHandler(this.compositeToolStripMenuItem_Click);
            // 
            // historialTraduccionesToolStripMenuItem
            // 
            this.historialTraduccionesToolStripMenuItem.Name = "historialTraduccionesToolStripMenuItem";
            this.historialTraduccionesToolStripMenuItem.Size = new System.Drawing.Size(24, 20);
            this.historialTraduccionesToolStripMenuItem.Tag = "historialTraducciones";
            this.historialTraduccionesToolStripMenuItem.Text = "-";
            this.historialTraduccionesToolStripMenuItem.Click += new System.EventHandler(this.historialTraduccionesToolStripMenuItem_Click);
            // 
            // gestiónDeRestaurantes
            // 
            this.gestiónDeRestaurantes.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gestiónDeRestaurantes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestiónDeUsuariosToolStripMenuItem,
            this.cerrarSesiónToolStripMenuItem,
            this.informacionDeLaSesionToolStripMenuItem,
            this.idiomasToolStripMenuItem,
            this.bitacoraToolStripMenuItem,
            this.backUpToolStripMenuItem,
            this.permisosToolStripMenuItem,
            this.compositeToolStripMenuItem,
            this.historialTraduccionesToolStripMenuItem,
            this.gestiónDeRestaurantesToolStripMenuItem,
            this.buscadorRestaurantesToolStripMenuItem,
            this.gestionMesasToolStripMenuItem,
            this.configuracionLocalToolStripMenuItem,
            this.altaEventosToolStripMenuItem});
            this.gestiónDeRestaurantes.Location = new System.Drawing.Point(0, 0);
            this.gestiónDeRestaurantes.Name = "gestiónDeRestaurantes";
            this.gestiónDeRestaurantes.Size = new System.Drawing.Size(1144, 24);
            this.gestiónDeRestaurantes.TabIndex = 1;
            this.gestiónDeRestaurantes.Text = "-----------";
            // 
            // gestiónDeRestaurantesToolStripMenuItem
            // 
            this.gestiónDeRestaurantesToolStripMenuItem.Name = "gestiónDeRestaurantesToolStripMenuItem";
            this.gestiónDeRestaurantesToolStripMenuItem.Size = new System.Drawing.Size(139, 20);
            this.gestiónDeRestaurantesToolStripMenuItem.Text = "gestiónDeRestaurantes";
            this.gestiónDeRestaurantesToolStripMenuItem.Click += new System.EventHandler(this.gestiónDeRestaurantesToolStripMenuItem_Click);
            // 
            // buscadorRestaurantesToolStripMenuItem
            // 
            this.buscadorRestaurantesToolStripMenuItem.Name = "buscadorRestaurantesToolStripMenuItem";
            this.buscadorRestaurantesToolStripMenuItem.Size = new System.Drawing.Size(135, 20);
            this.buscadorRestaurantesToolStripMenuItem.Text = "buscadorRestaurantes";
            this.buscadorRestaurantesToolStripMenuItem.Click += new System.EventHandler(this.buscadorRestaurantesToolStripMenuItem_Click);
            // 
            // gestionMesasToolStripMenuItem
            // 
            this.gestionMesasToolStripMenuItem.Name = "gestionMesasToolStripMenuItem";
            this.gestionMesasToolStripMenuItem.Size = new System.Drawing.Size(91, 20);
            this.gestionMesasToolStripMenuItem.Text = "gestionMesas";
            this.gestionMesasToolStripMenuItem.Click += new System.EventHandler(this.gestionMesasToolStripMenuItem_Click);
            // 
            // configuracionLocalToolStripMenuItem
            // 
            this.configuracionLocalToolStripMenuItem.Name = "configuracionLocalToolStripMenuItem";
            this.configuracionLocalToolStripMenuItem.Size = new System.Drawing.Size(121, 20);
            this.configuracionLocalToolStripMenuItem.Text = "configuracionLocal";
            this.configuracionLocalToolStripMenuItem.Click += new System.EventHandler(this.configuracionLocalToolStripMenuItem_Click);
            // 
            // altaEventosToolStripMenuItem
            // 
            this.altaEventosToolStripMenuItem.Name = "altaEventosToolStripMenuItem";
            this.altaEventosToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.altaEventosToolStripMenuItem.Text = "altaEventos";
            this.altaEventosToolStripMenuItem.Click += new System.EventHandler(this.altaEventosToolStripMenuItem_Click);
            // 
            // FrmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1144, 515);
            this.Controls.Add(this.gestiónDeRestaurantes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.HelpButton = true;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.gestiónDeRestaurantes;
            this.Name = "FrmMenu";
            this.Text = "Menu ";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMenu_FormClosed);
            this.Load += new System.EventHandler(this.Menu_Load);
            this.gestiónDeRestaurantes.ResumeLayout(false);
            this.gestiónDeRestaurantes.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem gestiónDeUsuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesiónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informacionDeLaSesionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem idiomasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bitacoraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem permisosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compositeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem historialTraduccionesToolStripMenuItem;
        private System.Windows.Forms.MenuStrip gestiónDeRestaurantes;
        private System.Windows.Forms.ToolStripMenuItem gestiónDeRestaurantesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buscadorRestaurantesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionMesasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuracionLocalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem altaEventosToolStripMenuItem;
    }
}