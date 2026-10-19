using BE;
using BLL;
using Krypton.Toolkit;
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
    public partial class FrmBuscadorRestaurantes : KryptonForm
    {
        private RestauranteBLL bllRestaurante = new RestauranteBLL();
        private IList<Restaurante> listaResultados = new List<Restaurante>();

        public FrmBuscadorRestaurantes()
        {
            InitializeComponent();
        }

        private void FrmBuscadorRestaurantes_Load(object sender, EventArgs e)
        {
            ConfigurarGrilla();
        }

        private void ConfigurarGrilla()
        {
            dgvRestaurantes.AutoGenerateColumns = false;
            dgvRestaurantes.Columns.Clear();
            dgvRestaurantes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ID_Restaurante", HeaderText = "ID", Visible = false });
            dgvRestaurantes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Nombre", HeaderText = "Restaurante", Width = 200 });
            dgvRestaurantes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Direccion", HeaderText = "Dirección", Width = 250 });
            dgvRestaurantes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "EventosResumen", HeaderText = "Evento Especial", Width = 200 });
            dgvRestaurantes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PreferenciasResumen", HeaderText = "Opciones", Width = 150 });
        }

        private void btnBuscarRestaurantes_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fecha = dtpFechaBusqueda.Value.Date;
                TimeSpan hora = dtpHoraBusqueda.Value.TimeOfDay;
                DateTime fechaHora = fecha.Add(hora);
                int comensales = (int)numComensalesBusqueda.Value;
                listaResultados = bllRestaurante.BuscarRestaurantesDisponibles(fechaHora, comensales);
                dgvRestaurantes.DataSource = null;
                dgvRestaurantes.DataSource = listaResultados;

                if (listaResultados.Count == 0)
                {
                    MessageBox.Show("No se encontraron restaurantes con disponibilidad para esa fecha y cantidad de personas.", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSeleccionarRestaurante_Click(object sender, EventArgs e)
        {
            if (dgvRestaurantes.CurrentRow == null)
            {
                MessageBox.Show("Por favor, seleccione un restaurante de la lista haciendo clic sobre él.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Restaurante restauranteElegido = (Restaurante)dgvRestaurantes.CurrentRow.DataBoundItem;
            DateTime fecha = dtpFechaBusqueda.Value.Date;
            TimeSpan hora = dtpHoraBusqueda.Value.TimeOfDay;
            DateTime fechaHora = fecha.Add(hora);
            int comensales = (int)numComensalesBusqueda.Value;
            // 3. ¡EL PUENTE! Abrimos el FrmNuevaReserva inyectándole estos datos
            FrmNuevaReserva frmReserva = new FrmNuevaReserva(restauranteElegido.ID_Restaurante, fechaHora, comensales);
            frmReserva.ShowDialog();
        }
    }
}
