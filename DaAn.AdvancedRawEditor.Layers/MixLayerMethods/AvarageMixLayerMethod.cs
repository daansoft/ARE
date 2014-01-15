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
            return PixelColor.FromNormalizedRGB((firstValue.RN + secondValue.RN) * 0.5,
                (firstValue.GN + secondValue.GN) * 0.5,
                (firstValue.BN + secondValue.BN) * 0.5);
        }

        public string Name
        {
            get;
            set;
        }
    }
}
