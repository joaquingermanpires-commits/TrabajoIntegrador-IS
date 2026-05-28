using ABS;
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
            CargarBitacora();
        }
        private void CargarBitacora()
        {
            try
            {
                dgvBitacora.DataSource = BitacoraBLL.GetInstance().ConsultarBitacora();
                if (dgvBitacora.Columns.Count > 0)
                {
                    dgvBitacora.Columns["ID_Bitacora"].Visible = false;
                    dgvBitacora.Columns["Fecha"].Width = 130;
                    dgvBitacora.Columns["Usuario"].Width = 120;
                    dgvBitacora.Columns["Criticidad"].Width = 90;
                    dgvBitacora.Columns["Modulo"].Width = 120;
                    dgvBitacora.Columns["Mensaje"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la bitácora: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void ActualizarIdioma()
        {
            var traducciones = IdiomaBLL.GetInstance().ObtenerTraducciones();
            TraducirControles(this.Controls, traducciones);
            CargarBitacora();
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
        private void FrmBitacora_FormClosed(object sender, FormClosedEventArgs e)
        {
            IdiomaBLL.GetInstance().Desuscribir(this);

        }

        private void FrmBitacora_Load(object sender, EventArgs e)
        {
            CargarBitacora();
        }
    }
}