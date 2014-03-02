using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers.Layers
{
    public class MaskLayer : Layer
    {
        private double[][] mask { get; set; }

        public MaskLayer(Guid identificator)
            : base(identificator, 2)
        {

        }

        public override PixelColor GetPixelColor(int x, int y)
        {
            double maskedInputR = PixelColor.Max;
            double maskedInputG = PixelColor.Max;
            double maskedInputB = PixelColor.Max;

            double maskedOutputR = PixelColor.Min;
            double maskedOutputG = PixelColor.Min;
            double maskedOutputB = PixelColor.Min;

            double maskValue = this.mask[x][y];

            if (maskValue < 1.0)
            {
                PixelColor previousColor = this.Layers[0].GetPixelColor(x, y);

                maskedInputR = previousColor.R * (1 - maskValue);
                maskedInputG = previousColor.G * (1 - maskValue);
                maskedInputB = previousColor.B * (1 - maskValue);
            }

            if (maskValue > 0.0)
            {
                PixelColor previousColor = this.Layers[1].GetPixelColor(x, y);

                maskedOutputR = previousColor.R * maskValue;
                maskedOutputG = previousColor.G * maskValue;
                maskedOutputB = previousColor.B * maskValue;
            }

            return PixelColor.FromNormalizedRGB(maskedInputR + maskedOutputR,
                maskedInputG + maskedOutputG,
                maskedInputB + maskedOutputB);
        }

        public override object GetLayerView()
        {
            throw new NotImplementedException();
        }
    }
}
