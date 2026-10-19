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

namespace WindowsFormsApp4.Negocio
{
    public partial class FrmConfiguracionLocal : KryptonForm
    {
        private int idRestauranteActual = 1;
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
            if (cmbDiaSemana.Items.Count > 0) cmbDiaSemana.SelectedIndex = 1;
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
            // Opcional: Llenar el DataGridView con los horarios vigentes
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
                // Si la BLL detecta que se intenta cerrar un día con reservas futuras, termina acá
                MessageBox.Show(ex.Message, "Acción Bloqueada", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        private void CargarPreferenciasDieteticas()
        {
            // 1. Cargamos TODAS las dietas del sistema en el CheckedListBox
            clbPreferencias.DataSource = bllPreferencia.ObtenerTodas();
            clbPreferencias.DisplayMember = "Descripcion";
            clbPreferencias.ValueMember = "ID_Preferencia";

            // 2. Buscamos cuáles dietas YA TIENE este restaurante en la base de datos
            IList<PreferenciaDietetica> misPreferencias = bllPreferencia.ObtenerPreferenciasPorRestaurante(idRestauranteActual);

            // 3. Recorremos el cuadro y tildamos automáticamente las que coincidan
            for (int i = 0; i < clbPreferencias.Items.Count; i++)
            {
                PreferenciaDietetica prefGlobal = (PreferenciaDietetica)clbPreferencias.Items[i];

                // Si la dieta global está en "mis preferencias", la marcamos con un Check
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

                // Recorremos solamente los items que el gerente dejó tildados
                foreach (PreferenciaDietetica pref in clbPreferencias.CheckedItems)
                {
                    idsSeleccionados.Add(pref.ID_Preferencia);
                }

                // Se los mandamos a la BLL para que haga el Wipe & Replace
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
    }
}
