using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers
{
    public class MaskLayer : ILayer
    {
        public ILayer PreviousLayer { get; set; }
        public ILayer CurrentLayer { get; set; }
        public ILayer NextLayer { get; set; }
        public double[][] Mask { get; set; }

        public PixelValue GetPixelValue(int x, int y)
        {
            PixelValue maskedInputValue = PixelValue.White;
            PixelValue maskedOutputValue = PixelValue.Black;

            double maskValue = this.Mask[x][y];

            PixelValue inputValue = PixelValue.White;

            if (maskValue < 1.0)
            {
                maskedInputValue = this.PreviousLayer.GetPixelValue(x, y) * (1 - maskValue);
            }

            if (maskValue > 0.0)
            {
                maskedOutputValue = this.CurrentLayer.GetPixelValue(x, y) * maskValue;
            }

            return maskedInputValue + maskedOutputValue;
        }

        public void Initialize()
        {
            // TODO initialise mask
        }

        public int GetWidth()
        {
            return this.PreviousLayer.GetWidth();
        }

        public int GetHeigth()
        {
            return this.PreviousLayer.GetHeigth();
        }


        public void AddForLayer(ILayer layer)
        {
            this.PreviousLayer = layer.PreviousLayer;
            this.CurrentLayer = layer;
            this.NextLayer = layer.NextLayer;
            layer.NextLayer.PreviousLayer = this;
        }


        public void DeleteCurrentLayer()
        {
            throw new NotImplementedException();
        }
        
        public string GetName()
        {
            return string.Format("Mask layer for {0}", this.CurrentLayer.GetName());
        }
    }
}
