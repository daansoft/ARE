using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers
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

                maskedInputR = previousColor.RN * (1 - maskValue);
                maskedInputG = previousColor.GN * (1 - maskValue);
                maskedInputB = previousColor.BN * (1 - maskValue);
            }

            if (maskValue > 0.0)
            {
                PixelColor previousColor = this.Layers[1].GetPixelColor(x, y);

                maskedOutputR = previousColor.RN * maskValue;
                maskedOutputG = previousColor.GN * maskValue;
                maskedOutputB = previousColor.BN * maskValue;
            }

            return PixelColor.FromNormalizedRGB(maskedInputR + maskedOutputR,
                maskedInputG + maskedOutputG,
                maskedInputB + maskedOutputB);
        }
    }
}
