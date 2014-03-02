using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers.MixLayerMethods
{
    public class AvarageMixLayerMethod : IMixLayerMethod
    {
        public PixelColor MixValue(PixelColor firstValue, PixelColor secondValue)
        {
            return PixelColor.FromNormalizedRGB((firstValue.R + secondValue.R) * 0.5,
                (firstValue.G + secondValue.G) * 0.5,
                (firstValue.B + secondValue.B) * 0.5);
        }

        public string Name
        {
            get;
            set;
        }
    }
}
