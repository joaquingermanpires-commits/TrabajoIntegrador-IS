using ABS;
using BE;
using BLL;
using SERVICIOS;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WindowsFormsApp4.Negocio;

namespace WindowsFormsApp4
{
    public partial class FrmMenu : Form, IObserver, IObservadorIdioma
    {
        public FrmMenu()
        {
            InitializeComponent();
            Singleton.GetInstance().Suscribir(this);
            IdiomaBLL.GetInstance().Suscribir(this);
        }
        private void Menu_Load(object sender, EventArgs e)
        {
            AplicarSeguridad();
        }
        public void ActualizarEstadoSesion()
        {
            string nombreUsuario = Singleton.GetInstance().GetUsuario();

            if (nombreUsuario != null)
            {
                this.Text = "Sistema de Gestión - Sesión iniciada por: " + nombreUsuario;
            }
            AplicarSeguridad();
        }
        //Permisos
        private void AplicarSeguridad()
        {
            Usuario usuarioLogueado = Singleton.GetInstance().GetUsuarioActual();
            bool tieneUsuario = usuarioLogueado != null;
            compositeToolStripMenuItem.Visible = tieneUsuario && PermisoBLL.GetInstance().VerificarPermiso(usuarioLogueado, "MenuComposite");
            bitacoraToolStripMenuItem.Visible = tieneUsuario && PermisoBLL.GetInstance().VerificarPermiso(usuarioLogueado, "MenuBitacora");
            backUpToolStripMenuItem.Visible = tieneUsuario && PermisoBLL.GetInstance().VerificarPermiso(usuarioLogueado, "MenuBackup");
            permisosToolStripMenuItem.Visible = tieneUsuario && PermisoBLL.GetInstance().VerificarPermiso(usuarioLogueado, "MenuPermisos");
            gestiónDeUsuariosToolStripMenuItem.Visible = tieneUsuario && PermisoBLL.GetInstance().VerificarPermiso(usuarioLogueado, "MenuUsuarios");
            idiomasToolStripMenuItem.Visible = tieneUsuario && PermisoBLL.GetInstance().VerificarPermiso(usuarioLogueado, "MenuIdiomas");
            gestiónDeRestaurantesToolStripMenuItem.Visible = tieneUsuario && PermisoBLL.GetInstance().VerificarPermiso(usuarioLogueado, "MenuRestaurantes");
            buscadorRestaurantesToolStripMenuItem.Visible = tieneUsuario && PermisoBLL.GetInstance().VerificarPermiso(usuarioLogueado, "MenuBuscadorRestaurantes");
            historialTraduccionesToolStripMenuItem.Visible = tieneUsuario && PermisoBLL.GetInstance().VerificarPermiso(usuarioLogueado, "Menu");
            gestionMesasToolStripMenuItem.Visible = tieneUsuario && PermisoBLL.GetInstance().VerificarPermiso(usuarioLogueado, "MenuGestionMesas");
            configuracionLocalToolStripMenuItem.Visible = tieneUsuario && PermisoBLL.GetInstance().VerificarPermiso(usuarioLogueado, "MenuConfiguracionLocal");
            altaEventosToolStripMenuItem.Visible = tieneUsuario && PermisoBLL.GetInstance().VerificarPermiso(usuarioLogueado, "MenuAltaEvento");
            //misReservasToolStripMenuItem.Visible = tieneUsuario && PermisoBLL.GetInstance().VerificarPermiso(usuarioLogueado, "MenuMisReservas");
            //recepcionToolStripMenuItem.Visible = tieneUsuario && PermisoBLL.GetInstance().VerificarPermiso(usuarioLogueado, "MenuRecepcion");
        }
        //Controles ToolStripMenu
        private void gestiónDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FrmGestion>();
        }
        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Frmlogout>();
        }
        private void informacionDeLaSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FrmSesion>();
        }
        private void idiomasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FrmIdiomas>();
        }
        private void bitacoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBitacora frmBitacora = new FrmBitacora();
            frmBitacora.StartPosition = FormStartPosition.CenterScreen;
            frmBitacora.ShowDialog();
        }
        private void backUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FrmBackup>();
        }
        private void permisosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FrmPermisos>();
        }
        private void compositeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FrmComposite>();
        }
        private void historialTraduccionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FrmHistorial>();
        }
        private void gestiónDeRestaurantesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FrmRestaurantes>();
        }
        private void buscadorRestaurantesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FrmBuscadorRestaurantes>();
        }
        private void gestionMesasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FrmGestionMesas>();
        }
        private void configuracionLocalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FrmConfiguracionLocal>();
        }
        private void altaEventosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FrmAltaEvento>();
        }
        //private void misReservasToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    AbrirFormulario<FrmMisReservas>();
        //}

        //private void recepcionToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    AbrirFormulario<FrmRecepcionCheckIn>();
        //}
        public void AbrirFormulario<T>() where T : Form, new()
        {
            //se busca que no se instancie 2 veces el mismo formulario
            foreach (Form formularioAbierto in this.MdiChildren)
            {
                if (formularioAbierto is T)
                {
                    formularioAbierto.Activate();
                    return;
                }
            }

            //Si no lo encuentra en el bucle se crea uno
            T nuevoFormulario = new T();
            nuevoFormulario.MdiParent = this;
            nuevoFormulario.Show();
        }
        //Metodos del formulario
        private void FrmMenu_FormClosed(object sender, FormClosedEventArgs e) 
        //Al cerrar la aplicacion en FrmLogout ocurria un problema que la aplicacion no se cerraba correctamente pero la depuracion si finalizaba
        {
            IdiomaBLL.GetInstance().Desuscribir(this);
            Singleton.GetInstance().Desuscribir(this);
            Application.Exit();
        }
        public void ActualizarIdioma()
        {
            var traducciones = IdiomaBLL.GetInstance().ObtenerTraducciones();
            TraducirControles(this.Controls, traducciones);
        }
        private void TraducirControles(Control.ControlCollection controles, Dictionary<string, string> traducciones)
        {
            foreach (Control c in controles)
            {
                if (c.Tag != null && !string.IsNullOrWhiteSpace(c.Tag.ToString()))
                {
                    string claveTag = c.Tag.ToString();
                    if (traducciones.ContainsKey(claveTag))
                    {
                        c.Text = traducciones[claveTag];
                    }
                }
                if (c is ToolStrip menu)
                {
                    foreach (ToolStripItem item in menu.Items)
                    {
                        TraducirItemDeMenu(item, traducciones);
                    }
                }
                else if (c.Controls.Count > 0)
                {
                    TraducirControles(c.Controls, traducciones);
                }
            }
        }
        private void TraducirItemDeMenu(ToolStripItem item, Dictionary<string, string> traducciones)
        {
            if (item.Tag != null && !string.IsNullOrWhiteSpace(item.Tag.ToString()))
            {
                string claveTag = item.Tag.ToString();
                if (traducciones.ContainsKey(claveTag))
                {
                    item.Text = traducciones[claveTag];
                }
            }
            if (item is ToolStripMenuItem menuItem && menuItem.DropDownItems.Count > 0)
            {
                foreach (ToolStripItem subItem in menuItem.DropDownItems)
                {
                    TraducirItemDeMenu(subItem, traducciones);
                }
            }
        }
    }
}
