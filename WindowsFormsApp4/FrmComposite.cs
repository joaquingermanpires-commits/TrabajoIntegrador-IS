using ABS;
using BE;
using BLL;
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
    public partial class FrmComposite: Form, IObservadorIdioma
    {
        private UsuarioBLL usuarioBLL;
        public FrmComposite()
        {
            InitializeComponent();
            usuarioBLL = new UsuarioBLL();
            IdiomaBLL.GetInstance().Suscribir(this);
        }

        private void FrmComposite_Load(object sender, EventArgs e)
        {
            CargarArbolesBase();
        }
        private void CargarArbolesBase()
        {
            tvPermisos.Nodes.Clear();
            lbFamilia.Items.Clear();
            lbPatente.Items.Clear();
            List<Familia> familiasCompletas = PermisoBLL.GetInstance().ObtenerFamiliasCompletas();
            foreach (Familia f in familiasCompletas)
            {
                TreeNode nodoRaiz = new TreeNode(f.Nombre);
                nodoRaiz.Tag = f;
                LlenarNodos(nodoRaiz, f);
                tvPermisos.Nodes.Add(nodoRaiz);
            }
            tvPermisos.ExpandAll();
            List<Familia> solofamilia = PermisoBLL.GetInstance().ObtenerFamiliasCompletas();
        }
        private void LlenarNodos(TreeNode nodoPadre, Permiso permisoPadre)
        {
            foreach (Permiso hijo in permisoPadre.ObtenerHijos())
            {
                TreeNode nodoHijo = new TreeNode(hijo.Nombre);
                nodoHijo.Tag = hijo;
                nodoPadre.Nodes.Add(nodoHijo);

                if (hijo is Familia)
                {
                    LlenarNodos(nodoHijo, hijo);
                }
            }
        }
        public void ActualizarIdioma()
        {
            var traducciones = IdiomaBLL.GetInstance().ObtenerTraducciones();

            if (this.Tag != null && !string.IsNullOrWhiteSpace(this.Tag.ToString()))
            {
                string claveTagFormulario = this.Tag.ToString();
                if (traducciones.ContainsKey(claveTagFormulario)) this.Text = traducciones[claveTagFormulario];
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
                    if (traducciones.ContainsKey(claveTag)) c.Text = traducciones[claveTag];
                }

                if (c.Controls.Count > 0) TraducirControles(c.Controls, traducciones);
            }
        }
        private void FrmPermisos_FormClosed(object sender, FormClosedEventArgs e)
        {
            IdiomaBLL.GetInstance().Desuscribir(this);
        }


    }
}
