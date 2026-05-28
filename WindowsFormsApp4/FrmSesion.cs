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
            lblSesionB.Text = Singleton.GetInstance().GetUsuario();
            IdiomaBLL.GetInstance().Suscribir(this);
        }
        private void btnidioma_Click(object sender, EventArgs e)
        {
            var idiomaActual = IdiomaBLL.GetInstance().IdiomaActivo;
            var todosLosIdiomas = IdiomaBLL.GetInstance().ObtenerIdiomasDisponibles();
            var nuevoIdioma = todosLosIdiomas.Find(i => i.ID_Idioma != idiomaActual.ID_Idioma);
            if (nuevoIdioma != null)
            {
                IdiomaBLL.GetInstance().CambiarIdioma(nuevoIdioma);
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
                if (c is MenuStrip menu)
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
        private void FrmSesion_FormClosed(object sender, FormClosedEventArgs e)
        {
            IdiomaBLL.GetInstance().Desuscribir(this);
        }
    }
}
