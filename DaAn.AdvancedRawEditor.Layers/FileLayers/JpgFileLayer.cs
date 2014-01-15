using DaAn.AdvancedRawEditor.Layers.Abstracts;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers.FileLayers
{
    public class JpgFileLayer : Layer, IInputLayer
    {
        public Bitmap bitmap;

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
            return this.bitmap.GetPixel(x, y);
        }

        public void SetInputData(string fileName)
        {
            this.bitmap = new Bitmap(fileName);
        }
    }
}
