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
using WindowsFormsApp4.Factories;

namespace WindowsFormsApp4.Negocio
{
    public partial class FrmNuevaReserva : KryptonForm
    {
        private int idRestauranteActual = 1;
        private MesaBLL bllMesa = new MesaBLL();
        private MesaGraficaFactory fabrica = new MesaGraficaEstandarFactory();
        private KryptonButton mesaSeleccionadaBtn = null;
        private RestauranteBLL bllRestaurante = new RestauranteBLL();

        // NUEVO: Variables para recordar los filtros exactos con los que se hizo la búsqueda
        private DateTime fechaHoraBusquedaActual;
        private int comensalesBusquedaActual;
        private int duracionBusquedaActual;

        public FrmNuevaReserva()
        {
            InitializeComponent();
        }

        private void FrmNuevaReserva_Load(object sender, EventArgs e)
        {
            panelReserva.Visible = true;

            // 2. Ocultamos SOLAMENTE los controles de la tarjeta y la etiqueta de la mesa
            lblMesaElegida.Visible = false;
            txtTokenTarjeta.Visible = false;
            btnConfirmarReserva.Visible = false;

            // Configuramos los límites (temporales) del tiempo
            numTiempoEstadia.Minimum = 45;
            numTiempoEstadia.Maximum = 240;
            numTiempoEstadia.Value = 120;
        }

        // NUEVO EVENTO: Se dispara al darle al botón de buscar
        private void btnBuscarMesas_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Unificamos la fecha y la hora en un solo objeto DateTime (Arquitectura sólida)
                DateTime fecha = dtpFechaReserva.Value.Date;
                TimeSpan hora = dtpHoraReserva.Value.TimeOfDay;
                fechaHoraBusquedaActual = fecha.Add(hora);

                // 2. Guardamos la cantidad de personas y el tiempo que eligieron
                comensalesBusquedaActual = (int)numComensales.Value;
                duracionBusquedaActual = (int)numTiempoEstadia.Value;

                mesaSeleccionadaBtn = null;
                lblMesaElegida.Visible = false;
                txtTokenTarjeta.Visible = false;
                btnConfirmarReserva.Visible = false;

                // 3. Dibujamos pasándole los datos unificados
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

            // ATENCIÓN: Esta línea va a tirar un error de compilación temporal porque todavía 
            // no creamos este método exacto en tu BLL. Lo haremos en el próximo paso.
            List<Mesa> mesasDisponibles = bllMesa.ObtenerMesasDisponibles(idRestauranteActual, fechaHoraSolicitada, comensales, minutosEstadia);

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
                // 3. Volvemos a mostrar los controles de confirmación
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

                // 1. INSTANCIAMOS LA RESERVA CON LA NUEVA ESTRUCTURA BE
                Reserva nuevaReserva = new Reserva
                {
                    ID_Mesa = mesaBE.ID_Mesa,
                    ID_Restaurante = idRestauranteActual,
                    ID_Usuario = 1, // ID del comensal hardcodeado por ahora
                    FechaHoraSolicitada = fechaHoraBusquedaActual, // Fecha y hora combinadas
                    CantidadComensales = comensalesBusquedaActual,
                    DuracionMinutos = duracionBusquedaActual       // La nueva propiedad
                };

                // nuevaReserva.ConfirmarReserva(); // Podrías llamar a tu método de estado aquí

                /*
                Descomentá esto cuando tengas listo el método GenerarReserva en tu ReservaBLL
                (y acordate de pasarle el token de la tarjeta si tu BLL lo requiere)
                
                ReservaBLL bllReserva = new ReservaBLL();
                bllReserva.GenerarReserva(nuevaReserva); 
                */

                // 2. ACTUALIZACIÓN VISUAL INMEDIATA (Observer)
                mesaBE.Habilitada = false;

                MessageBox.Show($"¡Reserva confirmada con éxito!\n\nMesa: {mesaBE.CodigoUbicacion}\nTe esperamos el {fechaHoraBusquedaActual.ToString("dd/MM/yyyy")} a las {fechaHoraBusquedaActual.ToString("HH:mm")}.",
                                "Reserva Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                lblMesaElegida.Visible = false;
                txtTokenTarjeta.Visible = false;
                btnConfirmarReserva.Visible = false;
                mesaSeleccionadaBtn = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error en la Reserva", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
