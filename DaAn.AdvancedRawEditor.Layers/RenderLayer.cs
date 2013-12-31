using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers
{
    public class RenderLayer
    {
        private ILayer layer;

        public RenderLayer(ILayer layer)
        {
            this.layer = layer;
        }

        public void Render(Graphics graphics)
        {
            Bitmap image = new Bitmap(this.layer.Width, this.layer.Height);

            for (int i = 0; i < this.layer.Width; i++)
            {
                for (int j = 0; j < this.layer.Height; j++)
                {
                    image.SetPixel(i, j, this.GetColor(i, j));
                }
            }

            graphics.DrawImage(image, 0, 0);
        }

        private Color GetColor(int i, int j)
        {
            PixelValue pixel = this.layer.GetPixelValue(i, j);

            pixel.Clip();

            return Color.FromArgb((byte)pixel.R, (byte)pixel.G, (byte)pixel.B);
        }
    }
}
