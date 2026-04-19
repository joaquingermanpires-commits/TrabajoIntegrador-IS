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
    public partial class FrmGestion : Form
    {
        UsuarioBLL bll = new UsuarioBLL();
        public FrmGestion()
        {
            InitializeComponent();
            ActualizaDGVU();
        }

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
        }

        private void BtnAlta_Click(object sender, EventArgs e)
        {
            try
            {
                bll.CrearUsuario(inputNombre.Text, InputContraseña.Text);
                MessageBox.Show("Usuario creado con éxito.");
                // Recargar grilla
                ActualizaDGVU();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void BtnBaja_Click(object sender, EventArgs e)
        {
            try
            {
                long idSeleccionado = Convert.ToInt64(dgvu.CurrentRow.Cells["ID_Usuario"].Value);
                bll.EliminarUsuario(idSeleccionado);
                MessageBox.Show("Usuario eliminado.");
                // Recargar grilla
                ActualizaDGVU();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void BtnModif_Click(object sender, EventArgs e)
        {
            try
            {
                // se Validamos que el usuario haya hecho clic en alguna fila de la grilla
                if (dgvu.CurrentRow == null)
                {
                    MessageBox.Show("Por favor, seleccione un usuario de la lista para modificar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                long idSeleccionado = Convert.ToInt64(dgvu.CurrentRow.Cells["ID_Usuario"].Value);   
                string nuevoNombre = inputNombre.Text;
                string nuevaContrasena = InputContraseña.Text;

                //BLL valida y hashee
                bll.ModificarUsuario(idSeleccionado, nuevoNombre, nuevaContrasena);

                // 5. Si todo salió bien, avisamos al usuario
                MessageBox.Show("El usuario ha sido modificado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                inputNombre.Clear();
                InputContraseña.Clear();

                ActualizaDGVU();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al modificar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
