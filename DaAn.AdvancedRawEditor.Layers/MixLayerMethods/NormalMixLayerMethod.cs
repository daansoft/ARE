using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers.MixLayerMethods
{
    public class NormalMixLayerMethod : IMixLayerMethod
    {
        public PixelValue MixValue(PixelValue firstValue, PixelValue secondValue)
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
