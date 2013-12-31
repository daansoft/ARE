using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers
{
    public interface IMixLayerMethod
    {
        PixelValue MixValue(PixelValue firstValue, PixelValue secondValue);
        string Name { get; }
    }
}
