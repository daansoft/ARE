using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers
{
    public class MaskLayer : TwoInputLayer
    {
        public double[][] Mask { get; set; }

        public override PixelValue GetPixelValue(int x, int y)
        {
            PixelValue maskedInputValue = PixelValue.White;
            PixelValue maskedOutputValue = PixelValue.Black;

            double maskValue = this.Mask[x][y];

            PixelValue inputValue = PixelValue.White;

            if (maskValue < 1.0)
            {
                maskedInputValue = this.FirstInputLayer.GetPixelValue(x, y) * (1 - maskValue);
            }

            if (maskValue > 0.0)
            {
                maskedOutputValue = this.SecondInputLayer.GetPixelValue(x, y) * maskValue;
            }

            return maskedInputValue + maskedOutputValue;
        }
    }
}
