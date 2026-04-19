using BLL;
using BE;
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
    public partial class FrmLogin : Form
    {
        private UsuarioBLL usuarioBLL;
        public FrmLogin()
        {
            InitializeComponent();
            usuarioBLL = new UsuarioBLL();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
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

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
