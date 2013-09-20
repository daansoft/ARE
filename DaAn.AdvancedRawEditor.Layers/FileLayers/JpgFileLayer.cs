using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers.FileLayers
{
    public class JpgFileLayer : Layer
    {
        public string FileName { get; set; }

        private Bitmap Image { get; set; }

        public JpgFileLayer()
        {
            this.Image = new Bitmap(this.FileName);
        }

        public override PixelValue GetPixelValue(int x, int y)
        {
            return this.Image.GetPixel(x, y);
        }

        public override string GetName()
        {
            return string.Format("[File {0}]", this.FileName);
        }

        public override int GetHeigth()
        {
            return this.Image.Height;
        }

        public override int GetWidth()
        {
            return this.Image.Width;
        }
    }
}
