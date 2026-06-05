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
    public partial class FrmComposite : Form, IObservadorIdioma
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
            BloquearModoEdicion();
        }
        private void BloquearModoEdicion()
        {
            tvFamilia.Enabled = false;
            BtnPatente.Enabled = false;
            BtnFamilia.Enabled = false;
            BtnEliminarS.Enabled = false;
            BtnGuardar.Enabled = false;
        }
        private void CargarArbolesBase()
        {
            tvPermisos.Nodes.Clear();
            lbFamilia.DataSource = null;
            lbPatente.DataSource = null;
            List<Familia> familiasCompletas = PermisoBLL.GetInstance().ObtenerFamiliasCompletas();
            foreach (Familia f in familiasCompletas)
            {
                TreeNode nodoRaiz = new TreeNode(f.Nombre);
                nodoRaiz.Tag = f;
                LlenarNodos(nodoRaiz, f);
                tvPermisos.Nodes.Add(nodoRaiz);
            }
            tvPermisos.ExpandAll();
            lbPatente.DataSource = PermisoBLL.GetInstance().ObtenerTodasLasPatentes();
            lbPatente.DisplayMember = "Nombre";
            lbFamilia.DataSource = PermisoBLL.GetInstance().ObtenerFamiliasCompletas();
            lbFamilia.DisplayMember = "Nombre";
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
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //Instanciamos la nueva Familia
                Familia nuevaFamilia = new Familia();
                nuevaFamilia.Nombre = FamiliaTxt.Text;
                //Regla de negocio básica para la UI
                if (tvFamilia.Nodes.Count == 0)
                {
                    MessageBox.Show("El carrito está vacío. Agregue permisos a la familia antes de guardar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //Llenamos la familia leyendo los nodos principales de tu TreeView carrito
                foreach (TreeNode nodo in tvFamilia.Nodes)
                {
                    // Extraemos el objeto Permiso (puede ser Patente o Familia) que guardamos en el Tag
                    if (nodo.Tag is Permiso permisoDelCarrito)
                    {
                        nuevaFamilia.AgregarHijo(permisoDelCarrito);
                    }
                }
                PermisoBLL.GetInstance().GuardarNuevaFamilia(nuevaFamilia);
                string usuarioActual = SERVICIOS.Singleton.GetInstance().GetUsuario();
                BitacoraBLL.GetInstance().RegistrarBitacora(usuarioActual, "INFO", "FrmComposite", $"Se creó la familia compuesta: {nuevaFamilia.Nombre}");
                MessageBox.Show("Familia compuesta creada y guardada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpieza de UI
                FamiliaTxt.Clear();
                tvFamilia.Nodes.Clear();
                BloquearModoEdicion();
                CargarArbolesBase();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void BtnPatente_Click(object sender, EventArgs e)
        {
            if (lbPatente.SelectedItem is Patente patenteSeleccionada)
            {
                TreeNode nodoCarrito = new TreeNode(patenteSeleccionada.Nombre);
                nodoCarrito.Tag = patenteSeleccionada;
                tvFamilia.Nodes.Add(nodoCarrito);
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una patente válida de la lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void BtnFamilia_Click(object sender, EventArgs e)
        {
            // Verificamos que haya seleccionado un objeto de tipo Familia en el ListBox
            if (lbFamilia.SelectedItem is Familia familiaSeleccionada)
            {
                TreeNode nodoCarrito = new TreeNode(familiaSeleccionada.Nombre);
                nodoCarrito.Tag = familiaSeleccionada;
                tvFamilia.Nodes.Add(nodoCarrito);
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una familia válida de la lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void BtnEliminarS_Click(object sender, EventArgs e)
        {
            if (tvFamilia.SelectedNode != null)
            {
                tvFamilia.Nodes.Remove(tvFamilia.SelectedNode);
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un elemento del carrito para eliminarlo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnCrear_Click(object sender, EventArgs e)
        {

            // 2. Vaciamos el carrito temporal (asumiendo que usás el TreeView)
            tvFamilia.Nodes.Clear();
            // 3. Habilitamos los controles para que el usuario empiece a trabajar
            btnCrear.Enabled = false;
            tvFamilia.Enabled = true;
            BtnPatente.Enabled = true;
            BtnFamilia.Enabled = true;
            BtnEliminarS.Enabled = true;
            BtnGuardar.Enabled = true;
        }
    }
}
