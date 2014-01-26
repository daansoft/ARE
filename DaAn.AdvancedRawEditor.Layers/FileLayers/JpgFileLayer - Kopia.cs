using DaAn.AdvancedRawEditor.Layers.Abstracts;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers.FileLayers
{
    public class JpgFileLayer : Layer, IInputLayer
    {
        private PixelColor[][] bitmatData = null;


        public JpgFileLayer(Guid identificator, string fileName) :
            base(identificator, 0)
        {
            this.SetInputData(fileName);
        }

        public override int Width
        {
            get
            {
                return this.bitmatData.Length;
            }
        }

        public override int Height
        {
            get
            {
                return this.bitmatData[0].Length;
            }
        }

        public override IConnectionBuilder GetConnectionBuilder()
        {
            return new EmptyConnectionBuilder();
        }

        public override PixelColor GetPixelColor(int x, int y)
        {
            return this.bitmatData[x][y];
        }

        public void SetInputData(string fileName)
        {
            Bitmap bmp = new Bitmap(fileName);

            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData bmpData = bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly, bmp.PixelFormat);

            // Get the address of the first line.
            IntPtr ptr = bmpData.Scan0;

            this.bitmatData = new PixelColor[bmp.Width][];

            unsafe
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    this.bitmatData[x] = new PixelColor[bmp.Height];

                    for (int y = 0; y < bmp.Height; y++)
                    {
                        var pix = (byte*)(bmpData.Scan0 + (bmpData.Stride * y) + x * 3);

                        this.bitmatData[x][y] = PixelColor.FromRGB(pix[0], pix[1], pix[2]);
                    }
                }
            }

            // Unlock the bits.
            bmp.UnlockBits(bmpData);
        }
    }
}
