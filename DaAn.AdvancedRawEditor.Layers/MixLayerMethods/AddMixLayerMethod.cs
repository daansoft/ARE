using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers.MixLayerMethods
{
    public class AddMixLayerMethod : IMixLayerMethod
    {
        public PixelColor MixValue(PixelColor firstValue, PixelColor secondValue)
        {
            return PixelColor.FromNormalizedRGB(firstValue.R + secondValue.R,
                firstValue.G + secondValue.G,
                firstValue.B + secondValue.B);
        }

        public string Name
        {
            get;
            set;
        }
    }
}
