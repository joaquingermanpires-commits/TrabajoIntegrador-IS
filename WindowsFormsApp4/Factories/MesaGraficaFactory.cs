using BE;
using Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4.Factories
{
    public abstract class MesaGraficaFactory
    {
        public abstract KryptonButton CrearMesaGrafica(Mesa mesaBE, bool esModoAdmin = false);
    }

    public class MesaGraficaEstandarFactory : MesaGraficaFactory
    {
        public override KryptonButton CrearMesaGrafica(Mesa mesaBE, bool esModoAdmin = false)
        {
            //Detalles visuales de la mesa
            KryptonButton btnMesa = new KryptonButton();
            btnMesa.Width = 50;
            btnMesa.Height = 70;
            btnMesa.Location = new Point(mesaBE.PosicionX, mesaBE.PosicionY);
            btnMesa.Tag = mesaBE;
            btnMesa.Values.Text = mesaBE.CodigoUbicacion;
            btnMesa.StateCommon.Content.ShortText.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnMesa.StateCommon.Back.ImageAlign = PaletteRectangleAlign.Control;
            btnMesa.StateCommon.Back.ImageStyle = PaletteImageStyle.CenterMiddle;
            btnMesa.StateCommon.Border.DrawBorders = PaletteDrawBorders.None;
            btnMesa.StateCommon.Border.Width = 0; 
            btnMesa.StateCommon.Border.Rounding = 0;
            btnMesa.StateCommon.Content.Padding = new Padding(0);

            ConfigurarEstadoVisual(btnMesa, mesaBE, esModoAdmin);

            mesaBE.OnMesaModificada += (mesaActualizada) =>
            {
                btnMesa.Values.Text = mesaActualizada.CodigoUbicacion;
                ConfigurarEstadoVisual(btnMesa, mesaActualizada, esModoAdmin);
                btnMesa.Invalidate();
            };

            return btnMesa;
        }
        private void ConfigurarEstadoVisual(KryptonButton btn, Mesa mesa, bool esModoAdmin)
        {
            Size tamañoBoton = new Size(50, 70);
            if (mesa.Habilitada) //(Mesa Libre)
            {
                btn.StateCommon.Back.Image = new Bitmap(Properties.Resources.MesaLibre, tamañoBoton);
                btn.Cursor = Cursors.Hand;
                btn.Enabled = true;
                btn.StateCommon.Content.ShortText.Color1 = Color.Black;
            }
            else                //(Mesa Ocupada)
            {
                btn.StateCommon.Back.Image = new Bitmap(Properties.Resources.MesaOcupada, tamañoBoton);
                if (!esModoAdmin) btn.Enabled = false;
                btn.StateCommon.Content.ShortText.Color1 = Color.White;
            }
        }
    }
}
