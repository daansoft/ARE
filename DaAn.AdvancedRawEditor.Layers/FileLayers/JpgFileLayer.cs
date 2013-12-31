using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers.FileLayers
{
    public class JpgFileLayer : ILayer
    {
        public Bitmap bitmap;

        public JpgFileLayer(string fileName)
        {
            this.bitmap = new Bitmap(fileName);
        }

        public int Width
        {
            get
            {
                return bitmap.Width;
            }
        }

        public int Height
        {
            get
            {
                return bitmap.Height;
            }
        }

        public string Name
        {
            get;
            set;
        }

        public PixelValue GetPixelValue(int x, int y)
        {
            return this.bitmap.GetPixel(x, y);
        }
    }
}
