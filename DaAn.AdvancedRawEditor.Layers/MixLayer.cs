using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers
{
    public class MixLayer : TwoInputLayer
    {
        public IMixLayerMethod MixMethod { get; set; }
        
        public override PixelValue GetPixelColor(int x, int y)
        {
            return this.MixMethod.MixValue(this.FirstInputLayer.GetPixelColor(x, y), this.SecondInputLayer.GetPixelColor(x, y));
        }
    }
}
