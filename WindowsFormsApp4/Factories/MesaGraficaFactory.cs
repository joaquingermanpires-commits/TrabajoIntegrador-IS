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
            KryptonButton btnMesa = new KryptonButton();
            btnMesa.Tag = mesaBE;

            Action AplicarTamañoYPosicion = () =>
            {
                int cantidadModulos = (int)Math.Ceiling(mesaBE.CapacidadPersonas / 2.0);
                if (cantidadModulos < 1) cantidadModulos = 1;

                if (mesaBE.EsVertical)
                {
                    btnMesa.Width = 71; // Alto pasa a ser el ancho
                    btnMesa.Height = 51 * cantidadModulos; // Ancho pasa a ser el alto apilado
                }
                else
                {
                    btnMesa.Width = 53 * cantidadModulos;
                    btnMesa.Height = 71;
                }
            };

            AplicarTamañoYPosicion();
            btnMesa.Location = new Point(mesaBE.PosicionX, mesaBE.PosicionY);

            btnMesa.Values.Text = mesaBE.CodigoUbicacion;
            btnMesa.StateCommon.Content.ShortText.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

            btnMesa.StateCommon.Border.DrawBorders = PaletteDrawBorders.None;
            btnMesa.StateCommon.Border.Width = 0;
            btnMesa.StateCommon.Border.Rounding = 0;
            btnMesa.StateCommon.Content.Padding = new Padding(0);
            btnMesa.StateCommon.Content.AdjacentGap = 0;

            ConfigurarEstadoVisual(btnMesa, mesaBE, esModoAdmin);

            mesaBE.OnMesaModificada += (mesaActualizada) =>
            {
                AplicarTamañoYPosicion();
                btnMesa.Values.Text = mesaActualizada.CodigoUbicacion;
                ConfigurarEstadoVisual(btnMesa, mesaActualizada, esModoAdmin);
                btnMesa.Invalidate();
            };

            return btnMesa;
        }
        private void ConfigurarEstadoVisual(KryptonButton btn, Mesa mesa, bool esModoAdmin)
        {
            Size tamañoBoton;
            RotateFlipType tipoRotacion;
            int ajusteX, ajusteY;

            // rotacion
            if (mesa.EsVertical)
            {
                tamañoBoton = new Size(71, 51);
                tipoRotacion = RotateFlipType.Rotate90FlipNone;
                ajusteX = 1; ajusteY = 0; // Calibracion manual
            }
            else
            {
                tamañoBoton = new Size(51, 71);
                tipoRotacion = RotateFlipType.RotateNoneFlipNone;
                ajusteX = 2; ajusteY = 1; // Calibracion manual
            }
            Image imgBase = mesa.Habilitada ? Properties.Resources.MesaLibre : Properties.Resources.MesaOcupada;
            if (tipoRotacion != RotateFlipType.RotateNoneFlipNone)
            {
                Bitmap imgRotada = new Bitmap(imgBase);
                imgRotada.RotateFlip(tipoRotacion);
                imgBase = imgRotada;
            }

            btn.StateCommon.Back.ImageStyle = PaletteImageStyle.Tile;
            btn.StateCommon.Back.ImageAlign = PaletteRectangleAlign.Control;
            btn.StateCommon.Back.Image = ObtenerImagenAlineada(imgBase, tamañoBoton, ajusteX, ajusteY);

            if (mesa.Habilitada)
            {
                btn.Cursor = Cursors.Hand;
                btn.Enabled = true;
                btn.StateCommon.Content.ShortText.Color1 = Color.Black;
            }
            else
            {
                if (!esModoAdmin) btn.Enabled = false;
                btn.StateCommon.Content.ShortText.Color1 = Color.White;
            }
        }
        // Método para reposicionar la imagen al píxel
        private Bitmap ObtenerImagenAlineada(Image original, Size tamañoDestino, int offsetX, int offsetY)
        {
            Bitmap lienzo = new Bitmap(tamañoDestino.Width, tamañoDestino.Height);
            using (Graphics g = Graphics.FromImage(lienzo))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.DrawImage(original,
                    new Rectangle(offsetX, offsetY, tamañoDestino.Width, tamañoDestino.Height),
                    new Rectangle(0, 0, original.Width, original.Height),
                    GraphicsUnit.Pixel);
            }
            return lienzo;
        }
    }
}
