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
            usuarioBLL = new UsuarioBLL();
            IdiomaBLL.GetInstance().Suscribir(this);
        }
        //btn Log in
        public void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                string Nombre_Usuario = txtUsuario.Text;
                string Contraseña = txtContraseña.Text;

                //  La BLL se encarga de la validación (que incluye el hasheo y llamar a la DAL)
                Usuario usuarioValidado = usuarioBLL.Login(Nombre_Usuario, Contraseña);

                if (usuarioValidado != null)
                {
                    // Uso de Singleton, Guardamos al usuario en la memoria global
                    Singleton.GetInstance().IniciarSesion(usuarioValidado);

                    string nombreLogueado = Singleton.GetInstance().GetUsuario();
                    MessageBox.Show($"¡Bienvenido al sistema, {nombreLogueado}!", "Login Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                }
            }
            catch (Exception ex)
            {
                // Atrapamos cualquier error de la base de datos o validación y lo mostramos
                MessageBox.Show(ex.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //btn Cambiar Idioma
        private void Cambiar_Idioma_click(object sender, EventArgs e)
        {
            var idiomaActual = IdiomaBLL.GetInstance().IdiomaActivo;
            var todosLosIdiomas = IdiomaBLL.GetInstance().ObtenerIdiomasDisponibles();
            var nuevoIdioma = todosLosIdiomas.Find(i => i.ID_Idioma != idiomaActual.ID_Idioma);
            if (nuevoIdioma != null)
            {
                IdiomaBLL.GetInstance().CambiarIdioma(nuevoIdioma);
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
