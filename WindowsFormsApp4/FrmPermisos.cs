using ABS;
using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class FrmPermisos : Form, IObservadorIdioma
    {
        private UsuarioBLL usuarioBLL;
        private bool actualizandoAutomaticamente = false;
        public FrmPermisos()
        {
            InitializeComponent();
            usuarioBLL = new UsuarioBLL();
            IdiomaBLL.GetInstance().Suscribir(this);
        }
        private void FrmPermisos_Load(object sender, EventArgs e)
        {
            CargarArbolBase();
            CargarUsuarios();
        }
        private void CargarUsuarios()
        {
            cmbUsuarios.SelectedIndexChanged -= cmbUsuarios_SelectedIndexChanged;
            cmbUsuarios.DataSource = usuarioBLL.ObtenerUsuarios();
            cmbUsuarios.DisplayMember = "Nombre_Usuario";
            cmbUsuarios.ValueMember = "ID_Usuario";
            cmbUsuarios.SelectedIndex = -1;
            cmbUsuarios.SelectedIndexChanged += cmbUsuarios_SelectedIndexChanged;
        }
        private void CargarArbolBase()
        {
            tvPermisos.Nodes.Clear();
            List<Familia> familiasCompletas = PermisoBLL.GetInstance().ObtenerFamiliasCompletas();
            foreach (Familia f in familiasCompletas)
            {
                TreeNode nodoRaiz = new TreeNode(f.Nombre);
                nodoRaiz.Tag = f;
                LlenarNodos(nodoRaiz, f);
                tvPermisos.Nodes.Add(nodoRaiz);
            }
            tvPermisos.ExpandAll();
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

        // EVENTO: SELECCIONAR UN USUARIO
        private void cmbUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbUsuarios.SelectedItem is Usuario usuarioSeleccionado)
            {
                PermisoBLL.GetInstance().CargarPermisosUsuario(usuarioSeleccionado);
                actualizandoAutomaticamente = true;
                DesmarcarTodosLosNodos(tvPermisos.Nodes);
                if (usuarioSeleccionado.Permisos != null)
                {
                    MarcarNodosDelUsuario(tvPermisos.Nodes, usuarioSeleccionado.Permisos);
                }
                actualizandoAutomaticamente = false;
                if (usuarioSeleccionado.ID_Usuario == 1 || usuarioSeleccionado.Nombre_Usuario.ToLower() == "admin1")
                {
                    btnGuardarPermisos.Enabled = false;
                    tvPermisos.Enabled = false;
                                               
                }
                else
                {
                    btnGuardarPermisos.Enabled = true;
                    tvPermisos.Enabled = true;
                }
            }
        }
        // LÓGICA DE CHECKBOXES (TILDES)
        private void DesmarcarTodosLosNodos(TreeNodeCollection nodos)
        {
            foreach (TreeNode nodo in nodos)
            {
                nodo.Checked = false;
                if (nodo.Nodes.Count > 0) DesmarcarTodosLosNodos(nodo.Nodes);
            }
        }
        private void MarcarNodosDelUsuario(TreeNodeCollection nodos, List<Permiso> permisosUsuario)
        {
            foreach (TreeNode nodo in nodos)
            {
                Permiso permisoDelNodo = (Permiso)nodo.Tag;
                if (ExistePermisoEnLista(permisoDelNodo, permisosUsuario))
                {
                    nodo.Checked = true;
                }

                if (nodo.Nodes.Count > 0) MarcarNodosDelUsuario(nodo.Nodes, permisosUsuario);
            }
        }
        private bool ExistePermisoEnLista(Permiso permisoBuscado, List<Permiso> lista)
        {
            foreach (var p in lista)
            {
                if (p.ID_Permiso == permisoBuscado.ID_Permiso) return true;
                if (p is Familia f)
                {
                    if (ExistePermisoEnLista(permisoBuscado, new List<Permiso>(f.ObtenerHijos()))) return true;
                }
            }
            return false;
        }
        private void tvPermisos_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (actualizandoAutomaticamente) return;
            actualizandoAutomaticamente = true;
            MarcarHijos(e.Node, e.Node.Checked);
            actualizandoAutomaticamente = false;
        }
        private void MarcarHijos(TreeNode nodoPadre, bool estado)
        {
            foreach (TreeNode nodoHijo in nodoPadre.Nodes)
            {
                nodoHijo.Checked = estado;
                MarcarHijos(nodoHijo, estado);
            }
        }
        // EVENTO: GUARDAR PERMISOS
        private void btnGuardarPermisos_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbUsuarios.SelectedItem is Usuario usuarioSeleccionado)
                {
                    usuarioSeleccionado.Permisos = new List<Permiso>();
                    RecolectarPermisosMarcados(tvPermisos.Nodes, usuarioSeleccionado.Permisos);
                    PermisoBLL.GetInstance().GuardarPermisosUsuario(usuarioSeleccionado);
                    string usuarioActual = SERVICIOS.Singleton.GetInstance().GetUsuario();
                    BitacoraBLL.GetInstance().RegistrarBitacora(usuarioActual, "INFO", "FrmPermisos", $"Se modificaron los permisos del usuario: {usuarioSeleccionado.Nombre_Usuario}");
                    MessageBox.Show("Permisos actualizados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione un usuario de la lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar permisos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void RecolectarPermisosMarcados(TreeNodeCollection nodos, List<Permiso> listaDestino)
        {
            foreach (TreeNode nodo in nodos)
            {
                if (nodo.Checked)
                {
                    listaDestino.Add((Permiso)nodo.Tag);
                }
                if (nodo.Nodes.Count > 0)
                {
                    RecolectarPermisosMarcados(nodo.Nodes, listaDestino);
                }
            }
        }

        // Metodos del formulario
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