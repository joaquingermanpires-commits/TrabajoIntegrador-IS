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
        public FrmNuevaReserva()
        {
            InitializeComponent();
        }
        private void FrmNuevaReserva_Load(object sender, EventArgs e)
        {
            panelReserva.Visible = false; // Oculto al inicio
            DibujarSalon();
            panelReservaConfirmacion.Visible = false;

            // 1. Buscamos las reglas del negocio del restaurante actual
            Restaurante restActual = bllRestaurante.ObtenerRestaurante(idRestauranteActual);

            // 2. Configuramos el control numérico para que respete esas reglas
            numTiempoEstadia.Minimum = restActual.TiempoMinimoPermitido;
            numTiempoEstadia.Maximum = restActual.TiempoMaximoPermitido;
            numTiempoEstadia.Value = restActual.TiempoMinimoPermitido; // Valor
        }
        private void DibujarSalon()
        {
            try
            {
                panelSalon.Controls.Clear();
                List<Mesa> mesasDelLocal = bllMesa.ObtenerMesas(idRestauranteActual);

                foreach (Mesa mesaBE in mesasDelLocal)
                {
                    // Al no pasarle "true" como segundo parámetro, asume false (modo comensal)
                    // Las mesas ocupadas nacerán bloqueadas (Enabled = false)
                    KryptonButton mesaVisual = fabrica.CrearMesaGrafica(mesaBE);

                    mesaVisual.Click += MesaVisual_Click;
                    panelSalon.Controls.Add(mesaVisual);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el salón: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void MesaVisual_Click(object sender, EventArgs e)
        {
            mesaSeleccionadaBtn = (KryptonButton)sender;
            Mesa mesaBE = (Mesa)mesaSeleccionadaBtn.Tag;

            if (mesaBE.Habilitada)
            {
                // Mostramos el panel y configuramos los límites
                panelReserva.Visible = true;
                lblMesaElegida.Text = $"Reserva para Mesa: {mesaBE.CodigoUbicacion}";

                // Evitamos que reserven para más personas de las que entran en la butaca
                numComensales.Maximum = mesaBE.CapacidadPersonas;
                numComensales.Minimum = 1;
                numComensales.Value = 1;

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

                /* 
                 * 1. INTEGRACIÓN CON TU CAPA DE NEGOCIO (BLL)
                 * Aquí deberías instanciar tu entidad Reserva y enviarla a la BLL.
                 * Ajustá las propiedades según cómo hayas armado la clase Reserva en tu BE.
                 
                Reserva nuevaReserva = new Reserva
                {
                    ID_Mesa = mesaBE.ID_Mesa,
                    Fecha = dtpFechaReserva.Value.Date,
                    Hora = dtpHoraReserva.Value.TimeOfDay,
                    CantidadComensales = (int)numComensales.Value,
                    TokenPago = txtTokenTarjeta.Text
                };
                
                BLL_Reserva bllReserva = new BLL_Reserva();
                bllReserva.GenerarReserva(nuevaReserva); 
                */

                // 2. ACTUALIZACIÓN VISUAL INMEDIATA (La magia del Observer)
                // Al deshabilitar la entidad BE, el botón en pantalla se vuelve oscuro 
                // y se bloquea automáticamente sin tener que tocar sus propiedades visuales.
                mesaBE.Habilitada = false;

                MessageBox.Show($"¡Reserva confirmada con éxito!\nMesa: {mesaBE.CodigoUbicacion}\nTe esperamos el {dtpFechaReserva.Value.ToShortDateString()} a las {dtpHoraReserva.Value.ToString("HH:mm")}.",
                                "Reserva Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiamos y ocultamos el panel
                panelReserva.Visible = false;
                mesaSeleccionadaBtn = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error en la Reserva", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
