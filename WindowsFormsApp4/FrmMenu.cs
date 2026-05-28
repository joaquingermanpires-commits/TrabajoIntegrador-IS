using ABS;
using BLL;
using SERVICIOS;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

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
        private void Menu_Load(object sender, EventArgs e){}
        public void ActualizarEstadoSesion()
        {
            string nombreUsuario = Singleton.GetInstance().GetUsuario();

            if (nombreUsuario != null)
            {
                this.Text = "Sistema de Gestión - Sesión iniciada por: " + nombreUsuario;

                // 2. Aquí es donde a futuro aplicarás la lógica de Permisos/Roles.
                // Ejemplo conceptual de lo que harás más adelante:
                /*
                if (Singleton.GetInstance().TienePermiso("Administrar_Usuarios"))
                {
                    gestionarUsuariosToolStripMenuItem.Visible = true;
                }
                else
                {
                    gestionarUsuariosToolStripMenuItem.Visible = false;
                }
                */
            }
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
            AbrirFormulario<FrmBitacora>();
        }
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
