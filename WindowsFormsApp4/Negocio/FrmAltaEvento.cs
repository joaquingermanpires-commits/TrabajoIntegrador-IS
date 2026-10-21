using BE;
using BLL;
using Krypton.Toolkit;
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

namespace WindowsFormsApp4.Negocio
{
    public partial class FrmAltaEvento : KryptonForm
    {
        private EventoBLL bllEvento = new EventoBLL();

        private int idRestauranteActual;

        public FrmAltaEvento()
        {
            InitializeComponent();
        }
        private void FrmAltaEvento_Load(object sender, EventArgs e)
        {
            CargarGrillaEventos();
            AplicarSeguridad();
            Usuario usuarioLogueado = Singleton.GetInstance().GetUsuarioActual();
            Restaurante miLocal = new RestauranteBLL().ObtenerRestaurantePorUsuario(usuarioLogueado.ID_Usuario);
            if (miLocal != null)
            {
                idRestauranteActual = miLocal.ID_Restaurante;
            }
            else
            {
                MessageBox.Show("Tu usuario no tiene ningún restaurante asignado. Contactá al administrador.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }
        }
        private void AplicarSeguridad()
        {
            Usuario usuarioLogueado = Singleton.GetInstance().GetUsuarioActual();
            bool tieneUsuario = usuarioLogueado != null;

            btnGuardarEvento.Enabled = tieneUsuario && PermisoBLL.GetInstance().VerificarPermiso(usuarioLogueado, "btnGuardarEvento");
        }
        private void btnGuardarEvento_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    MessageBox.Show("El nombre del evento es obligatorio.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                Evento nuevoEvento = new Evento
                {
                    ID_Restaurante = idRestauranteActual,
                    Nombre = txtNombre.Text.Trim(),
                    Descripcion = txtDescripcion.Text.Trim(),
                    FechaHoraInicio = dtpFechaInicio.Value,
                    FechaHoraFin = dtpFechaFin.Value,
                    PorcentajeDescuento = numDescuento.Value
                };
                if (bllEvento.AltaEventoPromocional(nuevoEvento))
                {
                    MessageBox.Show("¡El evento promocional fue creado con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarFormulario();
                    CargarGrillaEventos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarFormulario()
        {
            txtNombre.Clear();
            txtDescripcion.Clear();
            dtpFechaInicio.Value = DateTime.Now;
            dtpFechaFin.Value = DateTime.Now.AddDays(1);
            numDescuento.Value = 0;
            txtNombre.Focus();
        }
        private void CargarGrillaEventos()
        {
            try
            {
                dgvEventos.DataSource = null;
                dgvEventos.DataSource = bllEvento.ObtenerEventosPorRestaurante(idRestauranteActual);
                if (dgvEventos.Columns["ID_Evento"] != null)
                    dgvEventos.Columns["ID_Evento"].Visible = false;
                if (dgvEventos.Columns["ID_Restaurante"] != null)
                    dgvEventos.Columns["ID_Restaurante"].Visible = false;
                if (dgvEventos.Columns["FechaHoraInicio"] != null)
                {
                    dgvEventos.Columns["FechaHoraInicio"].HeaderText = "Inicio";
                    dgvEventos.Columns["FechaHoraInicio"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                }
                if (dgvEventos.Columns["FechaHoraFin"] != null)
                {
                    dgvEventos.Columns["FechaHoraFin"].HeaderText = "Fin";
                    dgvEventos.Columns["FechaHoraFin"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                }
                if (dgvEventos.Columns["PorcentajeDescuento"] != null)
                {
                    dgvEventos.Columns["PorcentajeDescuento"].HeaderText = "Descuento";
                    dgvEventos.Columns["PorcentajeDescuento"].DefaultCellStyle.Format = "0.00' %'";
                }
                if (dgvEventos.Columns["Descripcion"] != null)
                {
                    dgvEventos.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvEventos.Columns["Descripcion"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                }
                dgvEventos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la grilla de eventos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void kryptonPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
