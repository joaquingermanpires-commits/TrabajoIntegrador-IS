using ABS;
using BLL;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class FrmBackup : Form, IObservadorIdioma
    {
        public FrmBackup()
        {
            InitializeComponent();
            IdiomaBLL.GetInstance().Suscribir(this);
        }
        //Generar back up de la base
        private void btnBackup_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Archivo de Copia de Seguridad SQL (*.bak)|*.bak";
                saveFileDialog.Title = "Guardar Copia de Seguridad";
                saveFileDialog.FileName = $"Backup_IS_{DateTime.Now:dd-MM-yyyy_HH-mm}.bak"; // Nombre sugerido automático
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string rutaDestino = saveFileDialog.FileName;
                    BackupBLL.GetInstance().RealizarBackup(rutaDestino);
                    string usuarioActual = SERVICIOS.Singleton.GetInstance().GetUsuario();
                    BitacoraBLL.GetInstance().RegistrarBitacora(usuarioActual, "INFO", "FrmBackup", $"Backup generado exitosamente en: {rutaDestino}");
                    MessageBox.Show("Copia de seguridad generada con éxito.", "Backup Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                BitacoraBLL.GetInstance().RegistrarBitacora(SERVICIOS.Singleton.GetInstance().GetUsuario(), "ERROR", "FrmBackup", $"Fallo al generar backup: {ex.Message}");
                MessageBox.Show("Error al generar la copia de seguridad: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Restablecer la base
        private void btnRestore_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult confirmacion = MessageBox.Show(
                    "ADVERTENCIA: Restaurar una copia de seguridad sobrescribirá TODOS los datos actuales del sistema. Esta acción no se puede deshacer. ¿Desea continuar?",
                    "Confirmación Crítica", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirmacion == DialogResult.Yes)
                {
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    openFileDialog.Filter = "Archivo de Copia de Seguridad SQL (*.bak)|*.bak";
                    openFileDialog.Title = "Seleccionar Copia de Seguridad para Restaurar";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string rutaOrigen = openFileDialog.FileName;
                        BackupBLL.GetInstance().RealizarRestore(rutaOrigen);
                        string usuarioActual = SERVICIOS.Singleton.GetInstance().GetUsuario();
                        BitacoraBLL.GetInstance().RegistrarBitacora(usuarioActual, "CRITICAL", "FrmBackup", $"Sistema restaurado desde el archivo: {rutaOrigen}");
                        MessageBox.Show("El sistema ha sido restaurado exitosamente. Por seguridad, la aplicación se cerrará. Por favor, inicie sesión nuevamente.", "Restore Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Application.Restart();
                    }
                }
            }
            catch (Exception ex)
            {
                BitacoraBLL.GetInstance().RegistrarBitacora(SERVICIOS.Singleton.GetInstance().GetUsuario(), "ERROR", "FrmBackup", $"Fallo al restaurar sistema: {ex.Message}");
                MessageBox.Show("Error al restaurar la base de datos: " + ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
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