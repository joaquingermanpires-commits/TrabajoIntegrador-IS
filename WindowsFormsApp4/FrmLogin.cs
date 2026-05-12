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

        public void ActualizarIdioma(IIdioma idioma)
        {
            var traducciones = IdiomaBLL.GetInstance().ObtenerTraducciones();

            // Le pasamos la lista de traducciones y todos los controles del formulario al método recursivo
            TraducirControles(this.Controls, traducciones);
        }

        // 2. El método recursivo
        private void TraducirControles(Control.ControlCollection controles, Dictionary<string, string> traducciones)
        {
            foreach (Control c in controles)
            {
                // 1. Verificamos que el control tenga algo escrito en su propiedad Tag
                if (c.Tag != null && !string.IsNullOrWhiteSpace(c.Tag.ToString()))
                {
                    // Convertimos el Tag a string para usarlo como llave
                    string claveTag = c.Tag.ToString();

                    // 2. Si esa llave existe en la base de datos, lo traducimos
                    if (traducciones.ContainsKey(claveTag))
                    {
                        c.Text = traducciones[claveTag];
                    }
                }

                // 3. La recursividad se mantiene idéntica para buscar dentro de los Paneles
                if (c.Controls.Count > 0)
                {
                    TraducirControles(c.Controls, traducciones);
                }
            }
        }
        private void FrmLogin_Load(object sender, EventArgs e) { }

        private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            IdiomaBLL.GetInstance().Desuscribir(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var idiomaActual = IdiomaBLL.GetInstance().IdiomaActivo;

            // 2. Traemos la lista completa de idiomas disponibles (Español, Inglés)
            var todosLosIdiomas = IdiomaBLL.GetInstance().ObtenerIdiomasDisponibles();

            // 3. Usamos LINQ para buscar el primer idioma cuyo ID sea DIFERENTE al ID del idioma actual
            var nuevoIdioma = todosLosIdiomas.Find(i => i.ID_Idioma != idiomaActual.ID_Idioma);

            // 4. Si encontró el "otro" idioma, le decimos al gestor que haga el cambio
            if (nuevoIdioma != null)
            {
                IdiomaBLL.GetInstance().CambiarIdioma(nuevoIdioma);
            }
        }
    }
}
