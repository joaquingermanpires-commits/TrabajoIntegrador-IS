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
    public partial class FrmSesion : Form, IObservadorIdioma
    {
        public FrmSesion()
        {
            InitializeComponent();
            lblSesionB.Text = nombreLogueado;
            IdiomaBLL.GetInstance().Suscribir(this);
        }
        string nombreLogueado= Singleton.GetInstance().GetUsuario();

        private void btnidioma_Click(object sender, EventArgs e)
        {
            var idiomaActual = IdiomaBLL.GetInstance().IdiomaActivo;
            var todosLosIdiomas = IdiomaBLL.GetInstance().ObtenerIdiomasDisponibles();
            var nuevoIdioma = todosLosIdiomas.Find(i => i.ID_Idioma != idiomaActual.ID_Idioma);
            if (nuevoIdioma != null)
            {
                IdiomaBLL.GetInstance().CambiarIdioma(nuevoIdioma);

                // 2. Traemos quién es el usuario logueado en este momento (Singleton de Sesión)
                long idUsuarioActivo = Singleton.GetInstance().GetIdUsuario();
                UsuarioBLL gestorUsuario = new UsuarioBLL();
                gestorUsuario.ActualizarIdiomaPreferido(idUsuarioActivo, nuevoIdioma);
            }
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
                if (c.Controls.Count > 0)
                {
                    TraducirControles(c.Controls, traducciones);
                }
            }
        }
    }
}
