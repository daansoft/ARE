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
        public ILayer PreviousLayer { get; set; }
        public ILayer NextLayer { get; set; }
        public string FileName { get; set; }

        private Bitmap Image { get; set; }

        public PixelValue GetPixelValue(int x, int y)
        {
            return this.Image.GetPixel(x, y);
        }

        public void Initialize()
        {
            this.Image = new Bitmap(this.FileName);
        }

        public int GetWidth()
        {
            throw new NotImplementedException();
        }

        public int GetHeigth()
        {
            throw new NotImplementedException();
        }

        public void AddForLayer(ILayer layer)
        {
            throw new NotImplementedException();
        }

        public void DeleteCurrentLayer()
        {
            throw new NotImplementedException();
        }

        public string GetName()
        {
            return string.Format("File {0}", this.FileName);
        }
    }
}
