using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers.EffectLayers
{
    public class BWLayer : Layer
    {
        public  override PixelValue GetPixelValue(int x, int y)
        {
            var previousValue = this.PreviousLayer.GetPixelValue(x, y);

            var bw = (previousValue.R + previousValue.G + previousValue.B) / 3.0;

            return bw;
        }

        public override string GetName()
        {
            return "[Black & White]";
        }
    }
}
