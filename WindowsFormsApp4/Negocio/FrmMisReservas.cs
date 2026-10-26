using ABS;
using BE;
using BLL;
using SERVICIOS;
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
// using ZXing; 

namespace WindowsFormsApp4.Negocio
{
    public partial class FrmMisReservas : KryptonForm, IObservadorIdioma
    {
        private ReservaBLL bllReserva = new ReservaBLL();
        private long idUsuarioActual;

        public FrmMisReservas()
        {
            InitializeComponent();
            IdiomaBLL.GetInstance().Suscribir(this);
            idUsuarioActual = Singleton.GetInstance().GetUsuarioActual().ID_Usuario;
        }

        private void FrmMisReservas_Load(object sender, EventArgs e)
        {
            ActualizarGrilla();
            AplicarSeguridad();
        }
        private void AplicarSeguridad()
        {
            Usuario usuarioLogueado = Singleton.GetInstance().GetUsuarioActual();
            bool tieneUsuario = usuarioLogueado != null;

            // Bloquea el botón de ver el código/QR si no tiene el permiso
            btnVerPase.Enabled = tieneUsuario && PermisoBLL.GetInstance().VerificarPermiso(usuarioLogueado, "btnVerPase");
        }
        private void ActualizarGrilla()
        {
            try
            {
                dgvMisReservas.DataSource = null;
                dgvMisReservas.DataSource = bllReserva.ObtenerReservasPorUsuario(idUsuarioActual);
                if (dgvMisReservas.Columns["ID_Reserva"] != null) dgvMisReservas.Columns["ID_Reserva"].Visible = false;
                if (dgvMisReservas.Columns["ID_Usuario"] != null) dgvMisReservas.Columns["ID_Usuario"].Visible = false;
                if (dgvMisReservas.Columns["ID_Restaurante"] != null) dgvMisReservas.Columns["ID_Restaurante"].Visible = false;
                if (dgvMisReservas.Columns["ID_Mesa"] != null) dgvMisReservas.Columns["ID_Mesa"].Visible = false;
                if (dgvMisReservas.Columns["SeguroFinanciero"] != null) dgvMisReservas.Columns["SeguroFinanciero"].Visible = false;
                if (dgvMisReservas.Columns["CodigoAcceso"] != null) dgvMisReservas.Columns["CodigoAcceso"].Visible = false; 
                if (dgvMisReservas.Columns["RestauranteNombre"] != null)
                {
                    dgvMisReservas.Columns["RestauranteNombre"].HeaderText = "Local";
                    dgvMisReservas.Columns["RestauranteNombre"].DisplayIndex = 0;
                }
                if (dgvMisReservas.Columns["FechaHoraSolicitada"] != null)
                    dgvMisReservas.Columns["FechaHoraSolicitada"].HeaderText = "Fecha y Hora";
                if (dgvMisReservas.Columns["CantidadComensales"] != null)
                    dgvMisReservas.Columns["CantidadComensales"].HeaderText = "Personas";

                dgvMisReservas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar historial: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVerPase_Click(object sender, EventArgs e)
        {
            if (dgvMisReservas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una reserva de la lista para ver su pase.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Reserva reservaElegida = (Reserva)dgvMisReservas.CurrentRow.DataBoundItem;

            if (reservaElegida.Estado != Reserva.EstadoReserva.Confirmada)
            {
                MessageBox.Show($"Esta reserva se encuentra en estado '{reservaElegida.Estado}'. Solo las reservas confirmadas y pendientes de asistencia poseen pase de acceso.", "Pase no disponible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MostrarPaseAcceso(reservaElegida);
        }

        private void MostrarPaseAcceso(Reserva reserva)
        {
            using (KryptonForm frmPase = new KryptonForm())
            {
                frmPase.Text = "Pase de Acceso / Check-In";
                frmPase.Size = new Size(350, 450);
                frmPase.StartPosition = FormStartPosition.CenterParent;
                frmPase.FormBorderStyle = FormBorderStyle.FixedDialog;
                frmPase.MaximizeBox = false;
                frmPase.MinimizeBox = false;
                frmPase.BackColor = Color.White;

                Label lblTitulo = new Label
                {
                    Text = $"Reserva en {reserva.RestauranteNombre}\n{reserva.FechaHoraSolicitada.ToString("dd/MM/yyyy HH:mm")}",
                    Dock = DockStyle.Top,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Height = 60,
                    Font = new Font("Segoe UI", 12F, FontStyle.Bold)
                };

                Label lblCodigo = new Label
                {
                    Text = reserva.CodigoAcceso,
                    Dock = DockStyle.Top,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Height = 80,
                    Font = new Font("Courier New", 32F, FontStyle.Bold),
                    ForeColor = Color.DarkBlue
                };

                Label lblAyuda = new Label
                {
                    Text = "Presente este código o el QR al recepcionista\npara que le asigne su mesa y libere su seña.",
                    Dock = DockStyle.Bottom,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Height = 60
                };

                PictureBox picQR = new PictureBox
                {
                    Dock = DockStyle.Fill,
                    SizeMode = PictureBoxSizeMode.CenterImage,
                    BackColor = Color.White
                };

                /* --- LÓGICA DE CÓDIGO QR FUTURA --- */
                // try {
                //     BarcodeWriter writer = new BarcodeWriter { Format = BarcodeFormat.QR_CODE };
                //     writer.Options.Height = 200;
                //     writer.Options.Width = 200;
                //     picQR.Image = writer.Write(reserva.CodigoAcceso);
                // } catch { }
                /* ---------------------------------- */

                frmPase.Controls.Add(picQR);
                frmPase.Controls.Add(lblCodigo);
                frmPase.Controls.Add(lblTitulo);
                frmPase.Controls.Add(lblAyuda);

                frmPase.ShowDialog();
            }
        }

        // Multi-idioma
        public void ActualizarIdioma()
        {
            var traducciones = IdiomaBLL.GetInstance().ObtenerTraducciones();
            TraducirControles(this.Controls, traducciones);
        }

        private void TraducirControles(Control.ControlCollection controles, System.Collections.Generic.Dictionary<string, string> traducciones)
        {
            foreach (Control c in controles)
            {
                if (c.Tag != null && traducciones.ContainsKey(c.Tag.ToString()))
                {
                    c.Text = traducciones[c.Tag.ToString()];
                }
                if (c.Controls.Count > 0) TraducirControles(c.Controls, traducciones);
            }
        }

        private void FrmMisReservas_FormClosed(object sender, FormClosedEventArgs e)
        {
            IdiomaBLL.GetInstance().Desuscribir(this);
        }
    }
}