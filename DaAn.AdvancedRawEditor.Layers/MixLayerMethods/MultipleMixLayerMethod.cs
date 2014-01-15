using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers.MixLayerMethods
{
    public class MultipleMixLayerMethod : IMixLayerMethod
    {
        public PixelColor MixValue(PixelColor firstValue, PixelColor secondValue)
        {
            return PixelColor.FromNormalizedRGB(firstValue.RN * secondValue.RN,
                firstValue.GN * secondValue.GN,
                firstValue.BN * secondValue.BN);
        }

        public string Name
        {
            get;
            set;
        }
    }
}
