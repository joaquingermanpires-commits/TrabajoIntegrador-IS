using ABS;
using BE;
using BLL;
using SERVICIOS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class FrmLogin : Form, IObservadorIdioma
    {
        private UsuarioBLL usuarioBLL;
        public FrmLogin()
        {
            InitializeComponent();
            usuarioBLL = UsuarioBLL.GetInstance();
            IdiomaBLL.GetInstance().Suscribir(this);
            CargarComboIdiomas();
        }
        //btn Log in
        public void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                string Nombre_Usuario = txtUsuario.Text;
                string Contraseña = txtContraseña.Text;
                Usuario usuarioValidado = usuarioBLL.Login(Nombre_Usuario, Contraseña);

                if (usuarioValidado != null)
                {
                    PermisoBLL.GetInstance().CargarPermisosUsuario(usuarioValidado);
                    Singleton.GetInstance().IniciarSesion(usuarioValidado);
                    string nombreLogueado = Singleton.GetInstance().GetUsuario();
                    MessageBox.Show($"¡Bienvenido al sistema, {nombreLogueado}!", "Login Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BitacoraBLL.GetInstance().RegistrarBitacora(Nombre_Usuario, "INFO", "FrmLogin", "Inicio de sesión exitoso.");
                    if (usuarioValidado.IdiomaPreferido != null)
                    {
                        IdiomaBLL.GetInstance().CambiarIdioma(usuarioValidado.IdiomaPreferido);
                    }
                    FrmMenu menuPrincipal = new FrmMenu();
                    menuPrincipal.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.", "Error de Autenticación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    BitacoraBLL.GetInstance().RegistrarBitacora(Nombre_Usuario, "WARNING", "FrmLogin", "Intento de inicio de sesión fallido (Credenciales incorrectas).");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                BitacoraBLL.GetInstance().RegistrarBitacora(txtUsuario.Text, "CRITICAL", "FrmLogin", $"Error del sistema: {ex.Message}");
            }
        }
        //Cambiar Idioma
        private void CargarComboIdiomas()
        {
            var idiomasDisponibles = IdiomaBLL.GetInstance().ObtenerIdiomasDisponibles();
            cmbIdiomas.SelectedIndexChanged -= cmbIdiomas_SelectedIndexChanged;
            cmbIdiomas.DataSource = idiomasDisponibles;
            cmbIdiomas.DisplayMember = "Nombre";
            cmbIdiomas.ValueMember = "ID_Idioma";
            // Dejamos seleccionado el idioma que el sistema tiene por defecto
            var idiomaActual = IdiomaBLL.GetInstance().IdiomaActivo;
            if (idiomaActual != null)
            {
                cmbIdiomas.SelectedValue = idiomaActual.ID_Idioma;
            }
            cmbIdiomas.SelectedIndexChanged += cmbIdiomas_SelectedIndexChanged;
        }
        private void cmbIdiomas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbIdiomas.SelectedItem is IIdioma idiomaSeleccionado)
            {
                if (IdiomaBLL.GetInstance().IdiomaActivo == null || IdiomaBLL.GetInstance().IdiomaActivo.ID_Idioma != idiomaSeleccionado.ID_Idioma)
                {
                    IdiomaBLL.GetInstance().CambiarIdioma(idiomaSeleccionado);
                }
            }
        }
        //Metodos del formulario
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
                if (c.Controls.Count > 0)
                {
                    TraducirControles(c.Controls, traducciones);
                }
            }
        }
        private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            IdiomaBLL.GetInstance().Desuscribir(this);
            Application.Exit();
        }
    }
}
