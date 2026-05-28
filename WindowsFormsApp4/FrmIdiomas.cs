using ABS;
using BE;
using BLL;
using SERVICIOS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class FrmIdiomas : Form, IObservadorIdioma
    {
        private string etiquetaSeleccionada = "";
        private string tagTraduccionSeleccionada = "";
        private string usuario = Singleton.GetInstance().GetUsuario();
        public FrmIdiomas()
        {
            InitializeComponent();
            CargarComboIdiomas();
            IdiomaBLL.GetInstance().Suscribir(this);
            ActualizaDGVU();
        }
        //Actualizacion de controles(dgv,cmb,txtbox)
        private void CargarComboIdiomas()
        {
            cmbIdiomas.DataSource = IdiomaBLL.GetInstance().ObtenerIdiomasDisponibles();
            cmbIdiomas.DisplayMember = "Nombre";
            cmbIdiomas.ValueMember = "ID_Idioma";
        }
        private void cmbIdiomas_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizaDGVU();
        }
        private void ActualizaDGVU()
        {
            dgvTraducciones.AllowUserToAddRows = false;
            dgvTraducciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            if (cmbIdiomas.SelectedItem is IIdioma idiomaSeleccionado)
            {
                dgvTraducciones.DataSource = IdiomaBLL.GetInstance().ObtenerDiccionarioCompleto(idiomaSeleccionado.ID_Idioma);

                if (dgvTraducciones.Columns.Contains("Nombre_Control"))
                {
                    dgvTraducciones.Columns["Nombre_Control"].ReadOnly = true;
                    dgvTraducciones.Columns["Nombre_Control"].HeaderText = "Etiqueta";
                }
                if (dgvTraducciones.Columns.Contains("TextoTraduccion"))
                {
                    dgvTraducciones.Columns["TextoTraduccion"].ReadOnly = true;
                    dgvTraducciones.Columns["TextoTraduccion"].HeaderText = "Traducción";
                }
            }
        }
        private void dgvTraducciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                etiquetaSeleccionada = dgvTraducciones.Rows[e.RowIndex].Cells["Nombre_Control"].Value.ToString();
                txtEtiqueta.Text = etiquetaSeleccionada;

                tagTraduccionSeleccionada = dgvTraducciones.Rows[e.RowIndex].Cells["Nombre_Control"].Value.ToString();
                txtTraduccion.Text = dgvTraducciones.Rows[e.RowIndex].Cells["TextoTraduccion"].Value?.ToString() ?? "";
            }
        }
        //Botones etiquetas
        private void btnAgregarEtiqueta_Click(object sender, EventArgs e)
        {
            try
            {
                IdiomaBLL.GetInstance().AgregarEtiqueta(txtEtiqueta.Text.Trim());
                BitacoraBLL.GetInstance().RegistrarBitacora(usuario, "INFO", "FrmIdioma", "Etiqueta agregada exitosamente.");
                ActualizaDGVU();
                cmbIdiomas_SelectedIndexChanged(null, null); // Refresca traducciones por si sumamos una nueva
                txtEtiqueta.Clear();
            }
            catch (Exception ex) 
            {
                BitacoraBLL.GetInstance().RegistrarBitacora(usuario, "CRITICAL", "FrmIdioma", $"Error del sistema: {ex.Message}"); 
                MessageBox.Show(ex.Message); 
            }

        }
        private void btnEliminarEtiqueta_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Eliminar etiqueta y todas sus traducciones?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    IdiomaBLL.GetInstance().EliminarEtiqueta(etiquetaSeleccionada);
                    BitacoraBLL.GetInstance().RegistrarBitacora(usuario, "INFO", "FrmIdioma", "Etiqueta eliminada exitosamente.");
                    ActualizaDGVU();
                    cmbIdiomas_SelectedIndexChanged(null, null);
                    txtEtiqueta.Clear();
                }
            }
            catch (Exception ex) 
            {
                BitacoraBLL.GetInstance().RegistrarBitacora(usuario, "CRITICAL", "FrmIdioma", $"Error del sistema: {ex.Message}");
                MessageBox.Show(ex.Message); 
            }
        }
        private void btnModificarEtiqueta_Click(object sender, EventArgs e)
        {
            try
            {
                IdiomaBLL.GetInstance().ModificarEtiqueta(etiquetaSeleccionada, txtEtiqueta.Text.Trim());
                BitacoraBLL.GetInstance().RegistrarBitacora(usuario, "INFO", "FrmIdioma", "Etiqueta modificada exitosamente.");
                ActualizaDGVU();
                cmbIdiomas_SelectedIndexChanged(null, null);
                txtEtiqueta.Clear();
                etiquetaSeleccionada = "";
                MessageBox.Show("Etiqueta modificada.");
            }
            catch (Exception ex) 
            {
                BitacoraBLL.GetInstance().RegistrarBitacora(usuario, "CRITICAL", "FrmIdioma", $"Error del sistema: {ex.Message}");
                MessageBox.Show(ex.Message); 
            }
        }
        //Boton traducciones
        private void btnAgregarTraducciones_Click(object sender, EventArgs e)
        {

            try
            {
                if (cmbIdiomas.SelectedItem is IIdioma idiomaSeleccionado && !string.IsNullOrEmpty(tagTraduccionSeleccionada))
                {
                    IdiomaBLL.GetInstance().GuardarTraduccionIndividual(idiomaSeleccionado.ID_Idioma, tagTraduccionSeleccionada, txtTraduccion.Text.Trim());
                    BitacoraBLL.GetInstance().RegistrarBitacora(usuario, "INFO", "FrmIdioma", "Traducción agregada exitosamente.");
                    MessageBox.Show("Traducción guardada.");
                    ActualizaDGVU();
                    txtTraduccion.Clear();
                    if (IdiomaBLL.GetInstance().IdiomaActivo.ID_Idioma == idiomaSeleccionado.ID_Idioma)
                    {
                        IdiomaBLL.GetInstance().CambiarIdioma(idiomaSeleccionado);
                    }
                }
            }
            catch (Exception ex) 
            {
                BitacoraBLL.GetInstance().RegistrarBitacora(usuario, "CRITICAL", "FrmIdioma", $"Error del sistema: {ex.Message}");
                MessageBox.Show(ex.Message); 
            }
        }
        //Boton Idioma
        private void btnAgregarIdioma_Click(object sender, EventArgs e)
        {
            try
            {
                {
                    IdiomaBLL.GetInstance().AgregarIdiomaCopiaDefault(txtNuevoIdioma.Text.Trim());
                    CargarComboIdiomas();
                    txtNuevoIdioma.Clear();
                    BitacoraBLL.GetInstance().RegistrarBitacora(usuario, "INFO", "FrmIdioma", "Nuevo Idioma guardado exitosamente.");
                    MessageBox.Show("Idioma agregado con éxito.");
                    ActualizaDGVU();
                }
            }
            catch (Exception ex)
            {
                BitacoraBLL.GetInstance().RegistrarBitacora(usuario, "CRITICAL", "FrmIdioma", $"Error del sistema: {ex.Message}");
                MessageBox.Show(ex.Message, "Error al agregar idioma", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Metodos del formulario
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
                    if (traducciones.ContainsKey(claveTag)) c.Text = traducciones[claveTag];
                }
                if (c.Controls.Count > 0) TraducirControles(c.Controls, traducciones);
            }
        }
        private void FrmIdiomas_FormClosed(object sender, FormClosedEventArgs e)
        {
            IdiomaBLL.GetInstance().Desuscribir(this);
        }
    }
}