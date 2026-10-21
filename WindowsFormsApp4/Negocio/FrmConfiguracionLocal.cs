using ABS;
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

namespace WindowsFormsApp4.Negocio
{
    public partial class FrmConfiguracionLocal : KryptonForm, IObservadorIdioma
    {
        private int idRestauranteActual;
        private RestauranteBLL bllRestaurante = new RestauranteBLL();
        private HorarioAtencionBLL bllHorario = new HorarioAtencionBLL();
        private PreferenciaBLL bllPreferencia = new PreferenciaBLL();
        public FrmConfiguracionLocal()
        {
            InitializeComponent();
        }

        private void FrmConfiguracionLocal_Load(object sender, EventArgs e)
        {
            CargarReglasGlobales();
            CargarGrillaHorarios();
            CargarPreferenciasDieteticas();
            AplicarSeguridad();
            if (cmbDiaSemana.Items.Count > 0) cmbDiaSemana.SelectedIndex = 1;
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

            btnGuardarReglas.Enabled = tieneUsuario && PermisoBLL.GetInstance().VerificarPermiso(usuarioLogueado, "btnGuardarReglasGlobales");
            btnGuardarHorario.Enabled = tieneUsuario && PermisoBLL.GetInstance().VerificarPermiso(usuarioLogueado, "btnGuardarHorarios");
            btnAgregar.Enabled = tieneUsuario && PermisoBLL.GetInstance().VerificarPermiso(usuarioLogueado, "btnGuardarPreferencias");
        }

        private void CargarReglasGlobales()
        {
            try
            {
                Restaurante local = bllRestaurante.ObtenerPerfilRestaurante(idRestauranteActual);

                if (local != null)
                {
                    numTiempoMinimo.Value = local.TiempoMinimoPermitido;
                    numTiempoMaximo.Value = local.TiempoMaximoPermitido;
                    numOcupacion.Value = local.PorcentajeMaximoOcupacion;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar reglas: " + ex.Message);
            }
        }

        private void btnGuardarReglas_Click(object sender, EventArgs e)
        {
            try
            {
                Restaurante localActualizado = new Restaurante
                {
                    ID_Restaurante = idRestauranteActual,
                    TiempoMinimoPermitido = (int)numTiempoMinimo.Value,
                    TiempoMaximoPermitido = (int)numTiempoMaximo.Value,
                    PorcentajeMaximoOcupacion = numOcupacion.Value
                };
                bllRestaurante.ActualizarReglasGlobales(localActualizado);
                MessageBox.Show("Reglas actualizadas correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CargarGrillaHorarios()
        {
            dgvHorarios.DataSource = bllHorario.ObtenerHorarios(idRestauranteActual);
        }

        private void btnGuardarHorario_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbDiaSemana.SelectedIndex < 0)
                {
                    MessageBox.Show("Debe seleccionar un día de la semana.");
                    return;
                }

                HorarioAtencion nuevoHorario = new HorarioAtencion
                {
                    ID_Restaurante = idRestauranteActual,
                    DiaSemana = (DayOfWeek)cmbDiaSemana.SelectedIndex, // 0=Dom, 1=Lun, etc.
                    Habilitado = chkHabilitado.Checked,
                    HoraApertura = dtpApertura.Value.TimeOfDay,
                    HoraCierre = dtpCierre.Value.TimeOfDay
                };
                string mensajeResultado = bllHorario.ConfigurarHorario(nuevoHorario);

                MessageBox.Show(mensajeResultado, "Configuración de Horario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarGrillaHorarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Acción Bloqueada", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        private void CargarPreferenciasDieteticas()
        {
            clbPreferencias.DataSource = bllPreferencia.ObtenerTodas();
            clbPreferencias.DisplayMember = "Descripcion";
            clbPreferencias.ValueMember = "ID_Preferencia";
            IList<PreferenciaDietetica> misPreferencias = bllPreferencia.ObtenerPreferenciasPorRestaurante(idRestauranteActual);
            for (int i = 0; i < clbPreferencias.Items.Count; i++)
            {
                PreferenciaDietetica prefGlobal = (PreferenciaDietetica)clbPreferencias.Items[i];
                if (misPreferencias.Any(p => p.ID_Preferencia == prefGlobal.ID_Preferencia))
                {
                    clbPreferencias.SetItemChecked(i, true);
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                List<int> idsSeleccionados = new List<int>();
                foreach (PreferenciaDietetica pref in clbPreferencias.CheckedItems)
                {
                    idsSeleccionados.Add(pref.ID_Preferencia);
                }
                if (bllPreferencia.ActualizarPreferenciasRestaurante(idRestauranteActual, idsSeleccionados))
                {
                    MessageBox.Show("¡Preferencias dietéticas actualizadas con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Metodos del formulario
        public void ActualizarIdioma()
        {
            var traducciones = IdiomaBLL.GetInstance().ObtenerTraducciones();

            if (this.Tag != null && !string.IsNullOrWhiteSpace(this.Tag.ToString()))
            {
                string claveTagFormulario = this.Tag.ToString();
                if (traducciones.ContainsKey(claveTagFormulario)) this.Text = traducciones[claveTagFormulario];
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
        private void FrmBackup_FormClosed(object sender, FormClosedEventArgs e)
        {
            IdiomaBLL.GetInstance().Desuscribir(this);
        }
    }
}
