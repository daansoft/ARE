using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers.EffectLayers
{
    public class BWLayer : OneInputLayer
    {
        public override PixelValue GetPixelValue(int x, int y)
        {
            var previousValue = this.InputLayer.GetPixelValue(x, y);

            var bw = (previousValue.R + previousValue.G + previousValue.B) / 3.0;

            return bw;
        }
    }
}
