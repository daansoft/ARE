using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers
{
    public class MaskLayer : Layer
    {
        public Layer CurrentLayer { get; set; }
        public double[][] Mask { get; set; }

        public override PixelValue GetPixelValue(int x, int y)
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

        public override void Initialize()
        {
            // TODO initialise mask
        }
        
        public override string GetName()
        {
            return string.Format("{0}[Mask layer for {1}]", this.GetPreviousLayerName(), this.CurrentLayer.GetName());
        }

        public override void AddInside(Layer beginLayer, Layer endLayer)
        {
            beginLayer.PreviousLayer = this.PreviousLayer;
            beginLayer.ParentLayer = this;
            this.CurrentLayer = endLayer;
        }

        public override void Wrap(Layer beginLayer, Layer endLayer)
        {
            this.PreviousLayer = beginLayer.PreviousLayer;
            this.CurrentLayer = endLayer;
            beginLayer.ParentLayer = this;
        }
    }
}
