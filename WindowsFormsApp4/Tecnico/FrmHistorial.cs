using ABS;
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
    public partial class FrmHistorial : Form, IObservadorIdioma
    {
        public FrmHistorial()
        {
            InitializeComponent();
            IdiomaBLL.GetInstance().Suscribir(this);
        }

        private void FrmHistorial_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = IdiomaBLL.GetInstance().ObtenerHistorial();
                dgvHistorial.DataSource = dt;
                FormatearGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el historial: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FormatearGrilla()
        {
            dgvHistorial.AllowUserToAddRows = false;
            if (dgvHistorial.Columns.Count > 0)
            {
                dgvHistorial.Columns["ID_Idioma"].Visible = false;
                dgvHistorial.ReadOnly = true;
                dgvHistorial.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvHistorial.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                dgvHistorial.Columns["ID_Historial"].Visible = false;
                dgvHistorial.Columns["Idioma"].HeaderText = "Idioma";
                dgvHistorial.Columns["Nombre_Control"].HeaderText = "Control";
                dgvHistorial.Columns["Valor_Anterior"].HeaderText = "Valor Anterior";
                dgvHistorial.Columns["Valor_Anterior"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvHistorial.Columns["Valor_Nuevo"].HeaderText = "Valor Nuevo";
                dgvHistorial.Columns["Valor_Nuevo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvHistorial.Columns["Usuario_Modificador"].HeaderText = "Usuario";
                dgvHistorial.Columns["Fecha_Modificacion"].HeaderText = "Fecha";
                this.dgvHistorial.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
        }
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
                    if (traducciones.ContainsKey(claveTag)) c.Text = traducciones[claveTag];
                }
                if (c.Controls.Count > 0) TraducirControles(c.Controls, traducciones);
            }
        }
        private void FrmIdiomas_FormClosed(object sender, FormClosedEventArgs e)
        {
            IdiomaBLL.GetInstance().Desuscribir(this);
        }

        private void dgvHistorial_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvHistorial.CurrentRow != null)
            {
                // 1. Mostrar el valor viejo en el primer TextBox
                // Usamos ? y ?? por si el valor anterior era NULL (la primera vez que se tradujo)
                txtValorViejo.Text = dgvHistorial.CurrentRow.Cells["Valor_Anterior"].Value?.ToString() ?? "";

                // 2. Obtener las claves (Idioma y Etiqueta)
                int idIdioma = Convert.ToInt32(dgvHistorial.CurrentRow.Cells["ID_Idioma"].Value);
                int idEtiqueta = Convert.ToInt32(dgvHistorial.CurrentRow.Cells["Nombre_Control"].Value); // Acá está el "40"

                // 3. Buscar el valor actual vivo en la base de datos y mostrarlo en el segundo TextBox
                txtValorActual.Text = IdiomaBLL.GetInstance().ObtenerTraduccionActual(idIdioma, idEtiqueta);
            }
        }
        private void btnRestablecer_Click(object sender, EventArgs e)
        {
            if (dgvHistorial.CurrentRow == null) return;

            string textoViejo = txtValorViejo.Text;

            if (string.IsNullOrWhiteSpace(textoViejo))
            {
                MessageBox.Show("No se puede restablecer un valor vacío.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 1. Obtener IDs
                int idIdioma = Convert.ToInt32(dgvHistorial.CurrentRow.Cells["ID_Idioma"].Value);
                int idEtiqueta = Convert.ToInt32(dgvHistorial.CurrentRow.Cells["Nombre_Control"].Value);

                // 2. Ejecutar la lógica de guardado (esto crea un nuevo registro en el historial automáticamente)
                IdiomaBLL.GetInstance().RestablecerTraduccion(idIdioma, idEtiqueta, textoViejo);

                MessageBox.Show("Traducción restablecida correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 3. Recargar la grilla y actualizar el TextBox actual
                dgvHistorial.DataSource = IdiomaBLL.GetInstance().ObtenerHistorial();
                txtValorActual.Text = IdiomaBLL.GetInstance().ObtenerTraduccionActual(idIdioma, idEtiqueta);
                IdiomaBLL.GetInstance().Notificar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al restablecer: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
