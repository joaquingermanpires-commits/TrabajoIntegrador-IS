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
            CargarComboIdiomas();
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
        //Cambiar Idioma
        private void CargarComboIdiomas()
        {
            var idiomasDisponibles = IdiomaBLL.GetInstance().ObtenerIdiomasDisponibles();
            cmbIdiomas.SelectedIndexChanged -= cmbIdiomas_SelectedIndexChanged;
            cmbIdiomas.DataSource = idiomasDisponibles;
            cmbIdiomas.DisplayMember = "Nombre";
            cmbIdiomas.ValueMember = "ID_Idioma";
            // Sincronizamos el combo con el idioma que el sistema tiene activo actualmente
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
                    try
                    {
                        long idUsuarioLogueado = Singleton.GetInstance().GetIdUsuario();
                        if (idUsuarioLogueado > 0)
                        {
                            UsuarioBLL usuarioBLL = UsuarioBLL.GetInstance();
                            usuarioBLL.ActualizarIdiomaPreferido(idUsuarioLogueado, idiomaSeleccionado);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("El idioma se cambió correctamente, pero hubo un error al guardar su preferencia: " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }
    }
}
