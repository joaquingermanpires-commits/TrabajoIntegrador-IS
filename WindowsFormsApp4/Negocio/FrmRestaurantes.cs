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
    public partial class FrmRestaurantes : KryptonForm, IObservadorIdioma
    {
        private RestauranteBLL bll;
        private string usuario = Singleton.GetInstance().GetUsuario();

        public FrmRestaurantes()
        {
            InitializeComponent();
            bll = new RestauranteBLL();
            ActualizarDGV();
            IdiomaBLL.GetInstance().Suscribir(this);
        }

        private void FrmRestaurantes_Load(object sender, EventArgs e)
        {
            AplicarSeguridad();
            CargarComboUsuarios();
        }

        private void AplicarSeguridad()
        {
            Usuario usuarioLogueado = Singleton.GetInstance().GetUsuarioActual();
            bool tieneUsuario = usuarioLogueado != null;

            BtnAlta.Enabled = tieneUsuario && PermisoBLL.GetInstance().VerificarPermiso(usuarioLogueado, "btnAltaRestaurante");
            BtnModif.Enabled = tieneUsuario && PermisoBLL.GetInstance().VerificarPermiso(usuarioLogueado, "btnModificarRestaurante");
            BtnBaja.Enabled = tieneUsuario && PermisoBLL.GetInstance().VerificarPermiso(usuarioLogueado, "btnBajaRestaurante");
        }
        private void CargarComboUsuarios()
        {
            try
            {
                cmbUsuarios.DataSource = UsuarioBLL.GetInstance().ObtenerUsuarios();
                cmbUsuarios.DisplayMember = "Nombre_Usuario"; 
                cmbUsuarios.ValueMember = "ID_Usuario";       
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los usuarios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarDGV()
        {
            dgvRestaurantes.DataSource = null;
            dgvRestaurantes.DataSource = bll.ObtenerTodos();
            this.dgvRestaurantes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            if (dgvRestaurantes.Columns["ID_Restaurante"] != null) dgvRestaurantes.Columns["ID_Restaurante"].Visible = false;
            if (dgvRestaurantes.Columns["ID_Usuario"] != null) dgvRestaurantes.Columns["ID_Usuario"].Visible = false;
            if (dgvRestaurantes.Columns["TiempoMinimoPermitido"] != null) dgvRestaurantes.Columns["TiempoMinimoPermitido"].Visible = false;
            if (dgvRestaurantes.Columns["TiempoMaximoPermitido"] != null) dgvRestaurantes.Columns["TiempoMaximoPermitido"].Visible = false;
            if (dgvRestaurantes.Columns["PorcentajeMaximoOcupacion"] != null) dgvRestaurantes.Columns["PorcentajeMaximoOcupacion"].Visible = false;
        }

        private void dgvRestaurantes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtNombre.Text = dgvRestaurantes.Rows[e.RowIndex].Cells["Nombre"].Value?.ToString();
                txtDireccion.Text = dgvRestaurantes.Rows[e.RowIndex].Cells["Direccion"].Value?.ToString();
                txtTelefono.Text = dgvRestaurantes.Rows[e.RowIndex].Cells["Telefono"].Value?.ToString();
                if (dgvRestaurantes.Rows[e.RowIndex].Cells["ID_Usuario"].Value != null)
                {
                    cmbUsuarios.SelectedValue = Convert.ToInt64(dgvRestaurantes.Rows[e.RowIndex].Cells["ID_Usuario"].Value);
                }
            }
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtDireccion.Clear();
        }

        private void BtnAlta_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbUsuarios.SelectedValue == null)
                {
                    MessageBox.Show("Debe asignar un usuario a este restaurante.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Restaurante nuevoRestaurante = new Restaurante
                {
                    ID_Usuario = Convert.ToInt64(cmbUsuarios.SelectedValue),
                    Nombre = txtNombre.Text.Trim(),
                    Direccion = txtDireccion.Text.Trim(),
                    Telefono = txtTelefono.Text.Trim(),
                    TiempoMinimoPermitido = 30,
                    TiempoMaximoPermitido = 120,
                    PorcentajeMaximoOcupacion = 100
                };

                bll.RegistrarRestaurante(nuevoRestaurante);
                MessageBox.Show("Restaurante creado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BitacoraBLL.GetInstance().RegistrarBitacora(usuario, "INFO", "FrmRestaurantes", $"Restaurante '{nuevoRestaurante.Nombre}' creado y asignado al usuario ID {nuevoRestaurante.ID_Usuario}.");

                ActualizarDGV();
                LimpiarCampos();
                IdiomaBLL.GetInstance().Notificar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al Crear", MessageBoxButtons.OK, MessageBoxIcon.Error);
                BitacoraBLL.GetInstance().RegistrarBitacora(usuario, "CRITICAL", "FrmRestaurantes", $"Error del sistema (Alta): {ex.Message}");
            }
        }

        private void BtnModif_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvRestaurantes.CurrentRow == null)
                {
                    MessageBox.Show("Por favor, seleccione un restaurante de la lista para modificar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                int idSeleccionado = Convert.ToInt32(dgvRestaurantes.CurrentRow.Cells["ID_Restaurante"].Value);
                if (idSeleccionado == 0)
                {
                    MessageBox.Show("Error crítico: El ID del restaurante es 0. La grilla no está cargando el ID correctamente.", "Fallo de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Restaurante restauranteModificado = new Restaurante
                {
                    ID_Restaurante = idSeleccionado,
                    ID_Usuario = Convert.ToInt64(cmbUsuarios.SelectedValue),
                    Nombre = txtNombre.Text.Trim(),
                    Direccion = txtDireccion.Text.Trim(),
                    Telefono = txtTelefono.Text.Trim()
                };
                bool guardoBien = bll.ActualizarRestaurante(restauranteModificado);

                if (guardoBien)
                {
                    MessageBox.Show("El restaurante ha sido modificado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BitacoraBLL.GetInstance().RegistrarBitacora(usuario, "INFO", "FrmRestaurantes", $"Restaurante ID {idSeleccionado} modificado exitosamente.");

                    ActualizarDGV();
                    LimpiarCampos();
                    IdiomaBLL.GetInstance().Notificar();
                }
                else
                {
                    MessageBox.Show("La base de datos no pudo aplicar los cambios. Es posible que el registro ya no exista.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al modificar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                BitacoraBLL.GetInstance().RegistrarBitacora(usuario, "CRITICAL", "FrmRestaurantes", $"Error del sistema (Modif): {ex.Message}");
            }
        }

        private void BtnBaja_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvRestaurantes.CurrentRow == null) return;

                int idSeleccionado = Convert.ToInt32(dgvRestaurantes.CurrentRow.Cells["ID_Restaurante"].Value);

                DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea eliminar este restaurante?", "Confirmar Baja", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    bll.EliminarRestaurante(idSeleccionado);

                    MessageBox.Show("Restaurante eliminado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BitacoraBLL.GetInstance().RegistrarBitacora(usuario, "INFO", "FrmRestaurantes", $"Restaurante ID {idSeleccionado} eliminado exitosamente.");

                    ActualizarDGV();
                    LimpiarCampos();
                    IdiomaBLL.GetInstance().Notificar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                BitacoraBLL.GetInstance().RegistrarBitacora(usuario, "CRITICAL", "FrmRestaurantes", $"Error del sistema (Baja): {ex.Message}");
            }
        }

        public void ActualizarIdioma()
        {
            var traducciones = IdiomaBLL.GetInstance().ObtenerTraducciones();
            if (this.Tag != null && !string.IsNullOrWhiteSpace(this.Tag.ToString()))
            {
                string claveTagFormulario = this.Tag.ToString();
                if (traducciones.ContainsKey(claveTagFormulario))
                {
                    this.Text = traducciones[claveTagFormulario];
                }
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
                    if (traducciones.ContainsKey(claveTag))
                    {
                        c.Text = traducciones[claveTag];
                    }
                }
                if (c.Controls.Count > 0)
                {
                    TraducirControles(c.Controls, traducciones);
                }
            }
        }

        private void FrmRestaurantes_FormClosed(object sender, FormClosedEventArgs e)
        {
            IdiomaBLL.GetInstance().Desuscribir(this);
        }
    }
}
