using System;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void gestiónDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {

            AbrirFormulario<FrmGestion>();
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Frmlogout>();
        }

        public void AbrirFormulario<T>() where T : Form, new()
        {
            //se busca que no se instancie 2 veces el mismo formulario
            foreach (Form formularioAbierto in this.MdiChildren)
            {
                if (formularioAbierto is T)
                {
                    formularioAbierto.Activate();
                    return;
                }
            }

            //Si no lo encuentra en el bucle se crea uno
            T nuevoFormulario = new T();
            nuevoFormulario.MdiParent = this;
            nuevoFormulario.Show();
        }
    }
}
