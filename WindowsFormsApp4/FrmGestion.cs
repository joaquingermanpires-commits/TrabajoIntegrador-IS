using ABS;
using BE;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp4
{
    public partial class FrmGestion : Form, IObservadorIdioma
    {
        UsuarioBLL bll = new UsuarioBLL();
        private string usuario = Singleton.GetInstance().GetUsuario();
        public FrmGestion()
        {
            InitializeComponent();
            ActualizaDGVU();
            bll = new UsuarioBLL();
            IdiomaBLL.GetInstance().Suscribir(this);
        }
        //Actualizacion de controles(dgv, txtbox)
        private void dgvu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                inputNombre.Text = dgvu.Rows[e.RowIndex].Cells["Nombre_Usuario"].Value.ToString();
                // Vaciamos la contraseña por seguridad (para forzar a que escriba una nueva si quiere modificar)
                InputContraseña.Clear();
            }
        }
        private void ActualizaDGVU() 
        {
            dgvu.DataSource = null;
            dgvu.DataSource = bll.ObtenerUsuarios();
            this.dgvu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvu.Columns["Contraseña_Hash"].Visible = false;
            dgvu.Columns["Nombre_Usuario"].HeaderText = "Nombre";
            dgvu.Columns["IdiomaPreferido"].Visible = false;
            dgvu.Columns["DVH"].Visible = false;
        }
        //Gestion Usuarios
        public void BtnAlta_Click(object sender, EventArgs e)
        {
            try
            {
                bll.CrearUsuario(inputNombre.Text, InputContraseña.Text);
                MessageBox.Show("Usuario creado con éxito.");
                BitacoraBLL.GetInstance().RegistrarBitacora(usuario, "INFO", "FrmGestion", "Usuario creado exitosamente.");
                ActualizaDGVU();
                InputContraseña.Clear();
                inputNombre.Clear();
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Error al Crear"); ;
                BitacoraBLL.GetInstance().RegistrarBitacora(usuario, "CRITICAL", "FrmGestion", $"Error del sistema: {ex.Message}");
            }
        }
        public void BtnBaja_Click(object sender, EventArgs e)
        {
            try
            {
                long idSeleccionado = Convert.ToInt64(dgvu.CurrentRow.Cells["ID_Usuario"].Value);
                bll.EliminarUsuario(idSeleccionado);
                MessageBox.Show("Usuario eliminado.");
                BitacoraBLL.GetInstance().RegistrarBitacora(usuario, "INFO", "FrmGestion", "Usuario eliminado exitosamente.");
                ActualizaDGVU();
                InputContraseña.Clear();
                inputNombre.Clear();
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "Error al Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                BitacoraBLL.GetInstance().RegistrarBitacora(usuario, "CRITICAL", "FrmGestion", $"Error del sistema: {ex.Message}");
            }
        }
        public void BtnModif_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvu.CurrentRow == null)
                {
                    MessageBox.Show("Por favor, seleccione un usuario de la lista para modificar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    BitacoraBLL.GetInstance().RegistrarBitacora(usuario, "WARNING", "FrmGestion", "Error de seleccion de usuario.");
                    return;
                }

                long idSeleccionado = Convert.ToInt64(dgvu.CurrentRow.Cells["ID_Usuario"].Value);   
                string nuevoNombre = inputNombre.Text;
                string nuevaContrasena = InputContraseña.Text;
                bll.ModificarUsuario(idSeleccionado, nuevoNombre, nuevaContrasena);
                MessageBox.Show("El usuario ha sido modificado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BitacoraBLL.GetInstance().RegistrarBitacora(usuario, "INFO", "FrmGestion", "Usuario modificado exitosamente.");
                inputNombre.Clear();
                InputContraseña.Clear();
                ActualizaDGVU();
                InputContraseña.Clear();
                inputNombre.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al modificar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                BitacoraBLL.GetInstance().RegistrarBitacora(usuario, "CRITICAL", "FrmGestion", $"Error del sistema: {ex.Message}");
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
        private void FrmGestion_FormClosed(object sender, FormClosedEventArgs e)
        {
            IdiomaBLL.GetInstance().Desuscribir(this);
        }
    }
}
