using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers
{
    public class RenderLayer
    {
        private Layer layer;

        public RenderLayer(Layer layer)
        {
            this.layer = layer;
        }

        public Bitmap GetImage()
        {
            Bitmap image = new Bitmap(this.layer.Width, this.layer.Height);

            Rectangle rect = new Rectangle(0, 0, this.layer.Width, this.layer.Height);
            BitmapData bitmapData = image.LockBits(rect, System.Drawing.Imaging.ImageLockMode.WriteOnly, PixelFormat.Format32bppRgb);

            unsafe
            {

                for (int x = 0; x < this.layer.Width; x++)
                {
                    for (int y = 0; y < this.layer.Height; y++)
                    {
                        var pix = (byte*)(bitmapData.Scan0 + bitmapData.Stride * y + x * 4);
                        var colorPixel = this.layer.GetPixelColor(x, y);

                        colorPixel.Clip();

                        pix[0] = (byte)(colorPixel.R * 255.0);
                        pix[1] = (byte)(colorPixel.G * 255.0);
                        pix[2] = (byte)(colorPixel.B * 255.0);
                    }
                }
            }

            image.UnlockBits(bitmapData);

            return image;
        }

        private Color GetColor(int i, int j)
        {
            PixelColor pixel = this.layer.GetPixelColor(i, j);

            pixel.Clip();

            return Color.FromArgb((byte)Math.Round(pixel.R, MidpointRounding.ToEven), (byte)Math.Round(pixel.G, MidpointRounding.ToEven), (byte)Math.Round(pixel.B, MidpointRounding.ToEven));
        }
    }
}
