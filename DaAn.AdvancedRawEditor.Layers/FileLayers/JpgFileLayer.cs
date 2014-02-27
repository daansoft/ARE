using DaAn.AdvancedRawEditor.Layers.Abstracts;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers.FileLayers
{
    public class JpgFileLayer : Layer, IInputLayer
    {
        public Bitmap bitmap;

        private byte[] bitmapData;
        private int stride;

        public JpgFileLayer(Guid identificator, string fileName) :
            base(identificator, 0)
        {
            this.SetInputData(fileName);
        }

        public override int Width
        {
            get
            {
                return bitmap.Width;
            }
        }

        public override int Height
        {
            get
            {
                return bitmap.Height;
            }
        }

        public override IConnectionBuilder GetConnectionBuilder()
        {
            return new EmptyConnectionBuilder();
        }

        public override PixelColor GetPixelColor(int x, int y)
        {
            var d = this.stride * y + x * 3;
            return PixelColor.FromRGB(this.bitmapData[d], this.bitmapData[d + 1], this.bitmapData[d + 2]);
        }

        public void SetInputData(string fileName)
        {
            this.bitmap = new Bitmap(fileName);

            Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            BitmapData bmpdata = bitmap.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

            this.stride = bmpdata.Stride;

            IntPtr ptr = bmpdata.Scan0;
            int bytes = this.stride * bitmap.Height;
            this.bitmapData = new byte[bytes];
            Marshal.Copy(ptr, this.bitmapData, 0, bytes);

            this.bitmap.UnlockBits(bmpdata);
        }

        public override object GetLayerView()
        {
            throw new NotImplementedException();
        }
    }
}
