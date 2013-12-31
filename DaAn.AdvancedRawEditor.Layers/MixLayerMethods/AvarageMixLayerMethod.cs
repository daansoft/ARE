using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers.MixLayerMethods
{
    public class AvarageMixLayerMethod : IMixLayerMethod
    {
        public PixelValue MixValue(PixelValue firstValue, PixelValue secondValue)
        {
            return (firstValue + secondValue) * 0.5;
        }

        public string Name
        {
            get;
            set;
        }
    }
}
