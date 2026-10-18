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
        public FrmNuevaReserva()
        {
            InitializeComponent();
        }
        private void FrmNuevaReserva_Load(object sender, EventArgs e)
        {
            DibujarSalon();
        }
        private void DibujarSalon()
        {
            try
            {
                MesaBLL bllMesa = new MesaBLL();
                List<Mesa> mesasDelLocal = bllMesa.ObtenerMesas(idRestauranteActual);
                MesaGraficaFactory fabrica = new MesaGraficaEstandarFactory();

                // Limpiamos el panel por si se vuelve a cargar
                panelSalon.Controls.Clear();
                foreach (Mesa mesaBE in mesasDelLocal)
                {
                    // La fábrica crea el botón de Krypton y lo configura
                    KryptonButton mesaVisual = fabrica.CrearMesaGrafica(mesaBE);
                    mesaVisual.Click += MesaVisual_Click;
                    panelSalon.Controls.Add(mesaVisual);
                    int cantidadmesa =+ 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el salón: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void MesaVisual_Click(object sender, EventArgs e)
        {
            KryptonButton btnClickeado = (KryptonButton)sender;
            Mesa mesaSeleccionada = (Mesa)btnClickeado.Tag;
            if (mesaSeleccionada.Habilitada)
            {
                KryptonMessageBox.Show($"Seleccionaste la mesa: {mesaSeleccionada.CodigoUbicacion}\nCapacidad: {mesaSeleccionada.CapacidadPersonas} personas.",
                                       "Mesa Disponible");
            }
        }
    }
}
