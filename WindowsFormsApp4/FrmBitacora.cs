using ABS;
using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class FrmBitacora : Form, IObservadorIdioma
    {
        public FrmBitacora()
        {
            InitializeComponent();
            IdiomaBLL.GetInstance().Suscribir(this);
        }

        private void FrmBitacora_Load(object sender, EventArgs e)
        {
            cmbCriticidad.Items.Add("Todas");
            cmbCriticidad.Items.Add("INFO");
            cmbCriticidad.Items.Add("WARNING");
            cmbCriticidad.Items.Add("ERROR");
            cmbCriticidad.Items.Add("CRITICAL");
            cmbCriticidad.SelectedIndex = 0; // Seleccionamos "Todas" por defecto
            dtpDesde.Value = DateTime.Now.AddMonths(-1);
            dtpHasta.Value = DateTime.Now;
            BuscarConFiltros();
        }
        //botones para filtrar
        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            BuscarConFiltros();
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dtpDesde.Value = DateTime.Now.AddMonths(-1);
            dtpHasta.Value = DateTime.Now;
            cmbCriticidad.SelectedIndex = 0;
            txtUsuario.Clear();

            BuscarConFiltros();
        }
        //Metodos del dgv
        private void BuscarConFiltros()
        {
            try
            {
                DateTime? fechaDesde = dtpDesde.Value.Date;
                DateTime? fechaHasta = dtpHasta.Value.Date.AddDays(1).AddSeconds(-1);
                string criticidad = cmbCriticidad.SelectedItem.ToString() == "Todas" ? "" : cmbCriticidad.SelectedItem.ToString();
                string usuario = txtUsuario.Text.Trim();
                var listaFiltrada = BitacoraBLL.GetInstance().ConsultarBitacoraFiltrada(fechaDesde, fechaHasta, criticidad, usuario);

                dgvBitacora.DataSource = null;
                dgvBitacora.DataSource = listaFiltrada;

                FormatearGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar la bitácora: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FormatearGrilla()
        {
            if (dgvBitacora.Columns.Count > 0)
            {
                dgvBitacora.Columns["ID_Bitacora"].Visible = false;

                dgvBitacora.Columns["Fecha"].Width = 130;
                dgvBitacora.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss"; // Formato de fecha y hora

                dgvBitacora.Columns["Usuario"].Width = 120;
                dgvBitacora.Columns["Criticidad"].Width = 90;
                dgvBitacora.Columns["Modulo"].Width = 120;

                dgvBitacora.Columns["Mensaje"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dgvBitacora.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
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
                    if (traducciones.ContainsKey(claveTag)) c.Text = traducciones[claveTag];
                }

                if (c.Controls.Count > 0) TraducirControles(c.Controls, traducciones);
            }
        }
        private void FrmBitacora_FormClosed(object sender, FormClosedEventArgs e)
        {
            IdiomaBLL.GetInstance().Desuscribir(this);
        }
    }
}