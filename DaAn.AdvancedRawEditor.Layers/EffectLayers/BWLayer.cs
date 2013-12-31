using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers.EffectLayers
{
    public class BWLayer : OneInputLayer
    {
        public override PixelValue GetPixelColor(int x, int y)
        {
            var previousValue = this.InputLayer.GetPixelColor(x, y);

            return (previousValue.R + previousValue.G + previousValue.B) / 3.0;
        }
    }
}
