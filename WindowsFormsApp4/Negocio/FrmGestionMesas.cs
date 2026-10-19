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
    public partial class FrmGestionMesas : KryptonForm
    {
        private int idRestauranteActual = 1;
        private MesaBLL bllMesa = new MesaBLL();
        private MesaGraficaFactory fabrica = new MesaGraficaEstandarFactory();

        // Variables para la logica de arrastre 
        private bool isDragging = false;
        private Point mouseOffset;
        private KryptonButton mesaActiva;
        private KryptonButton mesaSeleccionadaBtn = null;
        private bool cargandoDatos = false;

        public FrmGestionMesas()
        {
            InitializeComponent();
        }
        private void FrmGestionMesas_Load(object sender, EventArgs e)
        {
            txtCodigoMesa.Enabled = false;
            numCapacidad.Enabled = false;
            chkHabilitada.Enabled = false;
            CargarSalon();
        }
        private void CargarSalon()
        {
            panelSalon.Controls.Clear();
            IList<Mesa> mesasDelLocal = bllMesa.ObtenerMesas(idRestauranteActual);
            foreach (Mesa mesaBE in mesasDelLocal)
            {
                AgregarMesaAlPanel(mesaBE);
            }
        }
        private void AgregarMesaAlPanel(Mesa mesaBE)
        {
            KryptonButton mesaVisual = fabrica.CrearMesaGrafica(mesaBE, true);

            mesaVisual.MouseDown += Mesa_MouseDown;
            mesaVisual.MouseMove += Mesa_MouseMove;
            mesaVisual.MouseUp += Mesa_MouseUp;

            panelSalon.Controls.Add(mesaVisual);
        }
        // Logica de arrastre
        private void Mesa_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                mesaActiva = (KryptonButton)sender;
                mouseOffset = e.Location;
                mesaActiva.BringToFront();
                SeleccionarMesa(mesaActiva);
            }
        }
        private void SeleccionarMesa(KryptonButton btn)
        {
            mesaSeleccionadaBtn = btn;
            Mesa mesaBE = (Mesa)btn.Tag;
            cargandoDatos = true;
            txtCodigoMesa.Text = mesaBE.CodigoUbicacion;
            numCapacidad.Value = mesaBE.CapacidadPersonas;
            chkHabilitada.Checked = mesaBE.Habilitada;
            txtCodigoMesa.Enabled = true;
            numCapacidad.Enabled = true;
            chkHabilitada.Enabled = true;

            cargandoDatos = false;
        }
        // Calculo de desplazamiento
        private void Mesa_MouseMove(object sender, MouseEventArgs e)          
        {
            if (isDragging && mesaActiva != null)
            {
                mesaActiva.Left += e.X - mouseOffset.X;
                mesaActiva.Top += e.Y - mouseOffset.Y;
            }
        }
        private void Mesa_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
            mesaActiva = null;
        }

        // Eventos panel de adminsitrador de local
        private void txtCodigoMesa_TextChanged(object sender, EventArgs e)
        {
            if (cargandoDatos || mesaSeleccionadaBtn == null) return;

            Mesa mesaBE = (Mesa)mesaSeleccionadaBtn.Tag;
            mesaBE.CodigoUbicacion = txtCodigoMesa.Text;
        }
        private void numCapacidad_ValueChanged(object sender, EventArgs e)
        {
            if (cargandoDatos || mesaSeleccionadaBtn == null) return;

            Mesa mesaBE = (Mesa)mesaSeleccionadaBtn.Tag;
            mesaBE.CapacidadPersonas = (int)numCapacidad.Value;
        }
        private void chkHabilitada_CheckedChanged(object sender, EventArgs e)
        {
            if (cargandoDatos || mesaSeleccionadaBtn == null) return;

            Mesa mesaBE = (Mesa)mesaSeleccionadaBtn.Tag;
            mesaBE.Habilitada = chkHabilitada.Checked;
        }
        // Eventos agregar y guardar
        private void btnAgregarMesa_Click(object sender, EventArgs e)
        {
            Mesa nuevaMesa = new Mesa
            {
                ID_Mesa = 0,
                ID_Restaurante = idRestauranteActual,
                CapacidadPersonas = 2,
                CodigoUbicacion = "NUEVA",
                Habilitada = true,
                PosicionX = 10,
                PosicionY = 10
            };

            AgregarMesaAlPanel(nuevaMesa);
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int mesasGuardadas = 0;

                foreach (Control control in panelSalon.Controls)
                {
                    if (control is KryptonButton btnMesa && btnMesa.Tag is Mesa mesaBE)
                    {
                        mesaBE.PosicionX = btnMesa.Location.X;
                        mesaBE.PosicionY = btnMesa.Location.Y;

                        if (mesaBE.ID_Mesa == 0)
                        {
                            bllMesa.AltaMesa(mesaBE);
                        }
                        else
                        {
                            bllMesa.ModificarMesa(mesaBE);
                        }
                        mesasGuardadas++;
                    }
                }

                MessageBox.Show($"Se guardó la distribución de {mesasGuardadas} mesas con éxito.",
                                "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarSalon(); // Recarga para obtener IDs nuevos
                mesaSeleccionadaBtn = null; // Reseteamos la selección

                txtCodigoMesa.Enabled = false;
                numCapacidad.Enabled = false;
                chkHabilitada.Enabled = false;
                txtCodigoMesa.Text = "";
                numCapacidad.Value = 0;
                chkHabilitada.Checked = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
