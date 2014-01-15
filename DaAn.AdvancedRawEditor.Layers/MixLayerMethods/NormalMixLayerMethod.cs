using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers.MixLayerMethods
{
    public class NormalMixLayerMethod : IMixLayerMethod
    {
        public PixelColor MixValue(PixelColor firstValue, PixelColor secondValue)
        {
            return secondValue;
        }

        public string Name
        {
            get;
            set;
        }
    }
}
