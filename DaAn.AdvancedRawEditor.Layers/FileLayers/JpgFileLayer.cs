using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers.FileLayers
{
    public class JpgFileLayer : BaseLayer
    {
        public string FileName { get; set; }

        private Bitmap Image { get; set; }

        public override PixelValue GetPixelValue(int x, int y)
        {
            return this.Image.GetPixel(x, y);
        }

        public override void Initialize()
        {
            this.Image = new Bitmap(this.FileName);
        }

        public override string GetName()
        {
            return string.Format("{0}[File {1}]", this.GetPreviousLayerName(), this.FileName);
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
