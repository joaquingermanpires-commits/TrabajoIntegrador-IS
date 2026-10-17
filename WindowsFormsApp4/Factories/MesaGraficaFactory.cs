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
        // El Factory Method ahora devuelve específicamente un KryptonButton
        public abstract KryptonButton CrearMesaGrafica(Mesa mesaBE);
    }

    // 2. Creador Concreto
    public class MesaGraficaEstandarFactory : MesaGraficaFactory
    {
        public override KryptonButton CrearMesaGrafica(Mesa mesaBE)
        {
            // uso de Krypton(extension)
            KryptonButton btnMesa = new KryptonButton();
            btnMesa.Width = 50;
            btnMesa.Height = 50;

            // Asignamos las coordenadas dinámicas provenientes de la BD
            btnMesa.Location = new Point(mesaBE.PosicionX, mesaBE.PosicionY);
            btnMesa.Tag = mesaBE;
            btnMesa.Text = mesaBE.CodigoUbicacion;

            // Personalizamcion del diseño del texto e imagen(Krypton usa StateCommon para estilos globales)
            btnMesa.StateCommon.Content.ShortText.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnMesa.StateCommon.Content.ShortText.Color1 = Color.White;
            btnMesa.StateCommon.Back.ImageAlign = PaletteRectangleAlign.Control;
            btnMesa.StateCommon.Back.ImageStyle = PaletteImageStyle.Stretch;

            if (mesaBE.Habilitada) // Mesa libre
            {
                btnMesa.StateCommon.Back.Image = Properties.Resources.MesaLibre;
                btnMesa.Cursor = Cursors.Hand;
            }
            else // Mesa desabilithada
            {
                btnMesa.StateCommon.Back.Image = Properties.Resources.MesaOcupada;
                btnMesa.Enabled = false;
            }

            return btnMesa;
        }
    }
}
