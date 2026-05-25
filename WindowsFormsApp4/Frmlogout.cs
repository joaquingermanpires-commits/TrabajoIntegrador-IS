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
            usuarioBLL = new UsuarioBLL();
            IdiomaBLL.GetInstance().Suscribir(this);
        }
        public void ActualizarIdioma()
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
        private void Frmlogout_FormClosed(object sender, FormClosedEventArgs e)
        {
            IdiomaBLL.GetInstance().Desuscribir(this);
        }
    }
}

