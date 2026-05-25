using ABS;
using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class FrmIdiomas : Form, IObservadorIdioma
    {
        public FrmIdiomas()
        {
            InitializeComponent();
            CargarComboIdiomas();
            IdiomaBLL.GetInstance().Suscribir(this);
            ActualizaDGVU();
        }
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
            if (cmbIdiomas.SelectedItem is IIdioma idiomaSeleccionado)
            {
                dgvTraducciones.DataSource = IdiomaBLL.GetInstance().ObtenerDiccionarioCompleto(idiomaSeleccionado.ID_Idioma);

                if (dgvTraducciones.Columns.Contains("Nombre_Control"))
                {
                    dgvTraducciones.Columns["Nombre_Control"].ReadOnly = true;
                    dgvTraducciones.Columns["Nombre_Control"].HeaderText = "Tag / Etiqueta";
                }
                if (dgvTraducciones.Columns.Contains("TextoTraduccion"))
                {
                    dgvTraducciones.Columns["TextoTraduccion"].HeaderText = "Traducción para este Idioma";
                }
            }
        }
        private void btnAgregarEtiqueta_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbIdiomas.SelectedItem is IIdioma idiomaSeleccionado)
                {
                    // Enviamos el Tag, el Idioma de la pantalla y el texto inicial
                    IdiomaBLL.GetInstance().AgregarEtiquetaConTraduccion(
                        txtNuevaEtiqueta.Text.Trim(),
                        idiomaSeleccionado.ID_Idioma,
                        txtNuevaTraduccion.Text.Trim()
                    );

                    MessageBox.Show("Etiqueta y traducción registradas correctamente.");

                    // Limpiamos los campos y refrescamos la grilla
                    txtNuevaEtiqueta.Clear();
                    txtNuevaTraduccion.Clear();
                    ActualizaDGVU();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnAgregarTraducciones_Click(object sender, EventArgs e)
        {
            try
            {
                var idiomaSeleccionado = (IIdioma)cmbIdiomas.SelectedItem;
                Dictionary<string, string> diccionario = new Dictionary<string, string>();

                foreach (DataGridViewRow row in dgvTraducciones.Rows)
                {
                    if (row.Cells["Nombre_Control"].Value != null)
                    {
                        string tag = row.Cells["Nombre_Control"].Value.ToString();
                        string traduccion = row.Cells["TextoTraduccion"].Value?.ToString() ?? "";
                        diccionario.Add(tag, traduccion);
                    }
                }

                IdiomaBLL.GetInstance().GuardarTraducciones(idiomaSeleccionado.ID_Idioma, diccionario);
                MessageBox.Show("Modificaciones de la grilla guardadas con éxito.");

                // Si editamos el idioma que el operador tiene puesto ahora mismo, forzamos el refresco visual (Observer)
                if (IdiomaBLL.GetInstance().IdiomaActivo.ID_Idioma == idiomaSeleccionado.ID_Idioma)
                {
                    IdiomaBLL.GetInstance().CambiarIdioma(idiomaSeleccionado);
                }
                ActualizaDGVU();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAgregarIdioma_Click(object sender, EventArgs e)
        {
            try
            {
                IdiomaBLL.GetInstance().AgregarIdioma(txtNuevoIdioma.Text.Trim());
                CargarComboIdiomas();
                txtNuevoIdioma.Clear();
                MessageBox.Show("Idioma agregado con éxito.");
                ActualizaDGVU();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
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

        private void dgvTraducciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtNuevaEtiqueta.Text = dgvTraducciones.Rows[e.RowIndex].Cells["Nombre_Control"].Value.ToString();
                txtNuevaTraduccion.Text = dgvTraducciones.Rows[e.RowIndex].Cells["TextoTraduccion"].Value.ToString();
            }
        }
    }
}