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
        private Layer layer;

        public RenderLayer(Layer layer)
        {
            this.layer = layer;
        }

        public Bitmap GetImage()
        {
            // Create a new bitmap.
            Bitmap bmp = new Bitmap(this.layer.Width, this.layer.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            // Lock the bitmap's bits.  
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            System.Drawing.Imaging.BitmapData bmpData =
                bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite,
                bmp.PixelFormat);

            // Get the address of the first line.
            IntPtr ptr = bmpData.Scan0;

            // Declare an array to hold the bytes of the bitmap.
            int bytes = Math.Abs(bmpData.Stride) * bmp.Height;
            byte[] rgbValues = new byte[bytes];

            // Copy the RGB values into the array.
            //System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);

            for (int i = 0; i < this.layer.Width; i++)
            {
                for (int j = 0; j < this.layer.Height; j++)
                {
                    var d = bmpData.Stride * j + i * 3;
                    var color = this.GetColor(i, j);
                    rgbValues[d + 2] = (byte)color.R;
                    rgbValues[d + 1] = (byte)color.G;
                    rgbValues[d + 0] = (byte)color.B;
                }
            }

            // Copy the RGB values back to the bitmap
            System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);

            // Unlock the bits.
            bmp.UnlockBits(bmpData);

            return bmp;
        }

        private Color GetColor(int i, int j)
        {
            PixelColor pixel = this.layer.GetPixelColor(i, j);

            pixel.Clip();

            return Color.FromArgb((byte)Math.Round(pixel.R * 255.0, MidpointRounding.AwayFromZero), (byte)Math.Round(pixel.G * 255.0, MidpointRounding.ToEven), (byte)Math.Round(pixel.B * 255.0, MidpointRounding.ToEven));
        }
    }
}
