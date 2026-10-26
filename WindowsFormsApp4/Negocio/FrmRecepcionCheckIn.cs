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


namespace WindowsFormsApp4.Negocio
{
    public partial class FrmRecepcionCheckIn : KryptonForm, IObservadorIdioma
    {
        private ReservaBLL bllReserva = new ReservaBLL();
        private string usuarioActual = Singleton.GetInstance().GetUsuario();
        private int idRestauranteActual;
        private bool auditoriaAutomaticaActiva = false;

        public FrmRecepcionCheckIn()
        {
            InitializeComponent();
            IdiomaBLL.GetInstance().Suscribir(this);

            // Configuramos el timer de auditoría a 1 minuto (60,000 ms)
            timerAuditoria.Interval = 60000;
            timerAuditoria.Tick += TimerAuditoria_Tick;
        }

        private void FrmRecepcionCheckIn_Load(object sender, EventArgs e)
        {
            // 1. Obtener el local del usuario logueado
            long idUsuarioLogueado = Singleton.GetInstance().GetUsuarioActual().ID_Usuario;
            Restaurante miLocal = new RestauranteBLL().ObtenerRestaurantePorUsuario(idUsuarioLogueado);

            if (miLocal != null)
            {
                idRestauranteActual = miLocal.ID_Restaurante;
                EscribirLog($"Panel de Recepción iniciado para: {miLocal.Nombre}");
            }
            else
            {
                MessageBox.Show("Tu usuario no tiene ningún restaurante asignado.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            AplicarSeguridad();
            EscribirLog("Modo de Auditoría Automática: APAGADO.");
        }

        // ==========================================================
        // 1. SEGURIDAD (COMPOSITE)
        // ==========================================================
        private void AplicarSeguridad()
        {
            Usuario usuarioLogueado = Singleton.GetInstance().GetUsuarioActual();
            bool tieneUsuario = usuarioLogueado != null;

            // Reutilizamos las patentes que ya habíamos creado en SQL
            btnValidar.Enabled = tieneUsuario && PermisoBLL.GetInstance().VerificarPermiso(usuarioLogueado, "btnValidar");
            btnAuditarManual.Enabled = tieneUsuario && PermisoBLL.GetInstance().VerificarPermiso(usuarioLogueado, "btnEjecutarAuditoria");
            btnInterruptorAuto.Enabled = tieneUsuario && PermisoBLL.GetInstance().VerificarPermiso(usuarioLogueado, "btnEjecutarAuditoria");
        }

        // ==========================================================
        // 2. MÓDULO DE CHECK-IN (RECEPCIÓN MANUAL/ALFANUMÉRICA)
        // ==========================================================
        private void btnValidar_Click(object sender, EventArgs e)
        {
            try
            {
                string codigo = txtCodigoIngreso.Text.Trim().ToUpper();
                if (codigo.Length < 6)
                {
                    MessageBox.Show("El código de acceso debe tener 6 caracteres.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Llamamos a la BLL que valida y libera los fondos
                Reserva r = bllReserva.ProcesarCheckInAlfanumerico(codigo, idRestauranteActual);

                if (r != null)
                {
                    lblMesa.Text = $"¡ACCESO PERMITIDO!\nMesa: {r.ID_Mesa} | Comensales: {r.CantidadComensales}";
                    lblMesa.ForeColor = Color.Green;

                    EscribirLog($"[CHECK-IN EXITOSO] Código: {codigo} | Mesa asignada: {r.ID_Mesa}. Seguro financiero liberado.");
                    BitacoraBLL.GetInstance().RegistrarBitacora(usuarioActual, "INFO", "Recepcion", $"Ingreso confirmado para código {codigo}");

                    txtCodigoIngreso.Clear();
                }
                else
                {
                    lblMesa.Text = "CÓDIGO INVÁLIDO O EXPIRADO";
                    lblMesa.ForeColor = Color.Red;
                    EscribirLog($"[RECHAZO] Intento de acceso fallido con código: {codigo}.");
                }
            }
            catch (Exception ex)
            {
                EscribirLog($"[ERROR AL VALIDAR]: {ex.Message}");
                MessageBox.Show(ex.Message, "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==========================================================
        // 3. MÓDULO DE AUDITORÍA (NO-SHOWS Y COBROS)
        // ==========================================================
        private void btnAuditarManual_Click(object sender, EventArgs e)
        {
            EscribirLog("Ejecutando barrido manual de ausencias (No-Shows)...");
            EjecutarAuditoria();
            BitacoraBLL.GetInstance().RegistrarBitacora(usuarioActual, "INFO", "Recepcion", "Auditoría manual de mesas ejecutada.");
        }

        private void btnInterruptorAuto_Click(object sender, EventArgs e)
        {
            auditoriaAutomaticaActiva = !auditoriaAutomaticaActiva;

            if (auditoriaAutomaticaActiva)
            {
                timerAuditoria.Start();
                btnInterruptorAuto.Text = "Detener Auditor Automático";
                btnInterruptorAuto.StateCommon.Back.Color1 = Color.LightCoral;
                EscribirLog("Centinela automático ENCENDIDO. Verificando mesas cada 60 segundos.");
            }
            else
            {
                timerAuditoria.Stop();
                btnInterruptorAuto.Text = "Iniciar Auditor Automático";
                btnInterruptorAuto.StateCommon.Back.Color1 = Color.LightGreen;
                EscribirLog("Centinela automático DETENIDO.");
            }
        }

        private void TimerAuditoria_Tick(object sender, EventArgs e)
        {
            timerAuditoria.Stop(); // Pausamos para evitar solapamientos si la BD está lenta
            EjecutarAuditoria();
            if (auditoriaAutomaticaActiva) timerAuditoria.Start();
        }

        private void EjecutarAuditoria()
        {
            try
            {
                // Libera mesas y captura penalidades de quienes superaron los 15 min de tolerancia
                int cantidadBajas = bllReserva.AuditarNoShowsAutomatico(15);

                if (cantidadBajas > 0)
                {
                    EscribirLog($"[ATENCIÓN] Se cancelaron {cantidadBajas} reserva(s) por ausencia. Penalidades capturadas y mesas liberadas.");
                }
            }
            catch (Exception ex)
            {
                EscribirLog($"[ERROR CRÍTICO] Fallo en auditoría de mesas: {ex.Message}");
                BitacoraBLL.GetInstance().RegistrarBitacora(usuarioActual, "CRITICAL", "Recepcion", $"Error de auditoría: {ex.Message}");
            }
        }

        // ==========================================================
        // 4. UTILIDADES VISUALES Y MULTI-IDIOMA
        // ==========================================================
        private void EscribirLog(string mensaje)
        {
            string linea = $"[{DateTime.Now.ToString("HH:mm:ss")}] - {mensaje}";
            lstLog.AppendText(linea + Environment.NewLine);
            lstLog.ScrollToCaret();
        }

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

        private void FrmRecepcionCheckIn_FormClosed(object sender, FormClosedEventArgs e)
        {
            IdiomaBLL.GetInstance().Desuscribir(this);
            timerAuditoria.Stop();
        }
    }
}
