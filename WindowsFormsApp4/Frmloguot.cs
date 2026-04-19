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
    public partial class Frmloguot : Form
    {
        public Frmloguot()
        {
            InitializeComponent();
        }

        private void Btnout_Click(object sender, EventArgs e)
        {

            DialogResult resp;
                    resp = MessageBox.Show("¿Desea cerrar la sesión?", "Confirmación", MessageBoxButtons.YesNo);
                    if (resp == DialogResult.Yes)
                    {
                    //"Destruimos" la sesión actual usando tu Singleton
                    Singleton.GetInstance().CerrarSesion();

                    //reinicioamos la aplicacion para que aparezca la pantalla "FrmLogin
                    Application.Restart();

            }
                    else
                    {
                    this.Close();
                    }

                
            
        }
    }
}

