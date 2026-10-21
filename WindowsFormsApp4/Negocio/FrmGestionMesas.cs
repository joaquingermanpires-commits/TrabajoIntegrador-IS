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
using WindowsFormsApp4.Factories;

namespace WindowsFormsApp4.Negocio
{
    public partial class FrmGestionMesas : KryptonForm
    {
        private int idRestauranteActual;
        private MesaBLL bllMesa = new MesaBLL();
        private MesaGraficaFactory fabrica = new MesaGraficaEstandarFactory();

        // Variables para la logica de arrastre 
        private bool isDragging = false;
        private Point mouseOffset;
        private KryptonButton mesaActiva;
        private KryptonButton mesaSeleccionadaBtn = null;
        private bool cargandoDatos = false;
        private Point posicionOriginal;

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
            btnAgregarMesa.Enabled = tieneUsuario && PermisoBLL.GetInstance().VerificarPermiso(usuarioLogueado, "btnAgregarMesa");
            btnGuardar.Enabled = tieneUsuario && PermisoBLL.GetInstance().VerificarPermiso(usuarioLogueado, "btnGuardarMesas");
            btnRotarMesa.Enabled = tieneUsuario && PermisoBLL.GetInstance().VerificarPermiso(usuarioLogueado, "btnRotarMesa");
            btnEliminarMesa.Enabled = tieneUsuario && PermisoBLL.GetInstance().VerificarPermiso(usuarioLogueado, "btnEliminarMesa");
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
                posicionOriginal = mesaActiva.Location;
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
            if (isDragging && mesaActiva != null)
            {
                if (!EsPosicionValida(mesaActiva, mesaActiva.Left, mesaActiva.Top, 15))
                {
                    MessageBox.Show("Las mesas no pueden superponerse. Dejá un pasillo de espacio.", "Colisión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    mesaActiva.Location = posicionOriginal;
                }
                else
                {
                    Mesa mesaBE = (Mesa)mesaActiva.Tag;
                    mesaBE.PosicionX = mesaActiva.Left;
                    mesaBE.PosicionY = mesaActiva.Top;
                    bllMesa.ActualizarMesa(mesaBE);
                }
                isDragging = false;
                mesaActiva = null;
            }
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
                            bllMesa.ActualizarMesa(mesaBE);
                        }
                        mesasGuardadas++;
                    }
                }

                MessageBox.Show($"Se guardó la distribución de {mesasGuardadas} mesas con éxito.",
                                "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarSalon();
                mesaSeleccionadaBtn = null; 
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
        private bool EsPosicionValida(Control mesaQueSeMueve, int nuevaPosicionX, int nuevaPosicionY, int distanciaMinima = 15)
        {
            Rectangle rectMovido = new Rectangle(
                nuevaPosicionX - distanciaMinima,
                nuevaPosicionY - distanciaMinima,
                mesaQueSeMueve.Width + (distanciaMinima * 2),
                mesaQueSeMueve.Height + (distanciaMinima * 2)
            );
            foreach (Control controlExistente in panelSalon.Controls)
            {
                if (controlExistente is KryptonButton && controlExistente != mesaQueSeMueve)
                {
                    Rectangle rectExistente = new Rectangle(
                        controlExistente.Location.X,
                        controlExistente.Location.Y,
                        controlExistente.Width,
                        controlExistente.Height
                    );
                    if (rectMovido.IntersectsWith(rectExistente))
                    {
                        return false;
                    }
                }
            }
            return true; // No obstruye ninguna mesa
        }
        private void btnRotarMesa_Click(object sender, EventArgs e)
        {
            if (mesaSeleccionadaBtn == null) return;

            Mesa mesaBE = (Mesa)mesaSeleccionadaBtn.Tag;

            //Guardado de los valores viejos por si choca
            bool orientacionAnterior = mesaBE.EsVertical;
            int anchoAnterior = mesaSeleccionadaBtn.Width;
            int altoAnterior = mesaSeleccionadaBtn.Height;
            mesaBE.EsVertical = !mesaBE.EsVertical;
            // Calculo de cuánto mediría estando rotada
            int cantidadModulos = (int)Math.Ceiling(mesaBE.CapacidadPersonas / 2.0);
            if (cantidadModulos < 1) cantidadModulos = 1;
            mesaSeleccionadaBtn.Width = mesaBE.EsVertical ? 71 : 51 * cantidadModulos;
            mesaSeleccionadaBtn.Height = mesaBE.EsVertical ? 51 * cantidadModulos : 71;
            // "radar" de posiciones
            if (!EsPosicionValida(mesaSeleccionadaBtn, mesaSeleccionadaBtn.Left, mesaSeleccionadaBtn.Top, 15))
            {
                MessageBox.Show("No hay espacio suficiente para rotar la mesa aquí.", "Colisión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mesaSeleccionadaBtn.Width = anchoAnterior;
                mesaSeleccionadaBtn.Height = altoAnterior;
                mesaBE.EsVertical = orientacionAnterior;
            }
            else
            {
                mesaSeleccionadaBtn.Width = anchoAnterior;
                mesaSeleccionadaBtn.Height = altoAnterior;
                mesaBE.ModificarMesa(mesaBE.CodigoUbicacion, mesaBE.CapacidadPersonas, mesaBE.Habilitada);
                bllMesa.ActualizarMesa(mesaBE);
            }
        }

        private void btnEliminarMesa_Click(object sender, EventArgs e)
        {
            if (mesaSeleccionadaBtn == null) return;

            Mesa mesaBE = (Mesa)mesaSeleccionadaBtn.Tag;
            // Doble confirmación por ser una acción destructiva
            DialogResult respuesta = MessageBox.Show($"¿Estás seguro que querés eliminar permanentemente la mesa {mesaBE.CodigoUbicacion} del salón?", "Confirmar Baja", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                try
                {
                    // Llama a la BLL. Si tiene reservas, va a saltar el catch
                    if (bllMesa.EliminarMesa(mesaBE.ID_Mesa))
                    {
                        panelSalon.Controls.Remove(mesaSeleccionadaBtn);
                        mesaSeleccionadaBtn.Dispose();
                        mesaSeleccionadaBtn = null;
                        txtCodigoMesa.Clear();
                        numCapacidad.Value = 1;
                        txtCodigoMesa.Enabled = false;
                        numCapacidad.Enabled = false;
                        chkHabilitada.Enabled = false;

                        MessageBox.Show("Mesa eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "No se puede eliminar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}

