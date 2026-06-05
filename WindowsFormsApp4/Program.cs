using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 1. EJECUTAMOS LA VERIFICACIÓN DE INTEGRIDAD
            string resultadoIntegridad = IntegridadBLL.GetInstance().VerificarIntegridad();

            //if (!string.IsNullOrEmpty(resultadoIntegridad))
            //{
            //    // SI HAY ERROR: Mostramos el mensaje crítico
            //    MessageBox.Show(resultadoIntegridad + "\n\nEl sistema ha sido bloqueado por razones de seguridad. Comuníquese con el Administrador para realizar una restauración.",
            //                    "Fallo Crítico de Seguridad (DVH/DVV)",
            //                    MessageBoxButtons.OK,
            //                    MessageBoxIcon.Error);

            //    // Opcional: Acá podrías abrir un "FrmRestaurarBD" exclusivo para el Súper Admin en lugar de cerrar.
            //    // Por ahora, simplemente cerramos la app para evitar que usen datos corruptos.
            //    Application.Exit();
            //}
            //else
            //{
            //    // SI TODO ESTÁ BIEN: Arranca el sistema normalmente
            //    Application.Run(new FrmLogin());
            //}
            Application.Run(new FrmLogin());
        }
    }
}
