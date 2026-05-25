using ABS;
using BLL;
using SERVICIOS;
using System;
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
                // 1. Actualizamos la interfaz visual con los datos del usuario activo
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
        private void FrmMenu_FormClosed(object sender, FormClosedEventArgs e) 
        //Al reiniciar la aplicacion en FrmLogout ocurria un problema que la aplicacion no se cerraba correctamente pero la depuracion si finalizaba
        {
            IdiomaBLL.GetInstance().Desuscribir(this);
            Singleton.GetInstance().Desuscribir(this);
            Application.Exit();
        }

        public void ActualizarIdioma()
        {
            var traducciones = IdiomaBLL.GetInstance().ObtenerTraducciones();

            // Para los menús principales de arriba (SISTEMA, ADMINISTRACION)
            foreach (ToolStripMenuItem menuPrincipal in menuStrip1.Items)
            {
                if (menuPrincipal.Tag != null && !string.IsNullOrWhiteSpace(menuPrincipal.Tag.ToString()))
                {
                    string claveTag = menuPrincipal.Tag.ToString();
                    if (traducciones.ContainsKey(claveTag))
                        menuPrincipal.Text = traducciones[claveTag];
                }

                // Para los botones desplegables (Alta, Baja, Modificación)
                foreach (ToolStripItem subItem in menuPrincipal.DropDownItems)
                {
                    if (subItem.Tag != null && !string.IsNullOrWhiteSpace(subItem.Tag.ToString()))
                    {
                        string claveTagSub = subItem.Tag.ToString();
                        if (traducciones.ContainsKey(claveTagSub))
                            subItem.Text = traducciones[claveTagSub];
                    }
                }
            }
        }

    }
}
