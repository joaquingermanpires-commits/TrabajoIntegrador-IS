using BE;
using BLL;
using Krypton.Toolkit;
using SERVICIOS;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WindowsFormsApp4.Factories;

namespace WindowsFormsApp4.Negocio
{
    public partial class FrmNuevaReserva : KryptonForm
    {
        private int idRestauranteActual = 1;
        private MesaBLL bllMesa = new MesaBLL();
        private ReservaBLL bllReserva = new ReservaBLL();
        private MesaGraficaFactory fabrica = new MesaGraficaEstandarFactory();
        private KryptonButton mesaSeleccionadaBtn = null;
        private DateTime fechaHoraBusquedaActual;
        private int comensalesBusquedaActual;
        private int duracionBusquedaActual;

        public FrmNuevaReserva(int idRestaurante, DateTime fechaHoraSolicitada, int comensales)
        {
            InitializeComponent();
            this.idRestauranteActual = idRestaurante;
            this.fechaHoraBusquedaActual = fechaHoraSolicitada;
            this.comensalesBusquedaActual = comensales;
            dtpFechaReserva.Value = fechaHoraSolicitada.Date;
            dtpHoraReserva.Value = fechaHoraSolicitada;
            numComensales.Value = comensales;
            dtpFechaReserva.Enabled = false;
            dtpHoraReserva.Enabled = false;
            numComensales.Enabled = false;
            btnBuscarMesas.Visible = false;
        }

        private void FrmNuevaReserva_Load(object sender, EventArgs e)
        {
            panelReserva.Visible = true;
            lblMesaElegida.Visible = false;
            txtTokenTarjeta.Visible = false;
            btnConfirmarReserva.Visible = false;
            numTiempoEstadia.Minimum = 45;
            numTiempoEstadia.Maximum = 240;
            numTiempoEstadia.Value = 120;
            DibujarSalonConDisponibilidad(fechaHoraBusquedaActual, comensalesBusquedaActual, (int)numTiempoEstadia.Value);
            AplicarSeguridad();
        }
        private void AplicarSeguridad()
        {
            Usuario usuarioLogueado = Singleton.GetInstance().GetUsuarioActual();
            bool tieneUsuario = usuarioLogueado != null;

            btnBuscarMesas.Enabled = tieneUsuario && PermisoBLL.GetInstance().VerificarPermiso(usuarioLogueado, "btnBuscarMesasReserva");
            btnConfirmarReserva.Enabled = tieneUsuario && PermisoBLL.GetInstance().VerificarPermiso(usuarioLogueado, "btnConfirmarReserva");
        }

        private void btnBuscarMesas_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fecha = dtpFechaReserva.Value.Date;
                TimeSpan hora = dtpHoraReserva.Value.TimeOfDay;
                fechaHoraBusquedaActual = fecha.Add(hora);

                comensalesBusquedaActual = (int)numComensales.Value;
                duracionBusquedaActual = (int)numTiempoEstadia.Value;

                OcultarControlesConfirmacion();

                DibujarSalonConDisponibilidad(fechaHoraBusquedaActual, comensalesBusquedaActual, duracionBusquedaActual);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DibujarSalonConDisponibilidad(DateTime fechaHoraSolicitada, int comensales, int minutosEstadia)
        {
            panelSalon.Controls.Clear();

            IList<Mesa> mesasDisponibles = bllMesa.ObtenerMesasDisponibles(idRestauranteActual, fechaHoraSolicitada, comensales, minutosEstadia);

            foreach (Mesa mesaBE in mesasDisponibles)
            {
                KryptonButton mesaVisual = fabrica.CrearMesaGrafica(mesaBE);
                mesaVisual.Click += MesaVisual_Click;
                panelSalon.Controls.Add(mesaVisual);
            }
        }

        private void MesaVisual_Click(object sender, EventArgs e)
        {
            mesaSeleccionadaBtn = (KryptonButton)sender;
            Mesa mesaBE = (Mesa)mesaSeleccionadaBtn.Tag;

            if (mesaBE.Habilitada)
            {
                lblMesaElegida.Visible = true;
                txtTokenTarjeta.Visible = true;
                btnConfirmarReserva.Visible = true;

                lblMesaElegida.Text = $"Reserva para Mesa: {mesaBE.CodigoUbicacion}";
                txtTokenTarjeta.Text = "";
            }
        }

        private void btnConfirmarReserva_Click(object sender, EventArgs e)
        {
            if (mesaSeleccionadaBtn == null) return;
            Mesa mesaBE = (Mesa)mesaSeleccionadaBtn.Tag;

            try
            {
                if (string.IsNullOrWhiteSpace(txtTokenTarjeta.Text))
                {
                    MessageBox.Show("Debe ingresar un método de pago para la seña.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Reserva nuevaReserva = new Reserva
                {
                    ID_Mesa = mesaBE.ID_Mesa,
                    ID_Restaurante = idRestauranteActual,
                    ID_Usuario = Singleton.GetInstance().GetUsuarioActual().ID_Usuario,
                    FechaHoraSolicitada = fechaHoraBusquedaActual,
                    CantidadComensales = comensalesBusquedaActual,
                    DuracionMinutos = duracionBusquedaActual
                };
                if (bllReserva.GenerarReserva(nuevaReserva, txtTokenTarjeta.Text))
                {
                    MessageBox.Show($"¡Reserva confirmada con éxito!\n\nMesa: {mesaBE.CodigoUbicacion}\nTe esperamos el {fechaHoraBusquedaActual.ToString("dd/MM/yyyy")} a las {fechaHoraBusquedaActual.ToString("HH:mm")}.",
                                    "Reserva Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error en la Reserva", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OcultarControlesConfirmacion()
        {
            lblMesaElegida.Visible = false;
            txtTokenTarjeta.Visible = false;
            btnConfirmarReserva.Visible = false;
            mesaSeleccionadaBtn = null;
        }
    }
}