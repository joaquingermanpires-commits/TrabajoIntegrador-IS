using ABS;
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
    public partial class Frmlogout : Form, IObservadorIdioma
    {
        private UsuarioBLL usuarioBLL;
        public Frmlogout()
        {
            InitializeComponent();
            usuarioBLL = UsuarioBLL.GetInstance();
            IdiomaBLL.GetInstance().Suscribir(this);
        }
        //btn Cerrar sesion
        public void Btnout_Click(object sender, EventArgs e)
        {

            DialogResult resp;
            resp = MessageBox.Show("¿Desea cerrar la sesión?", "Confirmación", MessageBoxButtons.YesNo);
            if (resp == DialogResult.Yes)
            {
                //"Destruimos" la sesión actual usando Singleton
                Singleton.GetInstance().CerrarSesion();
                //reiniciamos la aplicación para que aparezca la pantalla "FrmLogin"
                Application.Restart();
            }
            else
            {
                this.Close();
            }

        }
        //Metodos del formulario
        public void ActualizarIdioma()
        {
            var traducciones = IdiomaBLL.GetInstance().ObtenerTraducciones();
            if (this.Tag != null && !string.IsNullOrWhiteSpace(this.Tag.ToString()))
            {
                string claveTagFormulario = this.Tag.ToString();
                if (traducciones.ContainsKey(claveTagFormulario))
                {
                    this.Text = traducciones[claveTagFormulario];
                }
            }
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
        private void Frmlogout_FormClosed(object sender, FormClosedEventArgs e)
        {
            IdiomaBLL.GetInstance().Desuscribir(this);
        }
    }
}

